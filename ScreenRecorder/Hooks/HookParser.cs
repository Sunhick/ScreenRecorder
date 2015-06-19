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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

#endregion

namespace ScreenRecorder.Hooks
{
    /// <summary>
    ///     Parses all the hook files
    /// </summary>
    public class HookParser
    {
        private const string hookLocation = @"Hooks\";

        /// <summary>
        ///     Parse
        /// </summary>
        /// <returns></returns>
        public List<HookData> Parse()
        {
            //get all hook files with extension *.hook
            string[] files = Directory.GetFiles(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, hookLocation), "*.hook"
                );

            List<HookData> data = new List<HookData>();

            foreach (string hookFile in files)
            {
                XDocument doc = XDocument.Load(hookFile);
                var query = from d in doc.Root.Descendants("Command") select d;

                foreach (var q in query)
                {
                    HookData hook = new HookData();

                    string exe = q.Element("Executable").Value;
                    string path = q.Element("Path").Value;
                    string arg = q.Element("Arguments").Value;
                    string hookid = q.FirstAttribute.Value;
                    string mode = q.LastAttribute.Value;

                    hook.HookId = hookid;
                    hook.WorkingDir = path;
                    hook.Executable = exe;
                    hook.Arguments = arg;
                    hook.Mode = mode;

                    data.Add(hook);
                }
            }

            return data;
        }
    }
}