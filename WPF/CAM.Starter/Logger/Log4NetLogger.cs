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

using log4net;
using Microsoft.Practices.Prism.Logging;

namespace CAM.Starter.Logger
{
    internal class Log4NetLogger : ILoggerFacade
    {
        private readonly ILog Logger = LogManager.GetLogger(typeof (Log4NetLogger));

        public void Log(string theMessage, Category theCategory, Priority thePriority)
        {
            switch (theCategory)
            {
                case Category.Debug:
                    Logger.Debug(theMessage);
                    break;
                case Category.Warn:
                    Logger.Warn(theMessage);
                    break;
                case Category.Exception:
                    Logger.Error(theMessage);
                    break;
                case Category.Info:
                    Logger.Info(theMessage);
                    break;
            }
        }
    }
}