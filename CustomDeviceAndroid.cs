using System;
using Android.Media;
using System.Runtime.InteropServices;
using System.Threading;
using Android.Util;
using Android.App;
using Android.Widget;
using Android.Content.PM;

namespace IDTMO
{
    class SoundClass
    {
        AudioTrack at;
        AudioRecord ar;
        int recordbufferSizeInBytes = 0;
        bool rec = false;
        bool pla = false;
        public SoundClass(Android.Content.Context ctx)
        {
            try
            {
                if (!pla)
                {
                    int bufsize = AudioTrack.GetMinBufferSize(48000, ChannelOut.Mono, Encoding.Pcm16bit);
                    bufsize = bufsize * 3;//来个三倍的缓冲区

					at = new AudioTrack(Stream.Music, 48000, ChannelOut.Mono, Encoding.Pcm16bit, bufsize, AudioTrackMode.Stream);
                    if (at.State == AudioTrackState.Initialized)
                    {
                        at.Play();
                        pla = true;
                        new Thread(GetPlayBackDataThread).Start();
                    }
                }
                if (!rec)
                {
                    recordbufferSizeInBytes = AudioRecord.GetMinBufferSize(44100, ChannelIn.Mono, Encoding.Pcm16bit);
                    recordbufferSizeInBytes = recordbufferSizeInBytes * 3;
                    ar = new AudioRecord(AudioSource.Mic, 44100, ChannelIn.Mono, Encoding.Pcm16bit, recordbufferSizeInBytes);
                    if (ar.State == State.Initialized)
                    {
                        ar.StartRecording();
                        rec = true;
                        new Thread(ProcessCapturedData).Start();
                    }
                    else
                    {
                        AlertDialog.Builder builder = new AlertDialog.Builder(ctx); ;
						builder.SetIcon(Resource.Drawable.Icon);
						builder.SetTitle("Mic-Permission Required");
						builder.SetPositiveButton("OK", delegate
						{

						});
						builder.SetNegativeButton("Cancel", delegate { });
						builder.Create().Show();
                    }
                }
                   
            }
            catch (Exception ex)
            {
				
            }
        }
        ~SoundClass()
        {
            rec = false;
            pla = false;
            at.Stop();
            at.Release();
        }
        unsafe void GetPlayBackDataThread()
        {
            try
            {

				int playbackPeriodSize = 33 * 480;
				short* playbackBuffer = stackalloc short[playbackPeriodSize];

				while (true)
                {
                    if (!pla) { break; }
                    if (playbackBuffer == null)
                    {
                        return;
                    }
					if (ts3client_acquireCustomPlaybackData("AndroidIDTMO", playbackBuffer, playbackPeriodSize) != ERROR_ok)
                    {
                        
                    }
                    else
                    {
                        short[] buffer = new short[playbackPeriodSize];
                        Marshal.Copy((IntPtr)playbackBuffer, buffer, 0, playbackPeriodSize);
						at.Write(buffer, 0, playbackPeriodSize);
                    }
                    Thread.Sleep(30);
                }
            }
            catch (Exception ex)
            {
				
            }
            
        }
        void ProcessCapturedData()
        {
            try
            {
				recordbufferSizeInBytes = 441 * 3;
                short[] audiodata = new short[recordbufferSizeInBytes];
                while (true)
                {
                    if (!rec) { break; }
                    ar.Read(audiodata, 0, recordbufferSizeInBytes);
                    uint error = ts3client_processCustomCaptureData("AndroidIDTMO", audiodata, recordbufferSizeInBytes);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
