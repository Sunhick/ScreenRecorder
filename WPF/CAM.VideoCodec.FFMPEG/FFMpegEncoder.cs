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
        private readonly ILog Log = LogManager.GetLogger(typeof (FFMpegEncoder));

        public bool Encode(HookInfo theHookInfo)
        {
            Log.Info("Start of encoding bitmaps into video stream...");
            Process aVMaker = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(theHookInfo.ExePath, theHookInfo.ExeName),
                    UseShellExecute = false,
                    CreateNoWindow = false
                }
            }; //Audio-Video maker process

            //TODO: ask If output.mp4 need to be overwritten?

#if DEBUG
            aVMaker.StartInfo.UseShellExecute = true;
            aVMaker.StartInfo.CreateNoWindow = false;
#else 
            aVMaker.StartInfo.UseShellExecute = false;
            aVMaker.StartInfo.CreateNoWindow = true;
#endif

            string aOutFile = GetOutputFile();

            //avMaker.StartInfo.Arguments = String.Format(@"-i bitmaps\{0} -vcodec huffyuv output.avi", pngLoc);
            //avMaker.StartInfo.Arguments = String.Format(@"-i bitmaps\{0} -r 20 output.mp4", pngLoc);

            aVMaker.StartInfo.Arguments = theHookInfo.Arguments;
            // String.Format(@"-i {0} -r {2} -c:v libx264 -preset slow -crf 21 {1}", ifile, outFile, Settings.Default.FramesPerSec);
            // avMaker.StartInfo.Arguments = String.Format(@" -r 20 -i bitmaps\{0} -c:v libx264 -r 20 -pix_fmt yuv420p output.mp4", pngLoc);

            if (!aVMaker.Start())
            {
                return false;
            }

            //output
            // log.Info(avMaker.StandardOutput.ReadToEnd());
            //errors
            //log.Error(avMaker.StandardError.ReadToEnd());

            aVMaker.WaitForExit();
            aVMaker.Close();

            Log.Info("End of encoding bitmaps into video stream...");
            return false;
        }

        private string GetOutputFile()
        {
            string aTempFileName = Path.GetTempFileName();
            Log.Info("Creating Video in TEMP Directory:" + aTempFileName);
            return aTempFileName;
        }
    }
}