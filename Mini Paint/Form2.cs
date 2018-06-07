using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Princes_Escape
{
    public partial class Form2 : Form
    {
        public SoundPlayer simpleSound;
        public SoundPlayer Klik= new SoundPlayer(Properties.Resources.Button_select);
        private Graphics l;
        public string nick = "";
        public Form2()
        {
            InitializeComponent();
            
        
            pictureBox1.Image = new Bitmap(300, 100);
            l = Graphics.FromImage(pictureBox1.Image);
            l.DrawImage(Princes_Escape.Properties.Resources.Princes, 0, 0);
            pictureBox10.Image = new Bitmap(80, 80);
            l = Graphics.FromImage(pictureBox10.Image);
            l.DrawImage(Princes_Escape.Properties.Resources.KK_2, 0, 0);
            pictureBox11.Image = new Bitmap(80, 80);
            l = Graphics.FromImage(pictureBox11.Image);
            l.DrawImage(Princes_Escape.Properties.Resources.księżniczka_3, 0, 0);

            // new Form4();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            nick = this.nickbox.Text;
            if (nick == "") MessageBox.Show("Podaj nick!");
            else
            {
                simpleSound.Stop();
                Klik.Play();
                new Gra(nick).Show();
                this.Hide();
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(); 
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Klik.Play();
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Klik.Play();
            new Ustawienia().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Klik.Play();
            MessageBox.Show("Matuesz Owczarczyk & Bałażej Kątny & Damian Karwowski");
        }

        private void button_edytor_Click(object sender, EventArgs e)
        {
            simpleSound.Stop();
            Klik.Play();
            new Form3().Show();
            this.Hide();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            simpleSound = new SoundPlayer(Princes_Escape.Properties.Resources.Menu);
            simpleSound.PlayLooping();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Users.ListaUserow.Count > 0)
            {
                new Form4().Show();
            }
            else
            {
                MessageBox.Show("Najpierw zagraj!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
