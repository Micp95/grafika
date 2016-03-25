using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;



namespace Grafika2
{
    public partial class Forml3 : Form
    {

        
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 0.1f);
        private System.Drawing.Pen pen2 = new System.Drawing.Pen(Color.Red, 0.3f);

        public Forml3()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            

            int x1, x2,x3,x4,y1,y2,y3,y4;
            int.TryParse(textBox1.Text, out x1);
            int.TryParse(textBox2.Text, out y1);

            int.TryParse(textBox3.Text, out x2);
            int.TryParse(textBox4.Text, out y2);

            int.TryParse(textBox5.Text, out x3);
            int.TryParse(textBox6.Text, out y3);

            int.TryParse(textBox7.Text, out x4);
            int.TryParse(textBox8.Text, out y4);


            Point P1 = new Point(x1, y1);
            Point P2 = new Point(x2, y2);

            Point P3 = new Point(x3, y3);
            Point P4 = new Point(x4, y4);
            string msg = "";


            g.DrawLine(pen1, P1, P2);
            g.DrawLine(pen1, P3, P4);


            double delta = (P2.X - P1.X) * (P3.Y - P4.Y) - (P3.X - P4.X) * (P2.Y - P1.Y);


            if (delta == 0)
            {
                msg = "Punkty rownolegle.";
                goto end;
            }

            double deltaMi = (P3.X - P1.X) * (P3.Y - P4.Y) - (P3.X - P4.X) * (P3.Y - P1.Y);

            double Mi = deltaMi / delta;

            int x = (int)((1 - Mi) * P1.X + Mi * P2.X);
            int y = (int)((1 - Mi) * P1.Y + Mi * P2.Y);

            Point PP = new Point(x,y);

            msg = "Punkt przeciecia to: (" + x.ToString() + ", " + y.ToString() + ")";

            g.DrawEllipse(pen2, PP.X - 5, PP.Y - 5, 10, 10);


        end:;

            label1.Text = msg;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //      PointF P1 = new PointF((float)Math.Sqrt(3f/2f), 0.5f);
            //      PointF P2 = new PointF(-0.5f, -(float)Math.Sqrt(3f / 2f));

            /*

            //DUPA
            PointF P1 = new PointF(0, 1);
            PointF P2 = new PointF(-1,1);


            Point PP1 = new Point((int)(P1.X * 100), (int)(P1.Y*100));
            Point PP2 = new Point((int)(P2.X * 100), (int)(P2.Y*100));

            g.DrawLine(pen1, new Point(100,100), new Point(PP1.X + 100, PP1.Y+100));
            g.DrawLine(pen1, new Point(100,100), new Point(PP2.X + 100, PP2.Y + 100));


            string msg = "";


            float tmp = P1.X * P2.X + P1.Y * P2.Y;

            if (tmp < 0)
                tmp = -tmp;

            double alfa = Math.Acos(tmp);

            alfa = alfa /Math.PI * 180;
            */
            pictureBox1.Refresh();

            int x1, x2, x3, x4, y1, y2, y3, y4;
            int.TryParse(textBox1.Text, out x1);
            int.TryParse(textBox2.Text, out y1);

            int.TryParse(textBox3.Text, out x2);
            int.TryParse(textBox4.Text, out y2);

            int.TryParse(textBox5.Text, out x3);
            int.TryParse(textBox6.Text, out y3);

            int.TryParse(textBox7.Text, out x4);
            int.TryParse(textBox8.Text, out y4);


            Point P1 = new Point(x1, y1);
            Point P2 = new Point(x2, y2);

            Point P3 = new Point(x3, y3);
            Point P4 = new Point(x4, y4);

            g.DrawLine(pen1, P1, P2);
            g.DrawLine(pen1, P3, P4);


            string msg = "";


            double a1 = (double)(P1.Y - P2.Y) / (double)(P1.X - P2.X);
            double a2 = (double)(P3.Y - P4.Y) / (double)(P3.X - P4.X);

