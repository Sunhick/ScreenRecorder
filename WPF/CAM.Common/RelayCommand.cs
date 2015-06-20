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
using System.Diagnostics;
using System.Windows.Input;

namespace CAM.Common
{
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> myCanExecute;

        private readonly Action<object> myExecute;

        public RelayCommand(Action<object> theExecute)
            : this(null, theExecute)
        {
        }

        public RelayCommand(Predicate<object> theCanExecute, Action<object> theExecute)
        {
            if (theExecute == null)
            {
                throw new ArgumentNullException("theExecute");
            }

            myExecute = theExecute;
            myCanExecute = theCanExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }

            remove { CommandManager.RequerySuggested -= value; }
        }

        [DebuggerStepThrough]
        public bool CanExecute(object theParameter)
        {
            return myCanExecute == null || myCanExecute(theParameter);
        }

        public void Execute(object theParameter)
        {
            myExecute(theParameter);
        }

        public static RelayCommand RegisterCommand(Predicate<object> theCanExecute, Action<object> theExecute)
        {
            return new RelayCommand(theCanExecute, theExecute);
        }
    }
}