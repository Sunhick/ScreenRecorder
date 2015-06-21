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

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using CAM.Configuration;
using CAM.Tools.Win32;
using CAM.VideoCodec.Interfaces;
using log4net;
using Microsoft.Practices.Unity;

namespace CAM.Tools.Model
{
    public class ToolsModel
    {
        private readonly string myBitmapLocation;
        private readonly IConfiguration myConfiguration;
        private readonly IUnityContainer myContainer;
        // ReSharper disable once InconsistentNaming
        private readonly IFFMpegEncoder myFFMpegEncoder;
        private int myBitmapCount;
        private Timer myTimer;
        private ILog Log = LogManager.GetLogger(typeof (ToolsModel));

        public ToolsModel(IUnityContainer theContainer)
        {
            myContainer = theContainer;
            myFFMpegEncoder = myContainer.Resolve<IFFMpegEncoder>();
            myConfiguration = myContainer.Resolve<IConfiguration>();
            myBitmapLocation = myConfiguration.VideoConfiguration.BitmapLocation;
            if (!Directory.Exists(myBitmapLocation))
            {
                Directory.CreateDirectory(myBitmapLocation);
            }
        }

        public void StartRecording()
        {
            int aFps = myConfiguration.VideoConfiguration.FPS;
            int aCallback = (1*1000/myConfiguration.VideoConfiguration.FPS);
            Log.DebugFormat("FPS: {0} Settings Timer callback to {1} ms", aFps, aCallback);
            myTimer = new Timer(OnTimedEvent, null, 0, aCallback);
        }

        private static Bitmap CaptureScreen(int theX, int theY, int theWidth, int theHeight)
        {
            var aBitmap = new Bitmap(theWidth, theHeight, PixelFormat.Format32bppRgb);
            using (Graphics aG = Graphics.FromImage(aBitmap))
            {
                aG.CopyFromScreen(theX, theY, 0, 0, aBitmap.Size, CopyPixelOperation.SourceCopy);

                User32.CURSORINFO aCursorInfo;
                aCursorInfo.cbSize = Marshal.SizeOf(typeof (User32.CURSORINFO));

                if (User32.GetCursorInfo(out aCursorInfo))
                {
                    // if the cursor is showing draw it on the screen shot
                    if (aCursorInfo.flags == User32.CURSOR_SHOWING)
                    {
                        // we need to get hotspot so we can draw the cursor in the correct position
                        var aIconPointer = User32.CopyIcon(aCursorInfo.hCursor);
                        User32.ICONINFO aIconInfo;

                        if (User32.GetIconInfo(aIconPointer, out aIconInfo))
                        {
                            // calculate the correct position of the cursor
                            int aIconX = aCursorInfo.ptScreenPos.x - ((int) aIconInfo.xHotspot);
                            int aIconY = aCursorInfo.ptScreenPos.y - ((int) aIconInfo.yHotspot);

                            // draw the cursor icon on top of the captured screen image
                            User32.DrawIcon(aG.GetHdc(), aIconX, aIconY, aCursorInfo.hCursor);

                            // release the handle created by call to g.GetHdc()
                            aG.ReleaseHdc();
                        }
                    }
                }
            }
            return aBitmap;
        }

        private void OnTimedEvent(object theState)
        {
            using (
                var aBitmap = CaptureScreen(0, 0, (int) SystemParameters.VirtualScreenWidth,
                    (int) SystemParameters.VirtualScreenHeight))
            {
                var aFileName = String.Format("{0}\\img{1}.png", myBitmapLocation, myBitmapCount++);
                aBitmap.Save(aFileName);
            }
        }

        public void StopRecording()
        {
            myTimer.Dispose();
            myTimer = null;

            var aVideoType = myConfiguration.VideoConfiguration.PreferedVideoType;

            var aHookInfo = myConfiguration.GetHook(aVideoType);
            myFFMpegEncoder.Encode(aHookInfo);

            string[] aTempBmps = Directory.GetFiles(myBitmapLocation, "*.png");
            foreach (var aTempBmp in aTempBmps)
            {
                File.Delete(aTempBmp);
            }
            myBitmapCount = 0;
        }
    }
}