            double alfa =Math.Atan((a1 - a2) / (1 + a1 * a2));
            alfa = alfa / Math.PI * 180;

            msg = "kat pomiedzy prostymi wynosi " + (int)alfa;
            label1.Text = msg;

        }
        double[] Add(double[] A, double[] B)
        {
            double[] ret = new double[A.Length];
            for (int k = 0; k < A.Length; k++)
                ret[k] = A[k] + B[k];
            return ret;

        }
        double[] Sub(double[] A, double[] B)
        {
            double[] ret = new double[A.Length];
            for (int k = 0; k < A.Length; k++)
                ret[k] = A[k] - B[k];
            return ret;

        }

        double Multip(double[] A, double[] B)
        {
            double ret = 0;

            for (int k = 0; k < A.Length; k++)
                ret += A[k] * B[k];
            return ret;

        }

        double[] MultipWekt(double[] A, double[] B)
        {
            double[] ret = new double[A.Length];

            ret[0] = A[1] * B[2] - B[1] * A[2];
            ret[1] = -1*(A[0] * B[2] - B[0] * A[2]);
            ret[2] = A[0] * B[1] - B[0] * A[1];
     
            return ret;

        }
        double[] Scalar(double[] A, double s)
        {
            double[] ret = new double[A.Length];
            for (int k = 0; k < A.Length; k++)
                ret[k] = A[k] * s;
            return ret;

        }


        private void button3_Click(object sender, EventArgs e)
        {
            double[] b = new double[3];
            double.TryParse(textBox10.Text, out b[0]);
            double.TryParse(textBox9.Text, out b[1]);
            double.TryParse(textBox11.Text, out b[2]);

            double[] P2 = new double[3];
            double.TryParse(textBox14.Text, out P2[0]);
            double.TryParse(textBox13.Text, out P2[1]);
            double.TryParse(textBox12.Text, out P2[2]);


            double[] n = new double[3];
            double r;
            double.TryParse(textBox17.Text, out n[0]);
            double.TryParse(textBox16.Text, out n[1]);
            double.TryParse(textBox15.Text, out n[2]);
            double.TryParse(textBox18.Text, out r);


            double[] d = Sub(P2, b);
            double nb = Multip(n, b);
            double nd = Multip(n, d);


            double[] przeciecie = Add(b, Scalar(d,(r-nb)/ nd));

            string msg = "przeciecie: " + przeciecie[0] + ", " + przeciecie[1] + ", " + przeciecie[2];
            label1.Text = msg;
        }


        private void button4_Click(object sender, EventArgs e)
        {

            double[] P1 = new double[3];
            double.TryParse(textBox10.Text, out P1[0]);
            double.TryParse(textBox9.Text, out P1[1]);
            double.TryParse(textBox11.Text, out P1[2]);

            double[] P2 = new double[3];
            double.TryParse(textBox14.Text, out P2[0]);
            double.TryParse(textBox13.Text, out P2[1]);
            double.TryParse(textBox12.Text, out P2[2]);


            double[] P3 = new double[3];
            double.TryParse(textBox17.Text, out P3[0]);
            double.TryParse(textBox16.Text, out P3[1]);
            double.TryParse(textBox15.Text, out P3[2]);


            double[] left = MultipWekt(Sub(P2, P1), Sub(P3, P1));
            double free = 0;
            for ( int k = 0; k <3; k++)
                free += left[k] * (-P1[k]);


            string result = "";
            string[] signs = new string[] { "x","y","z" };

            for ( int k = 0; k < 3;k++)
                if (left[k] != 0)
                {
                    if (left[k] > 0)
                        result += "+";
                    result += left[k] + signs[k] + " ";
                }


            result += "= ";
            free = -free;
            result += free;
    

            string msg = "rownanie: " + result;
            label1.Text = msg;
        }

    }
}
