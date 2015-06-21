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
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using CAM.Common;
using log4net;

namespace CAM.Configuration
{
    internal class Configuration : IConfiguration
    {
        private const string HookFile = "Hooks.config";
        private readonly ILog Log = LogManager.GetLogger(typeof (Configuration));
        private readonly IList<HookInfo> myConfiguredHooks = new List<HookInfo>();

        public Configuration()
        {
            var aFileMap = new ExeConfigurationFileMap {ExeConfigFilename = HookFile};

            if (!File.Exists(aFileMap.ExeConfigFilename))
            {
                throw new Exception("Configuration file could not be found :" + aFileMap.ExeConfigFilename);
            }

            // Load configuration
            var aOpenMappedExeConfiguration = ConfigurationManager.OpenMappedExeConfiguration(aFileMap,
                ConfigurationUserLevel.None);
            var aConfigurationSection = aOpenMappedExeConfiguration.GetSection("hook");
            var aHook = aConfigurationSection as Hook;
            if (aHook == null)
            {
                Log.Error("No Hooks configured! No command targed for FFMPEG. CAM Recorder may not work!");
                return;
            }

            var aEnumerator = aHook.Commands.GetEnumerator();
            do
            {
                var aCurrent = aEnumerator.Current as Command;
                if (aCurrent == null) continue;
                myConfiguredHooks.Add(new HookInfo()
                {
                    HookId = aCurrent.HookId,
                    Mode = aCurrent.Mode,
                    ExeName = aCurrent.Executable.Name,
                    ExePath = aCurrent.Executable.ExeLocation,
                    Arguments = aCurrent.Arguments.CommandLine
                });
            } while (aEnumerator.MoveNext());
        }

        public HookInfo GetHook(String theHookId)
        {
            if (myConfiguredHooks.Count == 0)
            {
                Log.Info("No Hooks available!");
                return null;
            }

            foreach (
                var aConfiguredHook in
                    myConfiguredHooks.Where(theConfiguredHook => theConfiguredHook.HookId == theHookId))
            {
                return aConfiguredHook;
            }

            Log.Info("No hook configured with hook Id:" + theHookId);
            return null;
        }
    }
}