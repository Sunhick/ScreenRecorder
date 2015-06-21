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

namespace CAM.Configuration
{
    /// <summary>
    ///     Expand the environment varibles in the hooks files.
    /// </summary>
    internal class VariablesParser
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (VariablesParser).Name);

        /// <summary>
        ///     application environment variables
        /// </summary>
        private static readonly Hashtable AppVariables = new Hashtable();

        /// <summary>
        ///     Push App environment variable
        /// </summary>
        /// <param name="theEnvName"></param>
        /// <param name="theEnvValue"></param>
        public static void PushVariable(string theEnvName, object theEnvValue)
        {
            if (string.IsNullOrEmpty(theEnvName))
                throw new ArgumentNullException("theEnvName", "Environment name cannot be null or empty");

            AppVariables.Remove(theEnvName);
            AppVariables.Add(theEnvName, theEnvValue);
        }


        /// <summary>
        ///     Expand relative path to absolute path
        /// </summary>
        /// <param name="theContent"></param>
        /// <returns></returns>
        public static string ExpandVariables(string theContent)
        {
            if (string.IsNullOrEmpty(theContent)) return theContent;

            Log.Debug("Before Expand contents: " + theContent);

            string aExpandedContent = theContent;

            foreach (DictionaryEntry aEntry in AppVariables)
            {
                string aOldString = "$" + ((string) (aEntry.Key)) + "$";
                string aNewString = (aEntry.Value != null) ? aEntry.Value.ToString() : null;

                // check whether Value is of type string and contains Key
                if (aNewString != null && aNewString.IndexOf(aOldString, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    int aStartIndex = 0;
                    while (aStartIndex < aExpandedContent.Length)
                    {
                        int aBeginIndexOfOldString = aExpandedContent.IndexOf(aOldString, aStartIndex,
                            StringComparison.OrdinalIgnoreCase);
                        if (aBeginIndexOfOldString >= 0)
                        {
                            int aOldStringLength = aOldString.Length;
                            int aEndIndexOfOldString = aBeginIndexOfOldString + aOldStringLength - 1;
                            aExpandedContent = aExpandedContent.Substring(0, aBeginIndexOfOldString) + aNewString +
                                               aExpandedContent.Substring(aEndIndexOfOldString + 1);
                            aStartIndex = aBeginIndexOfOldString + aNewString.Length;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            Log.Debug("After Expand contents: " + aExpandedContent);
            return aExpandedContent;
        }
    }
}