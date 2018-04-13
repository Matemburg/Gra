using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Princes_Escape
{
    public partial class Gra : Form
    {
        private Lvl poziom;
        private int wielkosc_planszy = 9;
        private Gracz Princess;
        private Graphics g;
        private Graphics l;
        private Point p = Point.Empty;
        private Point A = Point.Empty;
        private Point B = Point.Empty;
        private Pen pioro;
        private Pen REDPEN;
        private Plansza PLANSZA;
        private Image Pipi;
        private int prevint;
        private int stage = 0;
        private int lkrokow = 0;
        //  private Przeciwnik[3] Spiders;
        //  private int i = 0;
        //   private int j = 0;


        public Gra()
        {
   
            InitializeComponent();
         
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {



        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

        }





        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Magia()
        {

         

            bool wygrana = false;
            g.Clear(Color.Transparent);

           

            for (float x = (Width - Height) / 2; x <= Height + ((Width - Height) / 2); x = x + Height / wielkosc_planszy)
            {
                for (float y = 0; y < Height; y = y + Height / wielkosc_planszy)
                {
                    A.X = (int)x;
                    A.Y = 0;
                    B.X = (int)x;
                    B.Y = Height;
                    //l.DrawLine(pioro, A, B);
                    A.X = (Width - Height) / 2;
                    A.Y = (int)y;
                    B.X = Width - ((Width - Height) / 2);
                    B.Y = (int)y;
                    g.DrawImage(Princes_Escape.Properties.Resources.Ladder__Wood_, PLANSZA.POLA[0, 0].centrumX - 32, PLANSZA.POLA[0, 0].centrumY - 32, 64, 64);
                    //  l.DrawLine(pioro, A, B);




                }
            }


  

            ////pipi

            if (PLANSZA.POLA[Princess.get_x(), Princess.get_y()].permission == false)
            {
                Princess.back();
            }

         

            if (PLANSZA.POLA[Princess.get_x(), Princess.get_y()] == PLANSZA.POLA[wielkosc_planszy - 1, wielkosc_planszy - 1])
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        PLANSZA.POLA[i, j].permission = true;
                    }
                }
                // MessageBox.Show("Wygrana");
                stage++;
                label4.Text = stage.ToString();
                Princess.restart(0, 0);
                poziom.Lvl_losuj(stage);

            }
       

       

            ///// Przeszkody


            for (int w = 0; w < poziom.get_przeszkody()[0].get_Count(); w++)
            {

                g.DrawImage(poziom.get_przeszkody()[w].avatar, PLANSZA.POLA[poziom.get_przeszkody()[w].get_x(), poziom.get_przeszkody()[w].get_y()].centrumX - 32, PLANSZA.POLA[poziom.get_przeszkody()[w].get_x(), poziom.get_przeszkody()[w].get_y()].centrumY - 32, 64, 64);
            }

            g.DrawImage(Pipi, PLANSZA.POLA[Princess.get_x(), Princess.get_y()].centrumX - 32, PLANSZA.POLA[Princess.get_x(), Princess.get_y()].centrumY - 32, 64, 64);



            /// WROGOWIE ////////////////////////////////////////////

            for (int w = 0; w < poziom.get_wrogowie()[0].get_Count(); w++)
            {
                if (PLANSZA.POLA[Princess.get_x(), Princess.get_y()] == PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()])
                {


                    if (poziom.get_wrogowie()[w].get_istnieje() == true)
                    {
                        Princess.zran();
                        prevint = Princess.get_lvl();
                        Princess.addXP(1);
                        progressBar1.Maximum = Princess.get_trudnosc();
                        progressBar1.Increment(1);
                        label2.Text = Princess.get_lvl().ToString();
                        if (prevint < Princess.get_lvl())
                        {
                            progressBar1.Increment(-Princess.get_trudnosc());
                        }

                        if (Princess.gethp() == 0)
                        {
                            MessageBox.Show("Koniec GRY" + " Liczba krokow wynios³a " + lkrokow.ToString());
                            System.Windows.Forms.Application.Exit();

                        }

                        SoundPlayer simpleSound;
                        simpleSound = new SoundPlayer(Princes_Escape.Properties.Resources.Kill);
                        simpleSound.Play();
                        poziom.get_wrogowie()[w].zabij();
                    }
                }
            }

                for (int w = 0; w < poziom.get_wrogowie()[0].get_Count(); w++)
            {
                if (poziom.get_wrogowie()[w].get_istnieje() == true)
                    g.DrawImage(poziom.get_wrogowie()[w].avatar, PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()].centrumX - 32, PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()].centrumY - 32, 64, 64);
            }


            ////////////////////// APTECZKI ///////////////////////////
            for (int a = 0; a < poziom.get_item()[0].get_Count(); a++)
            {
                if (PLANSZA.POLA[Princess.get_x(), Princess.get_y()] == PLANSZA.POLA[poziom.get_item()[a].get_x(), poziom.get_item()[a].get_y()]&& poziom.get_item()[a].get_istnieje()==true)
            {
                poziom.get_item()[a].Akcja(Princess);
             //   poziom.get_item()[a].used();


            }

       
                        if (poziom.get_item()[a].get_istnieje() == true)
                            g.DrawImage(poziom.get_item()[a].avatar, PLANSZA.POLA[poziom.get_item()[a].get_x(), poziom.get_item()[a].get_y()].centrumX - 32, PLANSZA.POLA[poziom.get_item()[a].get_x(), poziom.get_item()[a].get_y()].centrumY - 32, 64, 64);

                   



                    }

            for (int i = 0; i < poziom.get_przeszkody()[0].get_Count(); i++)
            {
                PLANSZA.POLA[poziom.get_przeszkody()[i].get_x(), poziom.get_przeszkody()[i].get_y()].permission = false;
            }

      

                g.DrawImage(Properties.Resources.Trapdoor, PLANSZA.POLA[wielkosc_planszy - 1, wielkosc_planszy - 1].centrumX - 32, PLANSZA.POLA[wielkosc_planszy - 1, wielkosc_planszy - 1].centrumY - 32, 64, 64);
                for (int i = 0; Princess.gethp() > i; i++)
                {
                    g.DrawImage(Properties.Resources.Serce, 15, 15 + i * 65, 64, 64);
                }
                    imgObrazek.Refresh();
                }
            
        
        

        private void frmMiniPaint_Load(object sender, EventArgs e)
        {
            progressBar1.Location = new Point(Width/30,4*Height/5);
            progressBar1.Size = new Size((Width*10)/65, 24);
            label2.Location = new Point(Width / 30, 4*Height / 7);
            label4.Location = new Point(5*Width /6, 4 * Height / 7);
            label2.Parent = imgObrazek;
            label4.Parent = imgObrazek;

        

            poziom = new Lvl();
            poziom.Lvl_1();
           
            PLANSZA = new Plansza(Height, wielkosc_planszy, (Width - Height) / 2);
            for (int i = 0; i < poziom.get_przeszkody()[0].get_Count(); i++)
            {
                PLANSZA.POLA[poziom.get_przeszkody()[i].get_x(), poziom.get_przeszkody()[i].get_y()].permission = false;
            }
            Princess = new Gracz(0, 0, wielkosc_planszy);
            imgObrazek.Image = new Bitmap(Width, Height);
            g = Graphics.FromImage(imgObrazek.Image);
            l = Graphics.FromImage(imgObrazek.Image);
            
            pioro = new Pen(Color.White);
            REDPEN = new Pen(Color.Red);
            Pipi = Princes_Escape.Properties.Resources.Princes;
            label2.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            Magia();
        }

        private void frmMiniPaint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
                System.Windows.Forms.Application.Exit();
         
            if (e.KeyChar == 'w' || e.KeyChar =='W')
                Princess.ruch_up(); 
            else
            if (e.KeyChar == 's' || e.KeyChar == 'S')
                Princess.ruch_down(); 
            else
            if (e.KeyChar == 'd' || e.KeyChar == 'D')
                    Princess.ruch_left();
            else
            if (e.KeyChar == 'a' || e.KeyChar == 'A')
                    Princess.ruch_right();
            if (e.KeyChar == '+')
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        PLANSZA.POLA[i, j].permission = true;
                    }
                }
                        poziom.Lvl_2();
                for (int i = 0; i < poziom.get_przeszkody()[0].get_Count(); i++)
                {
                    PLANSZA.POLA[poziom.get_przeszkody()[i].get_x(), poziom.get_przeszkody()[i].get_y()].permission = false;
                }
            }
            if (e.KeyChar == '-')
            {
                Princess.restart(0, 0);
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        PLANSZA.POLA[i, j].permission = true;
                    }
                }
                poziom.Lvl_losuj(stage);
           
            }
            lkrokow++;
            Magia();
            

        }

        private void imgObrazek_Click(object sender, EventArgs e)
        {

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Gra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                Princess.ruch_up();
            else
 if (e.KeyCode == Keys.Down)
                Princess.ruch_down();
            else
 if (e.KeyCode == Keys.Right)
                Princess.ruch_left();
            else
 if (e.KeyCode == Keys.Left)
                Princess.ruch_right();




            lkrokow++;
            Magia();
        }
    }
}