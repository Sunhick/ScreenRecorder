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

#region Using directives

using System;
using System.Diagnostics;
using System.IO;
using ScreenRecorder.Properties;

#endregion

namespace ScreenRecorder.Hooks
{
    /// <summary>
    ///     Hook Data
    /// </summary>
    public class HookData
    {
        /// <summary>
        ///     Arguments
        /// </summary>
        public string Arguments;

        /// <summary>
        ///     Executable
        /// </summary>
        public string Executable;

        /// <summary>
        ///     Hook ID
        /// </summary>
        public string HookId;

        /// <summary>
        ///     Mode
        /// </summary>
        public string Mode;

        /// <summary>
        ///     Path
        /// </summary>
        public string WorkingDir;

        /// <summary>
        ///     Execute
        /// </summary>
        public void Execute()
        {
            var avMaker = new Process(); //Audio-Video maker process

            avMaker.StartInfo.FileName = Path.Combine(WorkingDir, Executable);

            //TODO: ask If output.mp4 need to be overwritten?

#if DEBUG
            avMaker.StartInfo.UseShellExecute = false;
            avMaker.StartInfo.CreateNoWindow = false;
#else 
            avMaker.StartInfo.UseShellExecute = false;
            avMaker.StartInfo.CreateNoWindow = true;
#endif

            var outFile = GetOutputFile();

            //avMaker.StartInfo.Arguments = String.Format(@"-i bitmaps\{0} -vcodec huffyuv output.avi", pngLoc);
            //avMaker.StartInfo.Arguments = String.Format(@"-i bitmaps\{0} -r 20 output.mp4", pngLoc);

            avMaker.StartInfo.Arguments = VariablesParser.ExpandVariables(Arguments);
            // String.Format(@"-i {0} -r {2} -c:v libx264 -preset slow -crf 21 {1}", ifile, outFile, Settings.Default.FramesPerSec);
            // avMaker.StartInfo.Arguments = String.Format(@" -r 20 -i bitmaps\{0} -c:v libx264 -r 20 -pix_fmt yuv420p output.mp4", pngLoc);

            if (!avMaker.Start())
            {
                Console.WriteLine(Resources.AVError);
                return;
            }

            //output
            // log.Info(avMaker.StandardOutput.ReadToEnd());
            //errors
            //log.Error(avMaker.StandardError.ReadToEnd());

            avMaker.WaitForExit();
            avMaker.Close();
        }

        /// <summary>
        ///     Get output file
        /// </summary>
        private string GetOutputFile()
        {
            var file = Path.Combine(
                Settings.Default.VideoLoc, "ScreenCapture"
                );

            if (File.Exists(file))
            {
                //create unique name
                var index = 1;
                while (true)
                {
                    file = Path.Combine(
                        Settings.Default.VideoLoc, string.Format("ScreenCapture({0})", index)
                        );

                    if (!File.Exists(file)) break;
                    index++;
                }
            }

            if (string.IsNullOrEmpty(Path.GetExtension(file)))
            {
                file = Path.ChangeExtension(file, Settings.Default.VideoType.ToString());
            }

            VariablesParser.PushVariable("VIDEO_LOCATION", file);

            return file;
        }
    } // class HookData
} // namespace ScreenRecorder