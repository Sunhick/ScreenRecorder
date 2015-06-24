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
using System.Collections;
using log4net;
using ScreenRecorder.Properties;

namespace ScreenRecorder
{
    /// <summary>
    ///     Expand the environment varibles in the hooks files.
    /// </summary>
    public class VariablesParser
    {
        private static readonly ILog log = LogManager.GetLogger(typeof (VariablesParser).Name);

        /// <summary>
        ///     application environment variables
        /// </summary>
        private static readonly Hashtable appVariables = new Hashtable()
        {
            {"BITMAPS", Settings.Default.BitmapTempLoc},
            {"FPS", Settings.Default.FramesPerSec}
        };

        /// <summary>
        ///     Push App environment variable
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
        ///     Expand relative path to absolute path
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string ExpandVariables(string content)
        {
            if (string.IsNullOrEmpty(content)) return content;

            log.Info("Before Expand contents: " + content);

            var expandedContent = content;

            foreach (DictionaryEntry anEntry in appVariables)
            {
                var oldString = "$" + ((string) (anEntry.Key)) + "$";
                var newString = (anEntry.Value != null) ? anEntry.Value.ToString() : null;

                // check whether Value is of type string and contains Key
                if (newString != null && newString.IndexOf(oldString, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    var startIndex = 0;
                    while (startIndex < expandedContent.Length)
                    {
                        var beginIndexOfOldString = expandedContent.IndexOf(oldString, startIndex,
                            StringComparison.OrdinalIgnoreCase);
                        if (beginIndexOfOldString >= 0)
                        {
                            var oldStringLength = oldString.Length;
                            var endIndexOfOldString = beginIndexOfOldString + oldStringLength - 1;
                            expandedContent = expandedContent.Substring(0, beginIndexOfOldString) + newString +
                                              expandedContent.Substring(endIndexOfOldString + 1);
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