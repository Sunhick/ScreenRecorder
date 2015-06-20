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
using CAM.Common;
using Microsoft.Practices.Prism.PubSubEvents;

namespace CAM.Starter.ViewModel
{
    // ReSharper disable once InconsistentNaming
    public class UIContainerViewModel : ViewModelBase
    {
        private string myActionAlertColor;

        public UIContainerViewModel(IEventAggregator theEventAggregator)
        {
            ActionAlertColor = ColorPalatte.BlueGrey;
            EventAggregator = theEventAggregator;
            EventAggregator.GetEvent<AppExitEvent>().Subscribe(CloseApplication);
        }

        public String ActionAlertColor
        {
            get { return myActionAlertColor; }
            set
            {
                myActionAlertColor = value;
                OnPropertyChanged("ActionAlertColor");
            }
        }

        public IEventAggregator EventAggregator { get; set; }

        private void CloseApplication(AppExitType theExitType)
        {
            switch (theExitType)
            {
                case AppExitType.Normal:
                    break;

                case AppExitType.Forced:
                    break;

                case AppExitType.Error:
                    break;
            }

            Environment.Exit(0);
        }
    }
}