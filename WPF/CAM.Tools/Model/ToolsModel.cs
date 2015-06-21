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

using CAM.Common;
using CAM.VideoCodec.Interfaces;
using Microsoft.Practices.Unity;

namespace CAM.Tools.Model
{
    public class ToolsModel
    {
        private readonly IUnityContainer myContainer;
        private IFFMpegEncoder myFFMpegEncoder;
        private IConfiguration myConfiguration;

        public ToolsModel(IUnityContainer theContainer)
        {
            myContainer = theContainer;
            myFFMpegEncoder = myContainer.Resolve<IFFMpegEncoder>();
            myConfiguration = myContainer.Resolve<IConfiguration>();
        }
    }
}