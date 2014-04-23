
using System;
using ScreenRecorder.Properties;
using System.Collections;
using log4net;

namespace ScreenRecorder
{
    /// <summary>
    /// Expand the environment varibles in the hooks files.
    /// </summary>
    public class VariablesParser
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(VariablesParser).Name);

        /// <summary>
        /// application environment variables
        /// </summary>
        private static Hashtable appVariables = new Hashtable()
        {
            {"BITMAPS", Settings.Default.BitmapTempLoc},
            {"FPS", Settings.Default.FramesPerSec}
        };

        /// <summary>
        /// Push App environment variable
        /// </summary>
        /// <param name="envName"></param>
        /// <param name="envValue"></param>
        public static void PushVariable(string envName, object envValue)
        {
            if (string.IsNullOrEmpty(envName)) 
                throw new ArgumentNullException("envName", "Environment name cannot be null or empty");

            appVariables.Remove(envName);
            appVariables.Add(envName, envValue);
        }


        /// <summary>
        /// Expand relative path to absolute path
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string ExpandVariables(string content)
        {
            if (string.IsNullOrEmpty(content)) return content;

            log.Info("Before Expand contents: " + content);

            string expandedContent = content;

            foreach (DictionaryEntry anEntry in appVariables)
            {
                string oldString = "$" + ((string)(anEntry.Key)) + "$";
                string newString = (anEntry.Value != null) ? anEntry.Value.ToString() : null;

                // check whether Value is of type string and contains Key
                if (newString != null && newString.IndexOf(oldString, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    int startIndex = 0;
                    while (startIndex < expandedContent.Length)
                    {
                        int beginIndexOfOldString = expandedContent.IndexOf(oldString, startIndex, StringComparison.OrdinalIgnoreCase);
                        if (beginIndexOfOldString >= 0)
                        {
                            int oldStringLength = oldString.Length;
                            int endIndexOfOldString = beginIndexOfOldString + oldStringLength - 1;
                            expandedContent = expandedContent.Substring(0, beginIndexOfOldString) + newString + expandedContent.Substring(endIndexOfOldString + 1);
                            startIndex = beginIndexOfOldString + newString.Length;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            log.Info("After Expand contents: " + expandedContent);
            return expandedContent;
        }
    }
}
