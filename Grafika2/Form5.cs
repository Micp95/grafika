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
    public partial class Form5 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Graphics g2;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Red, 0.1f);

        private System.Drawing.Pen pen2 = new System.Drawing.Pen(Color.Green, 0.1f);
        private System.Drawing.Pen pen3 = new System.Drawing.Pen(Color.Blue, 0.1f);


        Point P1 = new Point();
        Point P2 = new Point();


        Point PL1 = new Point();
        Point PL2 = new Point();

        int cx, cy;
        public Form5()
        {
            InitializeComponent();

            g = pictureBox1.CreateGraphics();
            g2 = pictureBox2.CreateGraphics();
            cx = pictureBox1.Width / 2;
            cy = pictureBox1.Height / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tmpx, tmpy;
            int.TryParse(textBox1.Text, out tmpx);
            int.TryParse(textBox2.Text, out tmpy);
            tmpy = -tmpy;
            PL1 = new Point(tmpx + cx, tmpy + cy);

            int.TryParse(textBox3.Text, out tmpx);
            int.TryParse(textBox4.Text, out tmpy);
            tmpy = -tmpy;
            PL2 = new Point(tmpx + cx, tmpy + cy);

            drawScene();

        }
        void drawScene()
        {
            pictureBox1.Refresh();

            if( PL1 != null && PL2 != null)
                g.DrawLine(pen1, PL1, PL2);

            if (P1 != null)
                g.DrawEllipse(pen2, P1.X-2, P1.Y-2, 4, 4);

            if (P2 != null)
                g.DrawEllipse(pen3, P2.X-2, P2.Y-2, 4, 4);
        }

        int actPoint = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            double a = (double)(PL1.Y - PL2.Y) / (double)(PL1.X - PL2.X);
            double b = (double)PL1.Y - (double)(a * PL1.X);


            double x = (double)P1.Y - a * (double)P1.X - b;
            string tekst = "Dla punkut zielonego: ";

            if ( x > 0)
                tekst += "punkt lezy po pierwszej stronie.";
            else if ( x < 0)
                tekst += "punkt lezy po drugiej stronie.";
            else
                tekst += "punkt lezy na linii.";



            label1.Text = tekst;
        }

        double relativePosition (Point PL1,Point PL2, Point P1,Point P2)
        {
            double a = (double)(PL1.Y - PL2.Y) / (double)(PL1.X - PL2.X);
            double b = (double)PL1.Y - (double)(a * PL1.X);

            double x1 = (double)P1.Y - a * (double)P1.X - b;
            double x2 = (double)P2.Y - a * (double)P2.X - b;

            double xx = x1 * x2;

            return xx;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            double xx = relativePosition(PL1, PL2, P1, P2);

            string tekst = "";

            if (xx > 0)
                tekst += "punkty lezo po tej samej stronie.";
            else if (xx < 0)
                tekst += "punkty lezo po przeciwnej stronie";
            else
                tekst += "jeden punkt lezy na linii.";


            label2.Text = tekst;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double a = (double)(PL1.Y - PL2.Y) / (double)(PL1.X - PL2.X);
            double b = (double)PL1.Y - (double)(a * PL1.X);


            double x = (double)P1.Y - a * (double)P1.X - b;
            string tekst = "";

            if (x == 0)
                tekst += "punkt zielony nalezy do odcinka";
            else
                tekst += "punkt zielony nie nalezy do odcinka";

            label3.Text = tekst;
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            drawScene();
            g.DrawLine(pen1,P1,P2);

            double xx1 = relativePosition(PL1, PL2, P1, P2);

            double xx2 = relativePosition(P1, P2, PL1, PL2);

            string tekst = "";

            if (xx1 == 0 && xx2 == 0)
                tekst += "odcinki sa wspolniniowe";
            else if ( xx1 <= 0 && xx2 <= 0)
                tekst += "odcinki sie przecinaja";
            else
                tekst += "odcinki sie nie przecinaja";

            label4.Text = tekst;
        }



        int linecount = 0;
        int polDegree = 0;
        int actual = 0;
        Point[] figure = null;
        private void button7_Click(object sender, EventArgs e)
        {
            int K;
            int.TryParse(textBox5.Text, out K);
            polDegree = K;
            actual = 0;
            linecount = 0;
            figure = new Point[polDegree];

            linesTab = new line[polDegree];
        }

        void drawFigure()
        {

            if ( actual != 1)
                for (int k = 0; k < linecount; k++)
                    g2.DrawLine(pen1, linesTab[k].P1, linesTab[k].P2);

        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if(polDegree != 0)
            {
                pictureBox2.Refresh();

                MouseEventArgs me = (MouseEventArgs)e;
                Point loc = me.Location;

                if ( actual < polDegree)
                {
                    figure[actual] = loc;

                    if ( actual != 0)
                    {
                        linesTab[actual - 1] = new line(figure[actual - 1], figure[actual]);
                        linecount++;
                    }
                        
                    actual++;

                    if (actual == polDegree)
                    {
                        linesTab[polDegree - 1] = new line(figure[0], figure[actual-1]);
                        linecount++;
                    }

                }
                else
                {
                    g2.DrawEllipse(pen2, loc.X - 2, loc.Y - 2, 4, 4);

                    if (przynaleznoscPro(loc))
                        label6.Text = "Zawarty w wielokacie.";
                    else
                        label6.Text = "Poza wielokatem.";

                }
                drawFigure();
            }

        }

        enum stan
        {
            brak,przeciecie,wspol
        }

        stan przeciecieOdcinkow ( Point PL1, Point PL2, Point P1,Point P2)
        {
            double xx1 = relativePosition(PL1, PL2, P1, P2);
            double xx2 = relativePosition(P1, P2, PL1, PL2);


            if (xx1 == 0 && xx2 == 0)
                return stan.wspol;
            else if (xx1 <= 0 && xx2 <= 0)
                return stan.przeciecie;
            else
                return stan.brak;
        }

        class line
        {
            public Point P1;
            public Point P2;
            public line(Point P1, Point P2) {
                this.P1 = P1;
                this.P2 = P2;
            }
        };
      

        line[] linesTab;

        bool przynaleznoscPro ( Point myPoint)
        {

            Point infPoint = new Point(pictureBox2.Width + 20, pictureBox2.Height + 20);


            int liczbaPrzeciec;
            bool wspollinowy = false;
            stan wart;
            int count = 0;

            do
            {
                if (wspollinowy)
                    infPoint = new Point(pictureBox2.Width + 20, pictureBox2.Height + 20 + ++count);

                liczbaPrzeciec = 0;
                wspollinowy = false;

                for (int k = 0; k < linecount; k++)
                {
                    wart = przeciecieOdcinkow(linesTab[k].P1, linesTab[k].P2, infPoint, myPoint);
                    if (wart == stan.wspol)
                    {
                        wspollinowy = true;
                        break;
                    }
                    else if (wart == stan.przeciecie)
                        liczbaPrzeciec++;
                }

            } while (wspollinowy);


            if (liczbaPrzeciec % 2 == 0)
                return false;
            else
                return true;
        }
     
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
         
            Point loc = me.Location;
            if (actPoint == 0){
                P1 = loc;
                actPoint = 1;
            }
            else{
                P2 = loc;
                actPoint = 0;
            }
            drawScene();
        }
    }
}
