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
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace CAM.Tools.Helper
{
    /// <summary>
    ///     Visual wrapper
    /// </summary>
    [ContentProperty("Child")]
    public class VisualWrapper : FrameworkElement
    {
        private Visual myChild;

        public Visual Child
        {
            get { return myChild; }

            set
            {
                if (myChild != null)
                {
                    RemoveVisualChild(myChild);
                }

                myChild = value;

                if (myChild != null)
                {
                    AddVisualChild(myChild);
                }
            }
        }

        protected override int VisualChildrenCount
        {
            get { return myChild != null ? 1 : 0; }
        }

        protected override Visual GetVisualChild(int theIndex)
        {
            if (myChild != null && theIndex == 0)
            {
                return myChild;
            }
            else
            {
                throw new ArgumentOutOfRangeException("theIndex");
            }
        }
    }
}