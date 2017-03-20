#ifndef SoundClass_h
#define SoundClass_h
#include <AudioToolbox/AudioQueue.h>
#import <AVFoundation/AVFoundation.h>
#import <UIKit/UIKit.h>



@interface SoundClass : NSObject
{
    AudioQueueBufferRef _recBuffers [1];
    AudioQueueBufferRef _playBuffers [2];
    AudioQueueRef _recordQueue; //放音的
    AudioQueueRef _playQueue;
}
-(void) InitSoundClass;
-(void)DestroyClass;
@end

//
//  SoundClass.m
//  IDTMOiOS
//
//  Created by Maozhenyu on 16/10/30.
//  Copyright © 2016年 Maozhenyu. All rights reserved.
//

#import <Foundation/Foundation.h>
#include "SoundClass.h"
#include "teamspeak/clientlib.h"
#include "main.h"

@interface SoundClass ()

@end

@implementation SoundClass

#define ProcessPeo 0.03
#define PlayBaSam 48000
#define RecordSam 44100



void inputBufferHandler(void *inUserData, AudioQueueRef inAQ, AudioQueueBufferRef inBuffer, const AudioTimeStamp *inStartTime,UInt32 inNumPackets, const AudioStreamPacketDescription *inPacketDesc)
{
    if (inNumPackets > 0) {
        if((ts3client_processCustomCaptureData("ZheneriOSSound", inBuffer->mAudioData, inNumPackets)) != 0){
        }
    }
    AudioQueueEnqueueBuffer(inAQ, inBuffer, 0, NULL);
}

static void outputBufferHandler(void *inUserData,AudioQueueRef inAQ,AudioQueueBufferRef buffer){
    uint error=0;
    error=ts3client_acquireCustomPlaybackData("ZheneriOSSound",buffer->mAudioData,ProcessPeo*PlayBaSam);
//    if(error!= 0){
//        //如果失败
//        //这里就填充 如果失败的话
//        //然后测试如果没有process的情况下，PTT能不能安秀
////        if(error != 2327) { //this error signals us to play silence
////            return;
////        }
//    }
    AudioQueueEnqueueBuffer(inAQ, buffer, 0, NULL);
}
-(void)routeChange:(NSNotification *)notification{
    NSDictionary *interuptionDict = notification.userInfo;
    
    NSInteger routeChangeReason = [[interuptionDict valueForKey:AVAudioSessionRouteChangeReasonKey] integerValue];
    switch (routeChangeReason) {
            
        case AVAudioSessionRouteChangeReasonNewDeviceAvailable:
            [[AVAudioSession sharedInstance] overrideOutputAudioPort:AVAudioSessionPortOverrideNone error:nil];
            break;
            
        case AVAudioSessionRouteChangeReasonOldDeviceUnavailable:
            [[AVAudioSession sharedInstance] overrideOutputAudioPort:AVAudioSessionPortOverrideSpeaker error:nil];
            break;
    }
    AudioQueuePause(_recordQueue);
    AudioQueueStart(_recordQueue, nil);
    AudioQueuePause(_playQueue);
    AudioQueueStart(_playQueue, nil);
    //AVAudioSession *session = [AVAudioSession sharedInstance];
    //如果是蓝牙 放蓝牙 如果是耳机 Airplay bluetooth
    //
}

