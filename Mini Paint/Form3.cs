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

        }

        private void Form3_Load(object sender, EventArgs e)
        {
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

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }
    }
}
