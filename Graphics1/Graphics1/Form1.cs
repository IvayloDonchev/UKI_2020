using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            int side = 200, x1 = 100, y1 = 300, x2, y2, x3, y3;
            x2 = x1 + side; y2 = y1; x3 = (x1 + x2) / 2;
            int h = (int)(side * Math.Sqrt(3) / 2);
            y3 = y1 - h;
            for (int i = 1; i <= 100; i+=5)
            {
                g.DrawLine(p, x1+i, y1+i, x2+i, y2+i);
                g.DrawLine(p, x2+i, y2+i, x3+i, y3+i);
                g.DrawLine(p, x3+i, y3+i, x1+i, y1+i);
            }
            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
