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
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
#endregion

namespace ScreenRecorder
{
    /// <summary>
    /// Hook Data
    /// </summary>
    public class HookData
    {
        public string HookID;
        public string Mode;
        public string Executable;
        public string Path;
        public string Arguments;
    }

    /// <summary>
    /// Parses all the hook files
    /// </summary>
    public class HookParser
    {
        string hookLocation  = @"Hooks\";

        /// <summary>
        /// ctor
        /// </summary>
        public HookParser()
        {
        }

        /// <summary>
        /// Parse
        /// </summary>
        /// <returns></returns>
        public List<HookData> Parse()
        {
            //get all hook files
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

                    hook.HookID = hookid;
                    hook.Path = path;
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