-(void) InitSoundClass
{
    NSError* error;
    AVAudioSession *session=[AVAudioSession sharedInstance];
    //AVAudioSessionPortOverrideSpeaker
    [session setMode:AVAudioSessionModeVoiceChat error:nil];
    
    if (![session setCategory:AVAudioSessionCategoryPlayAndRecord withOptions:AVAudioSessionCategoryOptionMixWithOthers| AVAudioSessionCategoryOptionDefaultToSpeaker  error:nil])
    {
        InMain([GB AddLog:@"IDTMO语音系统无法启动。" black:true];)
        return;
    }
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(routeChange:) name:AVAudioSessionRouteChangeNotification object:nil];
    
    
    [[NSNotificationCenter defaultCenter] addObserverForName:AVAudioSessionInterruptionNotification object:session queue:nil usingBlock:^(NSNotification *notification)
    {
        int status=[[notification.userInfo valueForKey:AVAudioSessionInterruptionTypeKey] intValue];
                if ( status== AVAudioSessionInterruptionTypeBegan)
        {
            InMain([GB AddLog:@"IDTMO语音已被其他应用中断，请关闭这些程序。" black:true];)
            InMain([GB.main.TXSwitchBtn setOn:false];)
            AudioQueuePause(_playQueue);
            AudioQueuePause(_recordQueue);
        }
       else if(status==AVAudioSessionInterruptionTypeEnded)
        {
            [[AVAudioSession sharedInstance] setActive:TRUE error:nil]; //重新激活
            InMain([GB.main.TXSwitchBtn setOn:true];)
            AudioQueueStart(_recordQueue,nil);
            AudioQueueStart(_playQueue,nil);
            InMain([GB AddLog:@"IDTMO语音已恢复。" black:true];)
        }
    }];
    if (![session setActive:YES error:&error]) //声音系统启动失败
    {
        return;
    }
    switch ([AVAudioSession sharedInstance].recordPermission) {
        case AVAudioSessionRecordPermissionUndetermined: {
            UIAlertView *a = [[UIAlertView alloc] initWithTitle:@"授权提示"
                                                        message:@"你需要授权IDTMO获取录音权限才能TX。"
                                                       delegate:self
                                              cancelButtonTitle:@"好的"
                                              otherButtonTitles:nil, nil];
            [a show];
            break;
        }
            
        case AVAudioSessionRecordPermissionDenied:
            [[[CustomAlertView alloc] initWithTitle:@"您拒绝了IDTMO使用麦克风的请求，因此无法TX。如果需要恢复，请去系统设置。" message:@"TX无法使用" delegate:nil cancelButtonTitle:@"确定" otherButtonTitles: nil] show];
            [PF Device_Muted:true MT:true]; //禁止TX使用
            break;
        case AVAudioSessionRecordPermissionGranted: {
            break;
        }
            
        default:
            break;
    }
    [session requestRecordPermission:^(BOOL granted) {
        if(granted) {
            //录音部分开始
            AudioStreamBasicDescription _recordFormat;
            bzero(&_recordFormat, sizeof(AudioStreamBasicDescription));
            _recordFormat.mSampleRate         = RecordSam;
            _recordFormat.mFormatID           = kAudioFormatLinearPCM;
            _recordFormat.mFormatFlags        = kAudioFormatFlagIsSignedInteger |
            kAudioFormatFlagsNativeEndian |
            kAudioFormatFlagIsPacked;
            _recordFormat.mFramesPerPacket    = 1;
            _recordFormat.mChannelsPerFrame   = 1;
            _recordFormat.mBitsPerChannel     = 16;
            _recordFormat.mBytesPerPacket = _recordFormat.mBytesPerFrame = (_recordFormat.mBitsPerChannel / 8) * _recordFormat.mChannelsPerFrame;
            
            
            AudioQueueNewInput(&_recordFormat, inputBufferHandler, (__bridge void *)(self), NULL, NULL, 0, &_recordQueue);
            
            int bufferByteSize = ceil(ProcessPeo * _recordFormat.mSampleRate) * _recordFormat.mBytesPerFrame;
            
            for (int i = 0; i < 1; i++){
                AudioQueueAllocateBuffer(_recordQueue, bufferByteSize, &_recBuffers[i]);
                AudioQueueEnqueueBuffer(_recordQueue, _recBuffers[i], 0, NULL);
            }
            
            AudioQueueStart(_recordQueue, NULL);
                //录音部分结束
        }
        else{
            //移动到上面处理
        }
    }];
    
    
    //播放部分开始
    AudioStreamBasicDescription audioFormat;
    bzero(&audioFormat, sizeof(AudioStreamBasicDescription));
    audioFormat.mSampleRate         = PlayBaSam;
    audioFormat.mFormatID           = kAudioFormatLinearPCM;
    audioFormat.mFormatFlags        = kAudioFormatFlagIsSignedInteger |
    kAudioFormatFlagsNativeEndian |
    kAudioFormatFlagIsPacked;
    audioFormat.mFramesPerPacket    = 1;
    audioFormat.mChannelsPerFrame   = 1;
    audioFormat.mBitsPerChannel     = 16;
    audioFormat.mBytesPerPacket = audioFormat.mBytesPerFrame = (audioFormat.mBitsPerChannel / 8) * audioFormat.mChannelsPerFrame;
    
    
    AudioQueueNewOutput(&audioFormat,outputBufferHandler, (__bridge void *)(self), NULL,NULL, 0, &_playQueue);
    int bufferByteSize = ceil(ProcessPeo * audioFormat.mSampleRate) * audioFormat.mBytesPerFrame;
    for(int i=0;i<2;i++)
    {
        AudioQueueAllocateBuffer(_playQueue, bufferByteSize, &_playBuffers[i]);
        _playBuffers[i]->mAudioDataByteSize=bufferByteSize;
        outputBufferHandler(nil,_playQueue,_playBuffers[i]);
    }
    AudioQueueSetParameter (_playQueue,kAudioQueueParam_Volume,2);
    AudioQueueStart(_playQueue, NULL);

    
}
-(void)DestroyClass
{
    [[AVAudioSession sharedInstance] setActive:FALSE error:nil];//关闭音乐会话
    AudioQueueDispose(_playQueue, true);
    AudioQueueDispose(_recordQueue, true);
    [[NSNotificationCenter defaultCenter] removeObserver:self];
}
@end
