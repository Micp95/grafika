using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika2
{
    public partial class Form4 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Red, 0.1f);
        private System.Drawing.Pen pen2 = new System.Drawing.Pen(Color.Black, 0.1f);
        int w, h;

        double scalx,scaly;
        double alfa;
        double ax, ay;


        public Form4()
        {
            InitializeComponent();

            g = pictureBox1.CreateGraphics();

            w = pictureBox1.Width;
            h = pictureBox1.Height;
            scalx = scaly = 1;
            alfa = 0;
            ax = ay = 0;

            PA = new Point();
            PB = new Point();
        }

        Point translatePoint(Point A)
        {
       //     A.X = -A.X;
            A.Y = -A.Y;

            double tmpx = A.X, tmpy = A.Y;

            tmpx *= scalx;
            tmpy *= scaly;

          //  tmpx = (double)A.X * Math.Cos(alfa) + (double)A.Y * Math.Sin(alfa);
          //  tmpy = (-1)*(double)A.X * Math.Sin(alfa) + (double)A.Y * Math.Cos(alfa);

            tmpx = tmpx * Math.Cos(alfa) + tmpy * Math.Sin(alfa);
            tmpy = (-1) * tmpx * Math.Sin(alfa) + tmpy * Math.Cos(alfa);


            tmpx += (double)w /2 + ax;
            tmpy += (double)h /2 + ay;


            A.X = (int)tmpx;
            A.Y = (int)tmpy;


            return A;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        Point PA, PB;

        private void button2_Click(object sender, EventArgs e)
        {
            readPointsPos();

            double sx,sy;
            double.TryParse(textBox3.Text.Replace("*,*", "*."), out sx);
            double.TryParse(textBox9.Text.Replace("*,*", "*."), out sy);
            scalx = sx;
            scaly = sy;
           

            drawContract();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            readPointsPos();

            double omega;
            double.TryParse(textBox4.Text.Replace("*,*", "*."), out omega);
            omega = omega  * Math.PI/180;
            omega = -omega;

            alfa = omega;

            drawContract();

        }

        void drawContract()
        {
            pictureBox1.Refresh();
            Point A = translatePoint(PA);
            Point B = translatePoint(PB);


            g.DrawLine(pen1, A, B);

            double scx = 1 / scalx;
            if (scx < 1)
                scx = 1;
            double scy = 1 / scaly;
            if (scy < 1)
                scy = 1;

            g.DrawLine(pen2, translatePoint( new Point(0,h* (int)scy)), translatePoint(new Point(0, -h * (int)scy)));
            g.DrawLine(pen2, translatePoint(new Point(-w * (int)scx, 0)), translatePoint(new Point(w * (int)(scx), 0)));

        }

        void readPointsPos()
        {
            int x, y;
            int.TryParse(textBox6.Text, out x);
            int.TryParse(textBox5.Text, out y);
            PA = new Point(x, y);

            int.TryParse(textBox7.Text, out x);
            int.TryParse(textBox8.Text, out y);
            PB = new Point(x, y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            readPointsPos();

            int x, y;
            int.TryParse(textBox1.Text, out x);
            int.TryParse(textBox2.Text, out y);

            ax = (double)x;
            ay = (double)y;
            ay = -ay;

            drawContract();
        }
    }
}
