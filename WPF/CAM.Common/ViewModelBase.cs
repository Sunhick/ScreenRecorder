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
using System.ComponentModel;
using System.Diagnostics;

namespace CAM.Common
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected ViewModelBase()
        {
            ThrowOnInvalidPropertyName = true;
        }

        protected bool ThrowOnInvalidPropertyName { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [Conditional("DEBUG"), DebuggerStepThrough]
        public void VerifyPropertyName(string thePropertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[thePropertyName] == null)
            {
                string aMsg = "Invalid property name: " + thePropertyName;

                if (ThrowOnInvalidPropertyName)
                {
                    throw new Exception(aMsg);
                }

                Debug.Fail(aMsg);
            }
        }

        public virtual void OnPropertyChanged(string thePropertyName)
        {
            VerifyPropertyName(thePropertyName);

            PropertyChangedEventHandler aHandler = PropertyChanged;
            if (aHandler != null)
            {
                var aE = new PropertyChangedEventArgs(thePropertyName);
                aHandler(this, aE);
            }
        }
    }
}