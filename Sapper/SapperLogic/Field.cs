using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SapperLogic
{
    public class Field
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int BombQuantity { get; set; }
        public List<Cell> Cells { get; } = new List<Cell>();
        public List<MyButton> Butts { get; set; }
        public Field(int height, int width, int bombQuantity, List<MyButton> buts)
        {
            Butts = buts;
            Height = height;
            Width = width;
            BombQuantity = bombQuantity;
            int cnt = 0;
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    if (buts[cnt].IsBomb)
                        Cells.Add(new Bomb(i, j, buts[cnt]));
                    else
                        Cells.Add(new Empty(i, j, buts[cnt]));
                    cnt++;
                }
            }
           
           
        }
        public Cell this[int x, int y]
        {
            get
            {
                return Cells.SingleOrDefault(cell => cell.Coordinates.X == x && cell.Coordinates.Y == y);
            }

            set
            {
                var oldCell = this[value.Coordinates.X, value.Coordinates.Y];
                if (oldCell != null)
                {
                    Cells.Remove(oldCell);
                }
                Cells.Add(value);
            }
        }
    }
    
   
}
