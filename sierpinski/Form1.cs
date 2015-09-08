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

namespace sierpinski
{
    public partial class Form1 : Form
    {
        int width = 0;
        int height = 0;
        private System.Drawing.Graphics g;
        public Form1()
        {
            InitializeComponent();
            width = panel1.Size.Width;
            height = panel1.Size.Height;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            g.Clear(Color.White);
            int niveau = Convert.ToInt32(this.numericUpDown1.Value);
            RectangleF rect = new RectangleF(0,0,width,height);
            label3.Text = ""+Math.Pow(8, niveau);
            DrawRectangle(g, niveau, rect);
        }

        // Draw a carpet in the rectangle.
        private void DrawRectangle(Graphics gr, int niveau, RectangleF rect)
        {
            if (niveau == 0)
            {
                gr.FillRectangle(Brushes.Black, rect);
            }
            else
            {
                float wid = rect.Width / 3f;
                float x0 = rect.Left;
                float x1 = x0 + wid;
                float x2 = x0 + wid * 2f;

                float hgt = rect.Height / 3f;
                float y0 = rect.Top;
                float y1 = y0 + hgt;
                float y2 = y0 + hgt * 2f;

                DrawRectangle(gr, niveau - 1, new RectangleF(x0, y0, wid, hgt));
                DrawRectangle(gr, niveau - 1, new RectangleF(x1, y0, wid, hgt));
                DrawRectangle(gr, niveau - 1, new RectangleF(x2, y0, wid, hgt));
                DrawRectangle(gr, niveau - 1, new RectangleF(x0, y1, wid, hgt));
                DrawRectangle(gr, niveau - 1, new RectangleF(x2, y1, wid, hgt));
                DrawRectangle(gr, niveau - 1, new RectangleF(x0, y2, wid, hgt));
                DrawRectangle(gr, niveau - 1, new RectangleF(x1, y2, wid, hgt));
                DrawRectangle(gr, niveau - 1, new RectangleF(x2, y2, wid, hgt));
            }
        }


    }
}
