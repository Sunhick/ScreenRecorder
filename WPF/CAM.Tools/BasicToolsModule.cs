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

using CAM.Tools.Views;
using log4net;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace CAM.Tools
{
    public class BasicToolsModule : IModule
    {
        private readonly ILog Log = LogManager.GetLogger(typeof (BasicToolsModule));
        private readonly IUnityContainer myContainer;
        private readonly IEventAggregator myEventAggregator;
        private readonly IRegionManager myRegionManager;

        public BasicToolsModule(IUnityContainer theContainer, IRegionManager theRegionManager,
            IEventAggregator theEventAggregator)
        {
            myContainer = theContainer;
            myRegionManager = theRegionManager;
            myEventAggregator = theEventAggregator;
        }

        public void Initialize()
        {
            Log.Info("Initializing Basic Tools Module");
            myRegionManager.RegisterViewWithRegion("ToolsRegion", typeof (ToolsView));
            myRegionManager.RegisterViewWithRegion("ViewingRegion", typeof (TransparentView));
        }
    }
}