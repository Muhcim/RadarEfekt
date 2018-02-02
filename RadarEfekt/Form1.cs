using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadarEfekt
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();

        int WİDTH = 300, HEİGHT = 300, HAND = 150;

        int u;// Derecede
        int cx, cy;//   çember merkezi
        int x, y;//   El koordinatörlüğü
        int tx, ty, lim = 20;

        Bitmap bmp;
        Pen p;
        Graphics g;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Bitmap Oluştur
            bmp = new Bitmap(WİDTH + 1, HEİGHT + 1);
            

            //BackGround Color
            this.BackColor = Color.Black;

            //center

            cx = WİDTH / 2;
            cy = HEİGHT / 2;

            //Elin İlk Derecesi
            u = 0;


            //timer
            t.Interval = 5;//Milisaniye Cinsinden
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();            
        }
        private void t_Tick(object sender, EventArgs e)
        {
            //Kalem
            p = new Pen(Color.Green, 1f);
          
            //graphics
            g = Graphics.FromImage(bmp);


            //Elin x ve y kordinatını hesapla
            int tu = (u - lim) % 360;

            if (u >= 0 && u <= 180)
            {
                //Sağ Yarım
                //u Radyan Dönüştürme

                x = cx + (int)(HAND * Math.Sin(Math.PI * u / 180));
                y = cy - (int)(HAND * Math.Cos(Math.PI * u / 180));


            }
            else
            {
                x = cx - (int)(HAND * -Math.Sin(Math.PI * u / 180));
                y = cy - (int)(HAND * Math.Cos(Math.PI * u / 180));

            }
            if (u >= 0 && u <= 180)
            {
                //sağ yarım
                //u Radyan Dönüştürme

                tx = cx + (int)(HAND * Math.Sin(Math.PI * tu / 180));
                ty = cy - (int)(HAND * Math.Cos(Math.PI * tu / 180));


            }
            else
            {
               tx = cx - (int)(HAND *-Math.Sin(Math.PI * tu / 180));
               ty = cy - (int)(HAND * Math.Cos(Math.PI * tu / 180));



            }
            //Daire Çiz

            g.DrawEllipse(p, 0, 0, WİDTH, HEİGHT); //Daha Büyük Daire
            g.DrawEllipse(p,80,80,WİDTH-160,HEİGHT-160);





            //Dikey Çizgi Çiz
            g.DrawLine(p, new Point(cx, 0), new Point(cx, HEİGHT));//Yukarı Aşağı
            g.DrawLine(p, new Point(0, cy), new Point(WİDTH, cy));//Sol sağ

            //Elini Çiz
            g.DrawLine(new Pen(Color.Black, 1f), new Point(cx, cy), new Point(tx, ty));
            g.DrawLine(p, new Point(cx, cy), new Point(x, y));

            //Resim yükle Bitmap
            pictureBox1.Image = bmp;


            //Elden Çıkarmak 
            p.Dispose();
            g.Dispose();

            //Güncelleştirme
            u++;
            if (u == 360)
            {
                u = 0;
            }


        }
    }
}
//Formun StartPosition'unu Center Screen Yapıyoruz