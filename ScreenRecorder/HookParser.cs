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
        public HookData Parse()
        {
            //get all hook files
            string[] files = Directory.GetFiles(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, hookLocation), "*.hook"
                );

            HookData data = new HookData();

            foreach (string hookFile in files)
            {
                XDocument doc = XDocument.Load(hookFile);
                var query = from d in doc.Root.Descendants("Command") select d;

                foreach (var q in query)
                {
                    string exe = q.Element("Executable").Value;
                    string path = q.Element("Path").Value;
                    string arg = q.Element("Arguments").Value;
                    string hookid = q.FirstAttribute.Value;
                    string mode = q.LastAttribute.Value;

                    data.HookID = hookid;
                    data.Path = path;
                    data.Executable = exe;
                    data.Arguments = arg;
                    data.Mode = mode;
                }
            }

            return data;
        }
    }
}
