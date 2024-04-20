using System;
using System.Windows.Forms;


namespace SapperLogic
{
    /// <summary>
    /// abstract sapper cell class
    /// </summary>
    public abstract class Cell
    {
        public Coordinates Coordinates { get; set; }
        public bool IsOpened { get; set; }
        public bool IsMark { get; set; }
        public MyButton CellButton { get; set; }

        protected Cell(Coordinates coordinates, MyButton button)
        {
            Coordinates = coordinates;
            CellButton = button;
            IsOpened = false;
            IsMark = false;
        }
        protected Cell(int x, int y, MyButton button)
        {
            CellButton = button;
            Coordinates = new Coordinates(x,y);
            IsOpened = false;
            IsMark = false;
        }
        public abstract void Mark();
        public abstract void Open();
    }
}
