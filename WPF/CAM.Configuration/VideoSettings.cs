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
using System.Configuration;
using System.IO;

namespace CAM.Configuration
{
    public class VideoSettings : ApplicationSettingsBase
    {
        public VideoSettings()
        {
            var aTempDir = Path.Combine(Path.GetTempPath(), "Bitmaps");
            if (string.IsNullOrEmpty(BitmapLocation)) BitmapLocation = aTempDir;
            if (string.IsNullOrEmpty(OutputLocation)) OutputLocation = aTempDir;
        }

        [UserScopedSetting]
        [DefaultSettingValue("20")]
        // ReSharper disable once InconsistentNaming
        public int FPS
        {
            get { return (int) this["FPS"]; }
            set { this["FPS"] = value; }
        }

        [UserScopedSetting]
        public String BitmapLocation
        {
            get { return (String) this["BitmapLocation"]; }
            set { this["BitmapLocation"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("en-US")]
        public String Language
        {
            get { return (String) this["Language"]; }
            set { this["Language"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("MKV")]
        public String PreferedVideoType
        {
            get { return (String) this["PreferedVideoType"]; }
            set { this["PreferedVideoType"] = value; }
        }

        [UserScopedSetting]
        public String OutputLocation
        {
            get { return (String) this["OutputLocation"]; }
            set { this["OutputLocation"] = value; }
        }
    }
}