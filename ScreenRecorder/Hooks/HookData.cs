#region File Header
/*[ Compilation unit ----------------------------------------------------------
 
   Component       : ScreenRecorder
 
   Name            : HookData.cs
 
  Author           : Sunil
 
-----------------------------------------------------------------------------*/
/*] END */
#endregion

#region Using directives
using ScreenRecorder.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Collections;
#endregion

namespace ScreenRecorder.Hooks
{
    /// <summary>
    /// Hook Data
    /// </summary>
    public class HookData
    {
        /// <summary>
        /// Hook ID
        /// </summary>
        public string HookID;

        /// <summary>
        /// Mode
        /// </summary>
        public string Mode;

        /// <summary>
        /// Executable
        /// </summary>
        public string Executable;

        /// <summary>
        /// Path
        /// </summary>
        public string WorkingDir;

        /// <summary>
        /// Arguments
        /// </summary>
        public string Arguments;

        /// <summary>
        /// Execute
        /// </summary>
        public void Execute()
        {
            Process avMaker = new Process();    //Audio-Video maker process

            avMaker.StartInfo.FileName = Path.Combine(WorkingDir, Executable);

            //TODO: ask If output.mp4 need to be overwritten?

#if DEBUG
            avMaker.StartInfo.UseShellExecute = false;
            avMaker.StartInfo.CreateNoWindow = false;
#else 
            avMaker.StartInfo.UseShellExecute = false;
            avMaker.StartInfo.CreateNoWindow = true;
#endif

            string outFile = GetOutputFile();

            //avMaker.StartInfo.Arguments = String.Format(@"-i bitmaps\{0} -vcodec huffyuv output.avi", pngLoc);
            //avMaker.StartInfo.Arguments = String.Format(@"-i bitmaps\{0} -r 20 output.mp4", pngLoc);

            avMaker.StartInfo.Arguments = VariablesParser.ExpandVariables(this.Arguments);
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
        /// Get output file
        /// </summary>
        private string GetOutputFile()
        {
            string file = Path.Combine(
                Settings.Default.VideoLoc, "ScreenCapture"
                );

            if (File.Exists(file))
            {
                //create unique name
                int index = 1;
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
