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
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Red, 0.1f);
        private System.Drawing.Pen penclear = new System.Drawing.Pen(Color.White, 0.1f);
        private System.Drawing.Pen pen2 = new System.Drawing.Pen(Color.Black, 2f);

        Bitmap bm;
        Graphics gr;

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            ActualPosition = new Point(100, 0);
            w = pictureBox1.Width;
            h = pictureBox1.Height;


            bm = new Bitmap(w, h);
            gr = Graphics.FromImage(bm);
   
     
            //pictureBox1.Image = bm;


            g.DrawRectangle(pen2, 0, 0, w, h);

           
        }
        int w, h;

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.DrawLine(pen1, 0, 0, 100, 100);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Point[] tab = new Point[3];
            tab[0].X = 0;
            tab[0].Y = 0;

            tab[1].X = 50;
            tab[1].Y = 100;

            tab[2].X = 100;
            tab[2].Y = 100;
            g.DrawCurve(pen1, tab);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.DrawBezier(pen1, new Point(0, 0), new Point(10, 100), new Point(100, 10), new Point(100, 100));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Point[] tab = new Point[3];
            tab[0].X = 0;
            tab[0].Y = 0;

            tab[1].X = 0;
            tab[1].Y = 100;

            tab[2].X = 100;
            tab[2].Y = 100;

            g.DrawPolygon(pen1,tab);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            g.DrawPie(pen1, new Rectangle(new Point(0,0),new Size(100,100)), 50, 40);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            g.DrawEllipse(pen1, new Rectangle(new Point(0, 0), new Size(100, 100)));
        }

        bool timerrun = false;
        private void button7_Click(object sender, EventArgs e)
        {
            if (timerrun){
                timerrun = false;
                timer1.Enabled = false;
            }
            else{
                timer1.Enabled = true;
                timerrun = true;
            }
        }

        Point ActualPosition;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // g.DrawEllipse(penclear, new Rectangle(ActualPosition, new Size(10, 10)));
            // pictureBox1.Refresh();
            bm = new Bitmap(w, h);
            gr = Graphics.FromImage(bm);
            NewPosiyion();
            gr.DrawEllipse(pen1, new Rectangle(ActualPosition, new Size(10, 10)));
            pictureBox1.Image = bm;

           
        }

        void NewPosiyion()
        {
            if (ActualPosition.X + 10 > w)
            {
                mx = -1;
            }
            else if (ActualPosition.X < 0)
            {
                mx = 1;
            }

            if (ActualPosition.Y + 10 > h)
            {
                my = -1;
            }
            else if (ActualPosition.Y < 0)
            {
                my = 1;
            }

            ActualPosition.X += mx * speed;
            ActualPosition.Y += my * speed;



        }

        int mx = 1;
        int my = 1;
        int speed = 1;

        private void button8_Click(object sender, EventArgs e)
        {
            double liczba1, liczba2;
            double.TryParse(textBox1.Text.Replace("*,*", "*."), out liczba1);
            double.TryParse(textBox2.Text.Replace("*,*", "*."), out liczba2);

            pictureBox1.Refresh();
            DrawElipse((int)liczba1, (int)liczba2);
        }

        void DrawElipse ( int R, int Il)
        {
            int px = pictureBox1.Width / 2;
            int py = pictureBox1.Height / 2;
            int r = R;
            int il = Il;

            Point pStart = new Point(px + r, py);
            Point pEnd = new Point();

            double theta = 0;
            double delta = 2 * Math.PI / il;

            double newx, newy;

            for (int i = 0; i < il; i++)
            {
                theta += delta;
                newx = r * Math.Cos(theta);
                newy = r * Math.Sin(theta);
                pEnd = new Point((int)(newx + px), (int)(newy + py));
                g.DrawLine(pen1, pStart, pEnd);
                pStart = pEnd;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double liczba1, liczba2;
            double.TryParse(textBox1.Text.Replace("*,*", "*."), out liczba1);
            double.TryParse(textBox2.Text.Replace("*,*", "*."), out liczba2);


            pictureBox1.Refresh();
            int px = pictureBox1.Width / 2;
            int py = pictureBox1.Height / 2;
            int r = (int)liczba1;
            int il = (int)liczba2;

            Point pStart = new Point(px + r, py);
            Point pEnd = new Point();

            double theta = 0;
            double delta = 2 * Math.PI / il;
            delta = 360 / il;

            double newx, newy;

            for (int i = 0; i <= il; i++)
            {
                theta += delta;
                newx = r * Math.Cos(theta);
                newy = r * Math.Sin(theta);
                pEnd = new Point((int)(newx + px), (int)(newy + py));
                g.DrawLine(pen1, pStart, pEnd);
                pStart = pEnd;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            double liczba1, liczba2;
            double.TryParse(textBox1.Text.Replace("*,*", "*."), out liczba1);
            double.TryParse(textBox2.Text.Replace("*,*", "*."), out liczba2);




            pictureBox1.Refresh();
            int x = (int)liczba2, y = (int)liczba2;
            Size ActSize = new Size(x, y);

            int px = pictureBox1.Width / 2 - x/2;
            int py = pictureBox1.Height / 2 - y/2;

            Point center = new Point(0, 0);

            int wsp = 15;
            int wsporg = 0;

            int pp = 0;

            for (int k = 0; k < (int)liczba1; k++){
     
                center = new Point(px+pp + wsporg,py+ pp);
                ActSize = new Size(x, y);

                g.DrawEllipse(pen1, new Rectangle(center, ActSize));

                center = new Point(px+pp, py+pp+ wsporg );
                ActSize = new Size(y, x);

                g.DrawEllipse(pen1, new Rectangle(center, ActSize));


                if (k == 0){
                    wsporg = wsp;
                    wsp *= 2;
                    x -= wsp;
                }
                else{
                    pp += wsporg;

                    x -= wsp;
                    y -= wsp;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            DrawSpiral(6, 50, 0);


        }

        void DrawSpiral (int N_, int R_,double ANG_)
        {

            int px = pictureBox1.Width / 2;
            int py = pictureBox1.Height / 2;
            int il = 100;

            int N = N_;
            int R = R_;
            double theta = ANG_;
            double delta = 2 * Math.PI / il;

            Point pStart = new Point(px, py);
            Point pEnd;
            int NN = N * il;

            float deltaRad = R / (float)NN;
            float RR;

            double newx, newy;

            for (int i = 0; i < NN; i++)
            {
                theta += delta;
                RR = deltaRad * (float)i;

                newx = RR * Math.Cos(theta);
                newy = RR * Math.Sin(theta);

                pEnd = new Point((int)(newx + px), (int)(newy + py));
                g.DrawLine(pen1, pStart, pEnd);
                pStart = pEnd;
            }


        }

        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            int starts = 4;

            double actStart = 2*Math.PI / (starts);

            for ( int k = 0; k < starts; k++)
                DrawSpiral(2, 100, actStart*k);

            DrawElipse(100, 100);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            int px = pictureBox1.Width / 2;
            int py = pictureBox1.Height / 2;

            int N = 20;
            double R = 100;

            double theta = 0;
            double delta = 2 * Math.PI / N;

            double[] X = new double[N];
            double[] Y = new double[N];


            for ( int i = 0; i < N; i++)
            {
                theta += delta;
                X[i] = R * Math.Cos(theta);
                Y[i] = R * Math.Sin(theta);
            }

            Point pStart = new Point(px, py);
            Point pEnd = new Point();

            int NM1 = N - 1, IP1;
            for ( int i = 0; i < NM1; i++)
            {
                IP1 = i + 1;
                for ( int j = IP1; j < N; j++)
                {
                    pEnd = new Point((int)X[i] + px, (int)Y[i] + py);
                    g.DrawLine(pen1, pStart, pEnd);
                    pStart = pEnd;

                    pEnd = new Point((int)X[j] + px, (int)Y[j] + py);
                    g.DrawLine(pen1, pStart, pEnd);
                    pStart = pEnd;

                }
            }



        }
        private int fib(int n)
        {
            if ((n == 1) || (n == 2))
                return 1;
            else
                return fib(n - 1) + fib(n - 2);
        }
        bool fibwar (int num)
        {
            int c;
            for ( int k = 1; (c = fib(k)) <= num; k++)
            {
                if (c == num)
                    return true;
            }
            return false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            int R = 200;
            int N = 25;
            int NN = N * 4;

            int px = pictureBox1.Width / 2 - R/2;
            int py = pictureBox1.Height / 2- R/2;

            double[] Px = new double[NN];
            double[] Py = new double[NN];

            double delta = (double)R / (double)N;
            double acum1, acum2, acum3, acum4;

            acum1 = acum2  = 0;
            acum3 = acum4 = R;

            for ( int k = 0; k < NN; k++)
            {
                if( k < N)
                {
                    Px[k] = acum1;
                    Py[k] = 0;
                    acum1 += delta;
                }
                else if ( k < N*2)
                {
                    Px[k] = R;
                    Py[k] = acum2;
                    acum2 += delta;
                }
                else if ( k < N*3)
                {
                    Px[k] = acum3;
                    Py[k] = R;
                    acum3 -= delta;
                }
                else
                {
                    Px[k] = 0;
                    Py[k] = acum4;
                    acum4 -= delta;
                }
            }

            Point pStart = new Point();
            Point pEnd = new Point();

            int tmp;
            for ( int i = 0; i < NN; i++)
            {
                pStart = new Point((int)Px[i] + px, (int)Py[i] + py);

                for (int j = 0; j < NN; j++)
                {
                    tmp = j-i;
                    if (tmp > NN)
                        break;
                    if ( tmp < 0)
                    {
                        tmp += NN;
                    }

                    if (fibwar(tmp))//jesli jest
                    {
                        pEnd = new Point((int)Px[j] + px, (int)Py[j] + py) ;
                        g.DrawLine(pen1, pStart, pEnd);
                    }


                }

            }




        }

        int NWD (int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }
        int edit = 10;

        private void button15_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

            DrawZajebistobok(91, 49, 50);
        }

        void DrawZajebistobok ( int _A, int _B, int _D)
        {

            int px = pictureBox1.Width / 2;
            int py = pictureBox1.Height / 2;

            int A = _A; //promien calkowity
            int B = _B; //promien tarczy
            int D = _D; // odleglosc otworu


            int scale = 1;


            int RD = D * scale;
            int RAB = (A - B) * scale;

            double theta = 0;
            double delta = Math.PI * 0.02;

            float ABVERB = (float)A / (float)B;

            double N = B / NWD(A, B);
            double NB = 100 * N;

            Point pStart = new Point(RAB + RD + px, py);
            Point pEnd = new Point();

            double PHI, x, y;
            for (int i = 0; i < NB; i++)
            {
                theta += delta;
                PHI = theta * ABVERB;
                x = RAB * Math.Cos(theta) + RD * Math.Cos(PHI);
                y = RAB * Math.Sin(theta) - RD * Math.Sin(PHI);

                pEnd = new Point((int)x + px, (int)y + py);
                g.DrawLine(pen1, pStart, pEnd);
                pStart = pEnd;

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            DrawBoxinBos(0.1);
        }

        void DrawBoxinBos (double _mi)
        {
            int a = 200;
            int px = pictureBox1.Width / 2 - a / 2;
            int py = pictureBox1.Height / 2 - a / 2;

            Point[] tabPoint = new Point[4];
            tabPoint[0] = new Point(px, py);
            tabPoint[1] = new Point(a + px, py);
            tabPoint[2] = new Point(a + px, a + py);
            tabPoint[3] = new Point(px, a + py);

            Point[] tabXPoint = new Point[4];

            int ill = 20;
            double mi = _mi;

            double rmi = 1 - mi;
            double x, y;

            for (int i = 0; i < ill; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j < 3)
                        g.DrawLine(pen1, tabPoint[j], tabPoint[j + 1]);
                    else
                        g.DrawLine(pen1, tabPoint[j], tabPoint[0]);
                }

                for (int j = 0; j < 4; j++)
                {
                    if (j < 3)
                    {
                        y = tabPoint[j].Y * rmi + tabPoint[j + 1].Y * mi;
                        x = tabPoint[j].X * rmi + tabPoint[j + 1].X * mi;
                        tabXPoint[j] = new Point((int)x, (int)y);
                    }
                    else
                    {
                        y = tabPoint[j].Y * rmi + tabPoint[0].Y * mi;
                        x = tabPoint[j].X * rmi + tabPoint[0].X * mi;
                        tabXPoint[j] = new Point((int)x, (int)y);
                    }
                }

                tabPoint = tabXPoint;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            DrawBoxinBos(0.05);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }



    }
}
