using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Princes_Escape
{
    public partial class Form3 : Form
    {
        string poziom = new string('0', 81);
        public Form3()
        {
            InitializeComponent();
        }

        private void rysuj(Graphics p, int numer)
        {
            if (radioButton1.Checked)
            {
                p.DrawImage(Properties.Resources.spider, 0, 0);
               // poziom.;
            }
            if (radioButton2.Checked)
                p.DrawImage(Properties.Resources.MEDIC, 0, 0);
            if (radioButton3.Checked)
                p.DrawImage(Properties.Resources.Lava, 0, 0);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Pen black = new Pen(Color.Black, 2);
            Graphics tlo;
            pictureBox82.Image = new Bitmap(592, 592);
            tlo = Graphics.FromImage(pictureBox82.Image);
            for(int i=0; i<9;i++)
            {
                tlo.DrawLine(black, i * 64+i*2, 0, i * 64+i*2, 592);
            }
  

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Graphics p9;
            pictureBox9.Image = new Bitmap(64, 64);
            p9 = Graphics.FromImage(pictureBox9.Image);
            rysuj(p9, 0);
       

        }

    
    }
}
