using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Sapper
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int height;
        public int width;
        public int mines;
        public bool isChanged = false;
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label4.Text = trackBar1.Value.ToString();
            int tmpmax = trackBar3.Maximum;
            int tmpmin = trackBar3.Minimum;
            trackBar3.Minimum = Convert.ToInt16(trackBar1.Value * trackBar2.Value / 10);
            trackBar3.Maximum = Convert.ToInt16(trackBar1.Value * trackBar2.Value / 4);
            if (trackBar3.Maximum != tmpmax || trackBar3.Minimum != tmpmin)
            {
                label6.Text = trackBar3.Value.ToString();
            }
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            label5.Text = trackBar2.Value.ToString();
            int tmpmax = trackBar3.Maximum;
            int tmpmin = trackBar3.Minimum;
            trackBar3.Minimum = Convert.ToInt16(trackBar1.Value * trackBar2.Value / 10);
            trackBar3.Maximum = Convert.ToInt16(trackBar1.Value * trackBar2.Value / 4);
            if (trackBar3.Maximum != tmpmax || trackBar3.Minimum != tmpmin)
            {
                label6.Text = trackBar3.Value.ToString();
            }
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            label6.Text = trackBar3.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            height = trackBar1.Value;
            width = trackBar2.Value;
            mines = trackBar3.Value;
            isChanged = true;
            this.Hide();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
