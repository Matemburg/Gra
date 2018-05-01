using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Princes_Escape
{
    public partial class Form3 : Form
    {
        WaveOut muzyka = new WaveOut();
        public SoundPlayer Klik = new SoundPlayer(Properties.Resources.Button_select);
        string [] poziom = new string[81];
        string zapis_poziomu;
        public Form3()
        {
            InitializeComponent();
        }

        private void rysuj(Graphics p, int numer)
        {
            if (radioButton1.Checked)
            {
                p.DrawImage(Properties.Resources.spider, 0, 0);
                poziom[numer] = "p";
            }
            if (radioButton2.Checked)
            {
                p.DrawImage(Properties.Resources.MEDIC, 0, 0);
                poziom[numer] = "a";
            }
            if (radioButton3.Checked)
            {
                p.DrawImage(Properties.Resources.Lava, 0, 0);
                poziom[numer] = "l";   
            }
            if (radioButton4.Checked)
            {
                p.DrawImage(Properties.Resources.wąż, 0, 0);
                poziom[numer] = "w";
            }
            if (radioButton5.Checked)
            {
                p.DrawImage(Properties.Resources.Empty, 0, 0);
                poziom[numer] = "0";
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
         //   var waveOut = new WaveOut(); // or WaveOutEvent()
                                         //  waveOut.Init(new WaveFileReader(Properties.Resources.mo));
                                         // waveOut.Volume = (float)0.5;
                                         //  waveOut.Play();

            MemoryStream mp3file = new MemoryStream(Properties.Resources.Motivated);
            Mp3FileReader mp3reader = new Mp3FileReader(mp3file);
     
            muzyka.Init(mp3reader);
            muzyka.Play();
            zapis_poziomu += "0";
            for (int i = 0; i < 81; i++)
                poziom[i] = "0";
            Pen black = new Pen(Color.Black, 2);
            Graphics tlo;
            pictureBox82.Image = new Bitmap(592, 592);
            tlo = Graphics.FromImage(pictureBox82.Image);
            for(int i=0; i<9;i++)
            {
                tlo.DrawLine(black, i * 64+i*2, 0, i * 64+i*2, 592);
            }
            for(int i = 0; i < 9; i++)
            {
                tlo.DrawLine(black,0, i * 64 + i * 2,  592,i * 64 + i * 2);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            Klik.Play();
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Klik.Play();
            zapis_poziomu = new string('0',0);
            MessageBox.Show(zapis_poziomu);
            for (int i = 0; i < 81; i++)
                zapis_poziomu += poziom[i];
            File.WriteAllText("mapy.txt", zapis_poziomu);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Klik.Play();
            new Form2().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Klik.Play();
            zapis_poziomu = new string('0', 0);
            //MessageBox.Show(zapis_poziomu);
            for (int i = 0; i < 81; i++)
                zapis_poziomu += poziom[i];
            muzyka.Pause();
            File.WriteAllText("mapy.txt", zapis_poziomu);
            Gra GRA = new Gra(true);
            GRA.Show();

            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Graphics p9;
            pictureBox9.Image = new Bitmap(64, 64);
            p9 = Graphics.FromImage(pictureBox9.Image);
            rysuj(p9, 0);
        }
        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            Graphics p8;
            pictureBox8.Image = new Bitmap(64, 64);
            p8 = Graphics.FromImage(pictureBox8.Image);
            rysuj(p8, 1);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Graphics p7;
            pictureBox7.Image = new Bitmap(64, 64);
            p7 = Graphics.FromImage(pictureBox7.Image);
            rysuj(p7, 2);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Graphics p6;
            pictureBox6.Image = new Bitmap(64, 64);
            p6= Graphics.FromImage(pictureBox6.Image);
            rysuj(p6, 3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Graphics p5;
            pictureBox5.Image = new Bitmap(64, 64);
            p5 = Graphics.FromImage(pictureBox5.Image);
            rysuj(p5, 4);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Graphics p4;
            pictureBox4.Image = new Bitmap(64, 64);
            p4 = Graphics.FromImage(pictureBox4.Image);
            rysuj(p4, 5);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox3.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox3.Image);
            rysuj(p3, 6);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Graphics p2;
            pictureBox2.Image = new Bitmap(64, 64);
            p2 = Graphics.FromImage(pictureBox2.Image);
            rysuj(p2, 7);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics p1;
            pictureBox1.Image = new Bitmap(64, 64);
            p1 = Graphics.FromImage(pictureBox1.Image);
            rysuj(p1, 8);
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Graphics p18;
            pictureBox18.Image = new Bitmap(64, 64);
            p18 = Graphics.FromImage(pictureBox18.Image);
            rysuj(p18, 9);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Graphics p17;
            pictureBox17.Image = new Bitmap(64, 64);
            p17 = Graphics.FromImage(pictureBox17.Image);
            rysuj(p17, 10);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Graphics p16;
            pictureBox16.Image = new Bitmap(64, 64);
            p16 = Graphics.FromImage(pictureBox16.Image);
            rysuj(p16, 11);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Graphics p15;
            pictureBox15.Image = new Bitmap(64, 64);
            p15 = Graphics.FromImage(pictureBox15.Image);
            rysuj(p15, 12);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Graphics p14;
            pictureBox14.Image = new Bitmap(64, 64);
            p14= Graphics.FromImage(pictureBox14.Image);
            rysuj(p14, 13);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Graphics p13;
            pictureBox13.Image = new Bitmap(64, 64);
            p13 = Graphics.FromImage(pictureBox13.Image);
            rysuj(p13, 14);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Graphics p12;
            pictureBox12.Image = new Bitmap(64, 64);
            p12 = Graphics.FromImage(pictureBox12.Image);
            rysuj(p12, 15);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Graphics p11;
            pictureBox11.Image = new Bitmap(64, 64);
            p11 = Graphics.FromImage(pictureBox11.Image);
            rysuj(p11, 16);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Graphics p10;
            pictureBox10.Image = new Bitmap(64, 64);
            p10 = Graphics.FromImage(pictureBox10.Image);
            rysuj(p10, 17);
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            Graphics p27;
            pictureBox27.Image = new Bitmap(64, 64);
            p27 = Graphics.FromImage(pictureBox27.Image);
            rysuj(p27, 18);
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            Graphics p26;
            pictureBox26.Image = new Bitmap(64, 64);
            p26 = Graphics.FromImage(pictureBox26.Image);
            rysuj(p26, 19);
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            Graphics p25;
            pictureBox25.Image = new Bitmap(64, 64);
            p25 = Graphics.FromImage(pictureBox25.Image);
            rysuj(p25, 20);
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Graphics p24;
            pictureBox24.Image = new Bitmap(64, 64);
            p24 = Graphics.FromImage(pictureBox24.Image);
            rysuj(p24, 21);
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            Graphics p23;
            pictureBox23.Image = new Bitmap(64, 64);
            p23 = Graphics.FromImage(pictureBox23.Image);
            rysuj(p23, 22);
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Graphics p22;
            pictureBox22.Image = new Bitmap(64, 64);
            p22 = Graphics.FromImage(pictureBox22.Image);
            rysuj(p22, 23);
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Graphics p21;
            pictureBox21.Image = new Bitmap(64, 64);
            p21 = Graphics.FromImage(pictureBox21.Image);
            rysuj(p21, 24);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Graphics p20;
            pictureBox20.Image = new Bitmap(64, 64);
            p20 = Graphics.FromImage(pictureBox20.Image);
            rysuj(p20, 25);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Graphics p19;
            pictureBox19.Image = new Bitmap(64, 64);
            p19 = Graphics.FromImage(pictureBox19.Image);
            rysuj(p19, 26);
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            Graphics p36;
            pictureBox36.Image = new Bitmap(64, 64);
            p36 = Graphics.FromImage(pictureBox36.Image);
            rysuj(p36, 27);
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            Graphics p35;
            pictureBox35.Image = new Bitmap(64, 64);
            p35 = Graphics.FromImage(pictureBox35.Image);
            rysuj(p35, 28);
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            Graphics p34;
            pictureBox34.Image = new Bitmap(64, 64);
            p34 = Graphics.FromImage(pictureBox34.Image);
            rysuj(p34, 29);
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            Graphics p33;
            pictureBox33.Image = new Bitmap(64, 64);
            p33 = Graphics.FromImage(pictureBox33.Image);
            rysuj(p33, 30);
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            Graphics p32;
            pictureBox32.Image = new Bitmap(64, 64);
            p32 = Graphics.FromImage(pictureBox32.Image);
            rysuj(p32, 31);
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            Graphics p31;
            pictureBox31.Image = new Bitmap(64, 64);
            p31 = Graphics.FromImage(pictureBox31.Image);
            rysuj(p31, 32);
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            Graphics p30;
            pictureBox30.Image = new Bitmap(64, 64);
            p30 = Graphics.FromImage(pictureBox30.Image);
            rysuj(p30, 33);
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            Graphics p29;
            pictureBox29.Image = new Bitmap(64, 64);
            p29 = Graphics.FromImage(pictureBox29.Image);
            rysuj(p29, 34);
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            Graphics p28;
            pictureBox28.Image = new Bitmap(64, 64);
            p28 = Graphics.FromImage(pictureBox28.Image);
            rysuj(p28, 35);
        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox45.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox45.Image);
            rysuj(p3, 36);
        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox44.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox44.Image);
            rysuj(p3, 37);
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox43.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox43.Image);
            rysuj(p3, 38);
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox42.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox42.Image);
            rysuj(p3, 39);
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox41.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox41.Image);
            rysuj(p3, 40);
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox40.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox40.Image);
            rysuj(p3, 41);
        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox39.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox39.Image);
            rysuj(p3, 42);
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox38.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox38.Image);
            rysuj(p3, 43);
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox37.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox37.Image);
            rysuj(p3, 44);
        }

        private void pictureBox54_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox54.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox54.Image);
            rysuj(p3, 45);
        }

        private void pictureBox53_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox53.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox53.Image);
            rysuj(p3, 46);
        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox52.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox52.Image);
            rysuj(p3, 47);
        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox51.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox51.Image);
            rysuj(p3, 48);
        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox50.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox50.Image);
            rysuj(p3, 49);
        }

        private void pictureBox49_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox49.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox49.Image);
            rysuj(p3, 50);
        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox48.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox48.Image);
            rysuj(p3, 51);
        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox47.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox47.Image);
            rysuj(p3, 52);
        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox46.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox46.Image);
            rysuj(p3, 53);
        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox63.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox63.Image);
            rysuj(p3, 54);
        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox62.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox62.Image);
            rysuj(p3, 55);
        }

        private void pictureBox61_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox61.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox61.Image);
            rysuj(p3, 56);
        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox60.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox60.Image);
            rysuj(p3, 57);
        }

        private void pictureBox59_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox59.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox59.Image);
            rysuj(p3, 58);
        }

        private void pictureBox58_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox58.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox58.Image);
            rysuj(p3, 59);
        }

        private void pictureBox57_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox57.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox57.Image);
            rysuj(p3, 60);
        }

        private void pictureBox56_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox56.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox56.Image);
            rysuj(p3, 61);
        }

        private void pictureBox55_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox55.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox55.Image);
            rysuj(p3, 62);
        }

        private void pictureBox72_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox72.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox72.Image);
            rysuj(p3, 63);
        }

        private void pictureBox71_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox71.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox71.Image);
            rysuj(p3, 64);
        }

        private void pictureBox70_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox70.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox70.Image);
            rysuj(p3, 65);
        }

        private void pictureBox69_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox69.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox69.Image);
            rysuj(p3, 66);
        }

        private void pictureBox68_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox68.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox68.Image);
            rysuj(p3, 67);
        }

        private void pictureBox67_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox67.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox67.Image);
            rysuj(p3, 68);
        }

        private void pictureBox66_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox66.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox66.Image);
            rysuj(p3, 69);
        }

        private void pictureBox65_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox65.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox65.Image);
            rysuj(p3, 70);
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox64.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox64.Image);
            rysuj(p3, 71);
        }

        private void pictureBox81_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox81.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox81.Image);
            rysuj(p3, 72);
        }

        private void pictureBox80_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox80.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox80.Image);
            rysuj(p3, 73);
        }

        private void pictureBox79_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox79.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox79.Image);
            rysuj(p3, 74);
        }

        private void pictureBox78_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox78.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox78.Image);
            rysuj(p3, 75);
        }

        private void pictureBox77_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox77.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox77.Image);
            rysuj(p3, 76);
        }

        private void pictureBox76_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox76.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox76.Image);
            rysuj(p3, 77);
        }

        private void pictureBox75_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox75.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox75.Image);
            rysuj(p3, 78);
        }

        private void pictureBox74_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox74.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox74.Image);
            rysuj(p3, 79);
        }

        private void pictureBox73_Click(object sender, EventArgs e)
        {
            Graphics p3;
            pictureBox73.Image = new Bitmap(64, 64);
            p3 = Graphics.FromImage(pictureBox73.Image);
            rysuj(p3, 80);
        }
    }
}
