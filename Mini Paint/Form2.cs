using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Princes_Escape
{
    public partial class Form2 : Form
    {
        public SoundPlayer simpleSound;
        public SoundPlayer Klik= new SoundPlayer(Properties.Resources.Button_select);
        private Graphics l;
        public Form2()
        {
            InitializeComponent();
            simpleSound = new SoundPlayer(Princes_Escape.Properties.Resources.Menu);
            simpleSound.Play();
        
            pictureBox1.Image = new Bitmap(300, 100);
            l = Graphics.FromImage(pictureBox1.Image);
            l.DrawImage(Princes_Escape.Properties.Resources.Princes, 100, 25);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            simpleSound.Stop();
            Klik.Play();
            new Gra().Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
