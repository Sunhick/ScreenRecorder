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

using CAM.VideoCodec.Interfaces;
using log4net;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace CAM.VideoCodec.FFMPEG
{
    // ReSharper disable once InconsistentNaming
    internal class FFMpegModule : IModule
    {
        private readonly IUnityContainer myContainer;
        private ILog Log = LogManager.GetLogger(typeof (FFMpegModule));

        public FFMpegModule(IUnityContainer theContainer)
        {
            myContainer = theContainer;
        }

        public void Initialize()
        {
            Log.Info("Initialize FFMpeg Module");
            var aFfMpegEncoder = new FFMpegEncoder();
            myContainer.RegisterInstance<IFFMpegEncoder>(aFfMpegEncoder, new ContainerControlledLifetimeManager());
        }
    }
}