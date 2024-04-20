using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace SapperLogic
{
    public class MyButton : Button
    {
        public bool IsBomb { get; set; }
        public MyButton(bool isBomb)
        {
            IsBomb = isBomb;
        }
    }
}
