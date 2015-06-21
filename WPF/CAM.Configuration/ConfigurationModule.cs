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
using log4net;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace CAM.Configuration
{
    internal class ConfigurationModule : IModule
    {
        private readonly ILog Log = LogManager.GetLogger(typeof (ConfigurationModule));
        private readonly IUnityContainer myContainer;

        public ConfigurationModule(IUnityContainer theContainer)
        {
            myContainer = theContainer;
        }

        public void Initialize()
        {
            Log.Info("Initialize Configuration Module");
            IConfiguration aConfig = new Configuration();
            myContainer.RegisterInstance<IConfiguration>(aConfig, new ContainerControlledLifetimeManager());
        }
    }
}