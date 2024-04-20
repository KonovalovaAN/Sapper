using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SapperLogic
{
    /// <summary>
    /// Empty cell 
    /// </summary>
    public class Empty : Cell
    {
        public Empty(Coordinates coordinates, MyButton button) : base(coordinates, button)
        {
            IsOpened = false;
            IsMark = false;
        }
        public Empty(int x, int y, MyButton button) : base(x, y, button)
        {
            IsOpened = false;
            IsMark = false;
        }
        public override void Mark()
        {
            IsMark = !IsMark;
        }
        public override void Open()
        {
            if (!IsOpened)
            {
                IsOpened = true;
            }
        }
    }
}
