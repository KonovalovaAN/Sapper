using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SapperLogic
{
    /// <summary>
    /// Bomb
    /// </summary>
    public class Bomb : Cell
    {
        public Bomb(Coordinates coordinates, MyButton button) : base(coordinates, button)
        {
            IsOpened = false;
            IsMark = false;
        }
        public Bomb(int x, int y, MyButton button) : base(x,y, button)
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
        }
    }
}
