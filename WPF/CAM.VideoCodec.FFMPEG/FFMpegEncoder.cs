// This file is part of ScreenRecorder
//  
// ScreenRecorder  is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// ScreenRecorder is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with ScreenRecorder.  If not, see <http://www.gnu.org/licenses/>.

using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using CAM.Common;
using CAM.VideoCodec.Interfaces;
using log4net;

namespace CAM.VideoCodec.FFMPEG
{
    /// <summary>
    ///     FFMPEG Encoder
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class FFMpegEncoder : IFFMpegEncoder
    {
        private readonly ILog Log = LogManager.GetLogger(typeof(FFMpegEncoder));

        public string Encode(EncoderInfo theEncoderInfo)
        {
            Log.Info("Start of encoding bitmaps into video stream...");

            //Audio-Video maker process
            using (var aVMaker = new Process())
            {
                aVMaker.StartInfo.FileName = Path.Combine(theEncoderInfo.ExePath, theEncoderInfo.ExeName);
                aVMaker.StartInfo.RedirectStandardOutput = true;
                aVMaker.StartInfo.RedirectStandardError = true;

#if DEBUG
                aVMaker.StartInfo.UseShellExecute = false;
                aVMaker.StartInfo.CreateNoWindow = false;
#else 
                aVMaker.StartInfo.UseShellExecute = false;
                aVMaker.StartInfo.CreateNoWindow = true;
#endif
                var aOutFile = GetOutputFile(theEncoderInfo.HookId);

                //avMaker.StartInfo.Arguments = String.Format(@"-i bitmaps\{0} -vcodec huffyuv output.avi", pngLoc);
                //avMaker.StartInfo.Arguments = String.Format(@"-i bitmaps\{0} -r 20 output.mp4", pngLoc);

                aVMaker.StartInfo.Arguments = theEncoderInfo.Arguments + "\\" + aOutFile;
                // String.Format(@"-i {0} -r {2} -c:v libx264 -preset slow -crf 21 {1}", ifile, outFile, Settings.Default.FramesPerSec);
                // avMaker.StartInfo.Arguments = String.Format(@" -r 20 -i bitmaps\{0} -c:v libx264 -r 20 -pix_fmt yuv420p output.mp4", pngLoc);

                var aOutput = new StringBuilder();
                var aError = new StringBuilder();

                using (var aOutputWaitHandle = new AutoResetEvent(false))
                {
                    using (var aErrorWaitHandle = new AutoResetEvent(false))
                    {
                        {
                            aVMaker.OutputDataReceived += (theSender, theArgs) =>
                            {
                                if (theArgs.Data == null)
                                {
                                    aOutputWaitHandle.Set();
                                }
                                else
                                {
                                    aOutput.AppendLine(theArgs.Data);
                                }
                            };
                            aVMaker.ErrorDataReceived += (theSender, theArgs) =>
                            {
                                if (theArgs.Data == null)
                                {
                                    aErrorWaitHandle.Set();
                                }
                                else
                                {
                                    aError.AppendLine(theArgs.Data);
                                }
                            };

                            if (!aVMaker.Start())
                            {
                                Log.Error("Error in starting the FFMPEG process!");
                            }

                            aVMaker.BeginOutputReadLine();
                            aVMaker.BeginErrorReadLine();

                            // Log FFMPEG output and errors
                            Log.Info(aOutput);
                            Log.Error(aError);

                            if (aVMaker.WaitForExit(int.MaxValue) &&
                                aOutputWaitHandle.WaitOne() &&
                                aErrorWaitHandle.WaitOne())
                            {
                                // Process completed. Check process.ExitCode here.
                                Log.Info("FFMPEG Process completed! Error code:" + aVMaker.ExitCode);
                            }
                            else
                            {
                                // Timed out.
                                Log.Info("FFMPEG Process timeout!");
                            }

                            return aOutFile;
                        }
                    }
                }
            }
        }

        private string GetOutputFile(string theHookId)
        {
            var aTempFileName = Path.ChangeExtension(Path.GetTempFileName(), theHookId);
            Log.Info("Creating Video in TEMP Directory:" + aTempFileName);
            return Path.GetFileName(aTempFileName);
        }
    }
}