using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SapperLogic;

namespace Sapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Field gameField;
        List<MyButton> buts;
        int ct = 0;
        public int width;
        public int height;
        public int bombAmount;
        private void Form1_Load(object sender, EventArgs e)
        {
            int bombCount = 0;
            width = 25; 
            height = 25;
            bombAmount = 210;
            Random rnd = new Random();
            buts = new List<MyButton>();
            for (int x = 25; this.Width - x > 50; x += 25)
            {
                for (int y = 50; this.Height - 25-y > 50; y += 25)
                {
                    MyButton button;
                    if (rnd.Next(0, 100) <= 34 && bombCount < bombAmount)
                    {
                        button = new MyButton(true);
                        bombCount++;
                    }
                    else
                    {
                        button = new MyButton(false);
                        ct++;
                    }
                    button.MouseDown += Button_MouseDown;
                    button.Location = new Point(x, y);
                    button.Size = new Size(25, 25);
                    Controls.Add(button);
                    buts.Add(button);
                }
            }
            gameField = new Field(25, 25, 50, buts);
            bombsleft.Text = width * height - bombCount + " SQUARES LEFT";
            ct = width * height - bombCount;
            for (int x = 0; x < gameField.Width; x++)
            {
                for (int y = 0; y < gameField.Height; y++)
                {
                    gameField[x, y].CellButton.BackgroundImage = Sapper.Properties.Resources.empty;
                    gameField[x, y].IsMark = false;
                    gameField[x, y].IsOpened = false;
                }
            }


        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            int yc = 0, xc = 0;
            MouseEventArgs me = e;
            MyButton but = (MyButton)sender;
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (but.IsBomb)
                {
                    but.BackgroundImage = Sapper.Properties.Resources.bomb;
                    for (int i = 0; i < gameField.Butts.Count; i++)
                    {
                        if (buts[i].IsBomb)
                        {
                            buts[i].BackgroundImage = Sapper.Properties.Resources.bomb;
                        }
                    }
                    MessageBox.Show("You lost!", "The end!");
                    this.Close();
                }
                else
                {
                    for (int i = 0; i < gameField.Butts.Count; i++)
                    {
                        if (gameField.Butts[i] == but)
                        {
                            yc = i % gameField.Width;
                            xc = i / gameField.Width;
                            int cnt = 0;
                            if (gameField[xc, yc] is Empty)
                            {
                                if (gameField[xc, yc + 1] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc + 1, yc + 1] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc + 1, yc] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc + 1, yc - 1] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc, yc - 1] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc - 1, yc - 1] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc - 1, yc] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc - 1, yc + 1] is Bomb)
                                {
                                    cnt++;
                                }
                            }
                            if (cnt != 0) but.Text = cnt.ToString();
                            else but.Text = " ";
                            but.BackgroundImage = Sapper.Properties.Resources.emptyopened;
                            gameField[xc, yc].IsOpened = true;
                            but.Enabled = false;
                            ct--;
                            if (ct == 0)
                            {
                                for (int j = 0; j < gameField.Butts.Count; j++)
                                {
                                    if (buts[j].IsBomb)
                                    {
                                        buts[j].BackgroundImage = Sapper.Properties.Resources.bomb;
                                    }
                                }
                                MessageBox.Show("You won!", "Congratulations!");
                                restart();
                            }
                            bombsleft.Text = ct + " SQUARES LEFT";
                        }
                    }
                }
            }

            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                for (int i = 0; i < gameField.Butts.Count; i++)
                {
                    if (gameField.Butts[i] == but)
                    {
                        yc = i % gameField.Width;
                        xc = i / gameField.Width;
                        if (gameField[xc, yc].IsMark == false && gameField[xc, yc].IsOpened == false)
                        {
                            gameField[xc, yc].IsMark = true;
                            gameField[xc, yc].CellButton.BackgroundImage = Sapper.Properties.Resources.mark;
                        }
                        else if (gameField[xc, yc].IsMark == true && gameField[xc, yc].IsOpened == false)
                        {
                            gameField[xc, yc].IsMark = false;
                            gameField[xc, yc].CellButton.BackgroundImage = Sapper.Properties.Resources.empty;
                        }
                    }
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int bombCount = 0;
            Form2 form2 = new Form2();
            form2.isChanged = false;
            form2.ShowDialog();
            if (form2.isChanged == false)
            {
                return;
            }
            Controls.Clear();
            Random rnd = new Random();
            buts = new List<MyButton>();
            Controls.Add(bombsleft);
            Controls.Add(menuStrip1);
            Width = form2.width * 25 + 75;
            Height = form2.height * 25 + 125;
            width = form2.width;
            height = form2.height;
            bombAmount = form2.mines;
           
            ct = 0;
            for (int x = 25; this.Width - x > 50; x += 25)
            {
                for (int y = 50; this.Height - 25 - y > 50; y += 25)
                {
                    MyButton button;
                    if (rnd.Next(0, 100) <= Convert.ToInt32(Convert.ToDouble(form2.mines) / (Convert.ToDouble(form2.width) * Convert.ToDouble(form2.height)) * 100) + 20 && bombCount < bombAmount)
                    {
                        button = new MyButton(true);
                        bombCount++;
                    }
                    else
                    {
                        button = new MyButton(false);
                        ct++;
                    }
                    button.MouseDown += Button_MouseDown;
                    button.Location = new Point(x, y);
                    button.Size = new Size(25, 25);
                    Controls.Add(button);
                    buts.Add(button);
                }
            }
            gameField = new Field(form2.height, form2.width, form2.mines, buts);
            bombsleft.Text = width * height - bombCount + " SQUARES LEFT";
            ct = width * height - bombCount;
            for (int x = 0; x < gameField.Width; x++)
            {
                for (int y = 0; y < gameField.Height; y++)
                {
                    gameField[x, y].CellButton.BackgroundImage = Sapper.Properties.Resources.empty;
                    gameField[x, y].IsMark = false;
                    gameField[x, y].IsOpened = false;
                }
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restart();
        }
        private void restart()
        {
            int bombCount = 0;
            Controls.Clear();
            Random rnd = new Random();
            buts = new List<MyButton>();
            Width = width * 25 + 75;
            Height = height * 25 + 125;
            Controls.Add(bombsleft);
            Controls.Add(menuStrip1);
            ct = 0;
            for (int x = 25; this.Width - x > 50; x += 25)
            {
                for (int y = 50; this.Height - 25 - y > 50; y += 25)
                {
                    MyButton button;
                    if (rnd.Next(0, 100) <= Convert.ToInt32(Convert.ToDouble(bombAmount) / (Convert.ToDouble(width) * Convert.ToDouble(height)) * 100) + 20 && bombCount < bombAmount)
                    {
                        button = new MyButton(true);
                        bombCount++;
                    }
                    else
                    {
                        button = new MyButton(false);
                        ct++;
                    }
                    button.MouseDown += Button_MouseDown;
                    button.Location = new Point(x, y);
                    button.Size = new Size(25, 25);
                    Controls.Add(button);
                    buts.Add(button);
                }
            }
            gameField = new Field(height, width, bombAmount, buts);
            bombsleft.Text = width * height - bombCount + " SQUARES LEFT";
            ct = width * height - bombCount;
            for (int x = 0; x < gameField.Width; x++)
            {
                for (int y = 0; y < gameField.Height; y++)
                {
                    gameField[x, y].CellButton.BackgroundImage = Sapper.Properties.Resources.empty;
                    gameField[x, y].IsMark = false;
                    gameField[x, y].IsOpened = false;
                }
            }
        }
    }
  
}