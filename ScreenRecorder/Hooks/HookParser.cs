#region File Header
/*[ Compilation unit ----------------------------------------------------------
 
   Component       : ScreenRecorderMP
 
   Name            : Settings.cs
 
  Author           : Sunil
 
-----------------------------------------------------------------------------*/
/*] END */
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;
#endregion

namespace ScreenRecorder.Hooks
{

    /// <summary>
    /// Parses all the hook files
    /// </summary>
    public class HookParser
    {
        const string hookLocation = @"Hooks\";

        /// <summary>
        /// Parse
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
