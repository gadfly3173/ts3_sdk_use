using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace IDTMO
{
    using anyID = UInt16;
    using size_t = Int32;
    
    class TS3
    {
        //Memory management
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_freeMemory(IntPtr pointer);

        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern uint ts3client_freeMemory(void* pointer);


        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_initClientLib(ref ClientUIFunctions functionPointers, ref ClientUIFunctionsRare functionRarePointers, int usedLogTypes, string logFileFolder, string resourcesFolder);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_destroyClientLib();
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getClientLibVersion(ref IntPtr result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getClientLibVersionNumber(ref UInt64 result);


        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_spawnNewServerConnectionHandler(int port, out UInt64 result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_destroyServerConnectionHandler(UInt64 serverConnectionHandlerID);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_createIdentity(out IntPtr arg0);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_identityStringToUniqueIdentifier(string identityString, ref string[][] result);


        //sound
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe uint ts3client_getPlaybackDeviceList(string modeID, char**** result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe uint ts3client_getCaptureDeviceList(string modeID, char**** result);

        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getPlaybackModeList(ref string[] result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getCaptureModeList(ref string[] result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getDefaultPlaybackDevice(string modeID, ref IntPtr[] result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getDefaultCaptureDevice(string modeID, out IntPtr[] result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getDefaultPlayBackMode(ref IntPtr result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getDefaultCaptureMode(out IntPtr result);

        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_openPlaybackDevice(UInt64 serverConnectionHandlerID, string modeID, string playbackDevice);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_openCaptureDevice(UInt64 serverConnectionHandlerID, string modeID, string captureDevice);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getCurrentPlaybackDeviceName(UInt64 serverConnectionHandlerID, ref string[][] result, ref int isDefault);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getCurrentPlayBackMode(UInt64 serverConnectionHandlerID, ref string[][] result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getCurrentCaptureDeviceName(UInt64 serverConnectionHandlerID, ref string[][] result, ref int isDefault);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getCurrentCaptureMode(UInt64 serverConnectionHandlerID, ref string[][] result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_initiateGracefulPlaybackShutdown(UInt64 serverConnectionHandlerID);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_closePlaybackDevice(UInt64 serverConnectionHandlerID);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_closeCaptureDevice(UInt64 serverConnectionHandlerID);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_activateCaptureDevice(UInt64 serverConnectionHandlerID);

        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_playWaveFile(UInt64 serverConnectionHandlerID, string path);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_playWaveFileHandle(UInt64 serverConnectionHandlerID, string path, int loop, ref UInt64 waveHandle);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_pauseWaveFileHandle(UInt64 serverConnectionHandlerID, UInt64 waveHandle, int pause);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_closeWaveFileHandle(UInt64 serverConnectionHandlerID, UInt64 waveHandle);

        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_registerCustomDevice(string deviceID, string deviceDisplayName, int capFrequency, int capChannels, int playFrequency, int playChannels);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_unregisterCustomDevice(string deviceID);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_processCustomCaptureData(string deviceName, short[] buffer, int samples);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern uint ts3client_acquireCustomPlaybackData(string deviceID,short* buffer, int samples);

        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setLocalTestMode(UInt64 serverConnectionHandlerID, int status);

        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_startVoiceRecording(UInt64 serverConnectionHandlerID);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_stopVoiceRecording(UInt64 serverConnectionHandlerID);

        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_allowWhispersFrom(UInt64 serverConnectionHandlerID, anyID clID);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_removeFromAllowedWhispersFrom(UInt64 serverConnectionHandlerID, anyID clID);




        //preprocessor
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getPreProcessorInfoValueFloat(UInt64 serverConnectionHandlerID, string ident, ref float result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getPreProcessorConfigValue(UInt64 serverConnectionHandlerID, string ident, ref IntPtr result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setPreProcessorConfigValue(UInt64 serverConnectionHandlerID, string ident, string value);


        //encoder
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getEncodeConfigValue(UInt64 serverConnectionHandlerID, string ident, ref string[][] result);


        //playback
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getPlaybackConfigValueAsFloat(UInt64 serverConnectionHandlerID, string ident, ref float result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setPlaybackConfigValue(UInt64 serverConnectionHandlerID, string ident, string value);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setClientVolumeModifier(UInt64 serverConnectionHandlerID, anyID clientID, float value);


        //logging
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_logMessage(string logMessage, LogLevel severity, string channel, UInt64 logID);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setLogVerbosity(LogLevel logVerbosity);


        //error handling
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getErrorMessage(uint errorCode, ref IntPtr error);


        //Interacting with the server
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_startConnection(UInt64 serverConnectionHandlerID, string identity, string ip, uint port,
            byte[] nickname, string[] defaultChannelArray, string defaultChannelPassword, string serverPassword);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_stopConnection(UInt64 serverConnectionHandlerID, string quitMessage);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestClientMove(UInt64 serverConnectionHandlerID, anyID clientID, UInt64 newChannelID, string password, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestClientVariables(UInt64 serverConnectionHandlerID, anyID clientID, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestClientKickFromChannel(UInt64 serverConnectionHandlerID, anyID clientID, string kickReason, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestClientKickFromServer(UInt64 serverConnectionHandlerID, anyID clientID, string kickReason, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestChannelDelete(UInt64 serverConnectionHandlerID, UInt64 channelID, int force, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestChannelMove(UInt64 serverConnectionHandlerID, UInt64 channelID, UInt64 newChannelParentID, UInt64 newChannelOrder, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestSendPrivateTextMsg(UInt64 serverConnectionHandlerID, byte[] message, anyID targetClientID, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestSendChannelTextMsg(UInt64 serverConnectionHandlerID, byte[] message, UInt64 targetChannelID, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestSendServerTextMsg(UInt64 serverConnectionHandlerID, byte[] message, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestConnectionInfo(UInt64 serverConnectionHandlerID, anyID clientID, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestClientSetWhisperList(UInt64 serverConnectionHandlerID, anyID clientID, UInt64[] targetChannelIDArray, anyID[] targetClientIDArray, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestChannelSubscribe(UInt64 serverConnectionHandlerID, UInt64 channelIDArray, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestChannelSubscribeAll(UInt64 serverConnectionHandlerID, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestChannelUnsubscribe(UInt64 serverConnectionHandlerID, UInt64 channelIDArray, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestChannelUnsubscribeAll(UInt64 serverConnectionHandlerID, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestChannelDescription(UInt64 serverConnectionHandlerID, UInt64 channelID, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestMuteClients(UInt64 serverConnectionHandlerID, anyID clientIDArray, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestUnmuteClients(UInt64 serverConnectionHandlerID, anyID clientIDArray, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestClientIDs(UInt64 serverConnectionHandlerID, string clientUniqueIdentifier, byte[] returnCode);


        //provisioning server calls
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestSlotsFromProvisioningServer(string ip, ushort port, string serverPassword, ushort slots, string identity, string region, ref UInt64 requestHandle);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_cancelRequestSlotsFromProvisioningServer(UInt64 requestHandle);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_startConnectionWithProvisioningKey(UInt64 serverConnectionHandlerID, string identity, string nickname, string connectionKey, string clientMetaData);



        //general info
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getClientID(UInt64 serverConnectionHandlerID, ref anyID result);



        //client connection info
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getConnectionStatus(UInt64 serverConnectionHandlerID, ref int result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getConnectionVariableAsUInt64(UInt64 serverConnectionHandlerID, anyID clientID, size_t flag, ref UInt64 result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getConnectionVariableAsDouble(UInt64 serverConnectionHandlerID, anyID clientID, size_t flag, ref double result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getConnectionVariableAsString(UInt64 serverConnectionHandlerID, anyID clientID, size_t flag, ref IntPtr result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_cleanUpConnectionInfo(UInt64 serverConnectionHandlerID, anyID clientID);



        //server connection info
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestServerConnectionInfo(UInt64 serverConnectionHandlerID, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getServerConnectionVariableAsUInt64(UInt64 serverConnectionHandlerID, size_t flag, ref UInt64 result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getServerConnectionVariableAsFloat(UInt64 serverConnectionHandlerID, size_t flag, ref float result);



        //client info
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getClientSelfVariableAsInt(UInt64 serverConnectionHandlerID, size_t flag, ref int result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getClientSelfVariableAsString(UInt64 serverConnectionHandlerID, size_t flag, ref IntPtr result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setClientSelfVariableAsInt(UInt64 serverConnectionHandlerID, size_t flag, int value);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setClientSelfVariableAsString(UInt64 serverConnectionHandlerID, size_t flag, byte[] value);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_flushClientSelfUpdates(UInt64 serverConnectionHandlerID, byte[] returnCode);

        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getClientVariableAsInt(UInt64 serverConnectionHandlerID, anyID clientID, size_t flag, ref int result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getClientVariableAsUInt64(UInt64 serverConnectionHandlerID, anyID clientID, size_t flag, ref UInt64 result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getClientVariableAsString(UInt64 serverConnectionHandlerID, anyID clientID, size_t flag, ref IntPtr result);

        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getClientList(UInt64 serverConnectionHandlerID, ref anyID[] result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getChannelOfClient(UInt64 serverConnectionHandlerID, anyID clientID, ref UInt64 result);



        //channel info
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getChannelVariableAsInt(UInt64 serverConnectionHandlerID, UInt64 channelID, size_t flag, ref int result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getChannelVariableAsUInt64(UInt64 serverConnectionHandlerID, UInt64 channelID, size_t flag, ref UInt64 result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getChannelVariableAsString(UInt64 serverConnectionHandlerID, UInt64 channelID, size_t flag, out IntPtr result);

        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getChannelIDFromChannelNames(UInt64 serverConnectionHandlerID, string[] channelNameArray, ref UInt64 result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setChannelVariableAsInt(UInt64 serverConnectionHandlerID, UInt64 channelID, size_t flag, int value);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setChannelVariableAsUInt64(UInt64 serverConnectionHandlerID, UInt64 channelID, size_t flag, UInt64 value);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setChannelVariableAsString(UInt64 serverConnectionHandlerID, UInt64 channelID, size_t flag, string value);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setChannelVariableAsString(UInt64 serverConnectionHandlerID, UInt64 channelID, size_t flag, byte[] value);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_flushChannelUpdates(UInt64 serverConnectionHandlerID, UInt64 channelID, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_flushChannelCreation(UInt64 serverConnectionHandlerID, UInt64 channelParentID, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern uint ts3client_getChannelList(UInt64 serverConnectionHandlerID, ulong** result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern uint ts3client_getChannelClientList(UInt64 serverConnectionHandlerID, UInt64 channelID, anyID** result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getParentChannelOfChannel(UInt64 serverConnectionHandlerID, UInt64 channelID, ref UInt64 result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getChannelEmptySecs(UInt64 serverConnectionHandlerID, UInt64 channelID, ref int result);

        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getServerConnectionHandlerList(UInt64[][] result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getServerVariableAsInt(UInt64 serverConnectionHandlerID, size_t flag, ref int result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getServerVariableAsUInt64(UInt64 serverConnectionHandlerID, size_t flag, ref UInt64 result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getServerVariableAsString(UInt64 serverConnectionHandlerID, size_t flag, ref IntPtr result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestServerVariables(UInt64 serverConnectionHandlerID);

        //filetransfer management
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getTransferFileName(anyID transferID, ref string[][] result); //The returned memory is dynamically allocated, remember to call ts3client_freeMemory() to release it
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getTransferFilePath(anyID transferID, ref string[][] result); //The returned memory is dynamically allocated, remember to call ts3client_freeMemory() to release it
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getTransferFileRemotePath(anyID transferID, ref string[][] result); //The returned memory is dynamically allocated, remember to call ts3client_freeMemory() to release it
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getTransferFileSize(anyID transferID, ref UInt64 result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getTransferFileSizeDone(anyID transferID, ref UInt64 result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_isTransferSender(anyID transferID, ref int result); //1 == upload, 0 == download
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getTransferStatus(anyID transferID, ref int result);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getCurrentTransferSpeed(anyID transferID, ref float result); //bytes/second within the last few seconds
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getAverageTransferSpeed(anyID transferID, ref float result); //bytes/second since start of the transfer
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getTransferRunTime(anyID transferID, ref UInt64 result);

        //Interacting with the server - file transfers
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_sendFile(UInt64 serverConnectionHandlerID, UInt64 channelID, string channelPW, string file, int overwrite, int resume, string sourceDirectory, ref anyID result, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestFile(UInt64 serverConnectionHandlerID, UInt64 channelID, string channelPW, string file, int overwrite, int resume, string destinationDirectory, ref anyID result, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_haltTransfer(UInt64 serverConnectionHandlerID, anyID transferID, int deleteUnfinishedFile, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestFileList(UInt64 serverConnectionHandlerID, UInt64 channelID, string channelPW, string path, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestFileInfo(UInt64 serverConnectionHandlerID, UInt64 channelID, string channelPW, string file, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestDeleteFile(UInt64 serverConnectionHandlerID, UInt64 channelID, string channelPW, ref string file, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestCreateDirectory(UInt64 serverConnectionHandlerID, UInt64 channelID, string channelPW, string directoryPath, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_requestRenameFile(UInt64 serverConnectionHandlerID, UInt64 fromChannelID, string fromChannelPW, UInt64 toChannelID, string toChannelPW, string oldFile, string newFile, byte[] returnCode);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getInstanceSpeedLimitUp(ref UInt64 limit);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getInstanceSpeedLimitDown(ref UInt64 limit);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getServerConnectionHandlerSpeedLimitUp(UInt64 serverConnectionHandlerID, ref UInt64 limit);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getServerConnectionHandlerSpeedLimitDown(UInt64 serverConnectionHandlerID, ref UInt64 limit);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_getTransferSpeedLimit(anyID transferID, ref UInt64 limit);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setInstanceSpeedLimitUp(UInt64 newLimit);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setInstanceSpeedLimitDown(UInt64 newLimit);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setServerConnectionHandlerSpeedLimitUp(UInt64 serverConnectionHandlerID, UInt64 newLimit);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setServerConnectionHandlerSpeedLimitDown(UInt64 serverConnectionHandlerID, UInt64 newLimit);
        [DllImport("libts3client_android.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ts3client_setTransferSpeedLimit(anyID transferID, UInt64 newLimit);
        public struct ClientUIFunctions
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onConnectStatusChangeEventDelegate(UInt64 serverConnectionHandlerID, int newStatus, uint errorNumber);
            public onConnectStatusChangeEventDelegate onConnectStatusChangeEvent;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onServerProtocolVersionEventDelegate(UInt64 serverConnectionHandlerID, int protocolVersion);
            public onServerProtocolVersionEventDelegate onServerProtocolVersionEvent;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onNewChannelEventDelegate(UInt64 serverConnectionHandlerID, UInt64 channelID, UInt64 channelParentID);
            public onNewChannelEventDelegate onNewChannelEvent;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onNewChannelCreatedEventDelegate(UInt64 serverConnectionHandlerID, UInt64 channelID, UInt64 channelParentID, anyID invokerID, string invokerName, string invokerUniqueIdentifier);
            public onNewChannelCreatedEventDelegate onNewChannelCreatedEvent;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onDelChannelEventDelegate(UInt64 serverConnectionHandlerID, UInt64 channelID, anyID invokerID, string invokerName, string invokerUniqueIdentifier);
            public onDelChannelEventDelegate onDelChannelEvent;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onChannelMoveEventDelegate(UInt64 serverConnectionHandlerID, UInt64 channelID, UInt64 newChannelParentID, anyID invokerID, string invokerName, string invokerUniqueIdentifier);
            public onChannelMoveEventDelegate onChannelMoveEvent;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onUpdateChannelEventDelegate(UInt64 serverConnectionHandlerID, UInt64 channelID);
            public onUpdateChannelEventDelegate onUpdateChannelEvent;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onUpdateChannelEditedEventDelegate(UInt64 serverConnectionHandlerID, UInt64 channelID, anyID invokerID, string invokerName, string invokerUniqueIdentifier);
            public onUpdateChannelEditedEventDelegate onUpdateChannelEditedEvent;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onUpdateClientEventDelegate(UInt64 serverConnectionHandlerID, anyID clientID, anyID invokerID, string invokerName, string invokerUniqueIdentifier);
            public onUpdateClientEventDelegate onUpdateClientEvent;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onClientMoveEventDelegate(UInt64 serverConnectionHandlerID, anyID clientID, UInt64 oldChannelID, UInt64 newChannelID, int visibility, string moveMessage);
            public onClientMoveEventDelegate onClientMoveEvent;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onClientMoveSubscriptionEventDelegate(UInt64 serverConnectionHandlerID, anyID clientID, UInt64 oldChannelID, UInt64 newChannelID, int visibility);
            public onClientMoveSubscriptionEventDelegate onClientMoveSubscriptionEvent;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onClientMoveTimeoutEventDelegate(UInt64 serverConnectionHandlerID, anyID clientID, UInt64 oldChannelID, UInt64 newChannelID, int visibility, string timeoutMessage);
            public onClientMoveTimeoutEventDelegate onClientMoveTimeoutEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onClientMoveMovedEventDelegate(UInt64 serverConnectionHandlerID, anyID clientID, UInt64 oldChannelID, UInt64 newChannelID, int visibility, anyID moverID, IntPtr moverName, string moverUniqueIdentifier, string moveMessage);
            public onClientMoveMovedEventDelegate onClientMoveMovedEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onClientKickFromChannelEventDelegate(UInt64 serverConnectionHandlerID, anyID clientID, UInt64 oldChannelID, UInt64 newChannelID, int visibility, anyID kickerID, IntPtr kickerName, string kickerUniqueIdentifier, string kickMessage);
            public onClientKickFromChannelEventDelegate onClientKickFromChannelEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onClientKickFromServerEventDelegate(UInt64 serverConnectionHandlerID, anyID clientID, UInt64 oldChannelID, UInt64 newChannelID, int visibility, anyID kickerID, IntPtr kickerName, string kickerUniqueIdentifier, string kickMessage);
            public onClientKickFromServerEventDelegate onClientKickFromServerEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onClientIDsEventDelegate(UInt64 serverConnectionHandlerID, string uniqueClientIdentifier, anyID clientID, string clientName);
            public onClientIDsEventDelegate onClientIDsEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onClientIDsFinishedEventDelegate(UInt64 serverConnectionHandlerID);
            public onClientIDsFinishedEventDelegate onClientIDsFinishedEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onServerEditedEventDelegate(UInt64 serverConnectionHandlerID, anyID editerID, string editerName, string editerUniqueIdentifier);
            public onServerEditedEventDelegate onServerEditedEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onServerUpdatedEventDelegate(UInt64 serverConnectionHandlerID);
            public onServerUpdatedEventDelegate onServerUpdatedEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onServerErrorEventDelegate(UInt64 serverConnectionHandlerID, string errorMessage, uint error, IntPtr returnCode, string extraMessage);
            public onServerErrorEventDelegate onServerErrorEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onServerStopEventDelegate(UInt64 serverConnectionHandlerID, string shutdownMessage);
            public onServerStopEventDelegate onServerStopEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onTextMessageEventDelegate(UInt64 serverConnectionHandlerID, anyID targetMode, anyID toID, anyID fromID, IntPtr fromName, string fromUniqueIdentifier, IntPtr message);
            public onTextMessageEventDelegate onTextMessageEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onTalkStatusChangeEventDelegate(UInt64 serverConnectionHandlerID, int status, int isReceivedWhisper, anyID clientID);
            public onTalkStatusChangeEventDelegate onTalkStatusChangeEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onIgnoredWhisperEventDelegate(UInt64 serverConnectionHandlerID, anyID clientID);
            public onIgnoredWhisperEventDelegate onIgnoredWhisperEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onConnectionInfoEventDelegate(UInt64 serverConnectionHandlerID, anyID clientID);
            public onConnectionInfoEventDelegate onConnectionInfoEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onServerConnectionInfoEventDelegate(UInt64 serverConnectionHandlerID);
            public onServerConnectionInfoEventDelegate onServerConnectionInfoEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onChannelSubscribeEventDelegate(UInt64 serverConnectionHandlerID, UInt64 channelID);
            public onChannelSubscribeEventDelegate onChannelSubscribeEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onChannelSubscribeFinishedEventDelegate(UInt64 serverConnectionHandlerID);
            public onChannelSubscribeFinishedEventDelegate onChannelSubscribeFinishedEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onChannelUnsubscribeEventDelegate(UInt64 serverConnectionHandlerID, UInt64 channelID);
            public onChannelUnsubscribeEventDelegate onChannelUnsubscribeEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onChannelUnsubscribeFinishedEventDelegate(UInt64 serverConnectionHandlerID);
            public onChannelUnsubscribeFinishedEventDelegate onChannelUnsubscribeFinishedEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onChannelDescriptionUpdateEventDelegate(UInt64 serverConnectionHandlerID, UInt64 channelID);
            public onChannelDescriptionUpdateEventDelegate onChannelDescriptionUpdateEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onChannelPasswordChangedEventDelegate(UInt64 serverConnectionHandlerID, UInt64 channelID);
            public onChannelPasswordChangedEventDelegate onChannelPasswordChangedEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onPlaybackShutdownCompleteEventDelegate(UInt64 serverConnectionHandlerID);
            public onPlaybackShutdownCompleteEventDelegate onPlaybackShutdownCompleteEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onSoundDeviceListChangedEventDelegate(string modeID, int playOrCap);
            public onSoundDeviceListChangedEventDelegate onSoundDeviceListChangedEvent;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onEditPlaybackVoiceDataEventDelegate(UInt64 serverConnectionHandlerID, anyID clientID, ref short samples, int sampleCount, int channels);
            public onEditPlaybackVoiceDataEventDelegate onEditPlaybackVoiceDataEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public unsafe delegate void onEditPostProcessVoiceDataEventDelegate(UInt64 serverConnectionHandlerID, anyID clientID, short* samples, int sampleCount, int channels, uint* channelSpeakerArray, uint* channelFillMask);
            public onEditPostProcessVoiceDataEventDelegate onEditPostProcessVoiceDataEvent;
            public unsafe delegate void onEditMixedPlaybackVoiceDataEventDelegate(UInt64 serverConnectionHandlerID, short* samples, int sampleCount, int channels, uint* channelSpeakerArray, uint* channelFillMask);
            public onEditMixedPlaybackVoiceDataEventDelegate onEditMixedPlaybackVoiceDataEvent;
            public unsafe delegate void onEditCapturedVoiceDataEventDelegate(UInt64 serverConnectionHandlerID, short* samples, int sampleCount, int channels, int* edited);
            public onEditCapturedVoiceDataEventDelegate onEditCapturedVoiceDataEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onCustom3dRolloffCalculationClientEventDelegate(UInt64 serverConnectionHandlerID, anyID clientID, float distance, ref float volume);
            public onCustom3dRolloffCalculationClientEventDelegate onCustom3dRolloffCalculationClientEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onCustom3dRolloffCalculationWaveEventDelegate(UInt64 serverConnectionHandlerID, UInt64 waveHandle, float distance, ref float volume);
            public onCustom3dRolloffCalculationWaveEventDelegate onCustom3dRolloffCalculationWaveEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onUserLoggingMessageEventDelegate(string logmessage, int logLevel, string logChannel, UInt64 logID, string logTime, string completeLogString);
            public onUserLoggingMessageEventDelegate onUserLoggingMessageEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onCustomPacketEncryptEventDelegate(ref string[][] dataToSend, ref uint sizeOfData);
            public onCustomPacketEncryptEventDelegate onCustomPacketEncryptEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onCustomPacketDecryptEventDelegate(ref string[][] dataReceived, ref uint dataReceivedSize);
            public onCustomPacketDecryptEventDelegate onCustomPacketDecryptEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onProvisioningSlotRequestResultEventDelegate(uint error, UInt64 requestHandle, string connectionKey);
            public onProvisioningSlotRequestResultEventDelegate onProvisioningSlotRequestResultEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onCheckServerUniqueIdentifierEventDelegate(UInt64 serverConnectionHandlerID, string ServerUniqueIdentifier, ref int cancelConnect);
            public onCheckServerUniqueIdentifierEventDelegate onCheckServerUniqueIdentifierEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onClientPasswordEncryptDelegate(UInt64 serverConnectionHandlerID, string plaintext, IntPtr encryptedText, int encryptedTextByteSize);
            public onClientPasswordEncryptDelegate onClientPasswordEncrypt;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onFileTransferStatusEventDelegate(anyID transferID, uint status, string statusMessage, UInt64 remotefileSize, UInt64 serverConnectionHandlerID);
            public onFileTransferStatusEventDelegate onFileTransferStatusEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onFileListEventDelegate(UInt64 serverConnectionHandlerID, UInt64 channelID, string path, string name, UInt64 size, UInt64 datetime, int type, UInt64 incompletesize, byte[] returnCode);
            public onFileListEventDelegate onFileListEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onFileListFinishedEventDelegate(UInt64 serverConnectionHandlerID, UInt64 channelID, string path);
            public onFileListFinishedEventDelegate onFileListFinishedEvent;
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void onFileInfoEventDelegate(UInt64 serverConnectionHandlerID, UInt64 channelID, string name, UInt64 size, UInt64 datetime);
            public onFileInfoEventDelegate onFileInfoEvent;
        } //END OF ClientUIFunctions
        public struct ClientUIFunctionsRare
        {
            public int a;
        }
    }
}
