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
        public SoundPlayer Krok;
        private Lvl poziom;
        private int wielkosc_planszy = 9;
        private Gracz Princess;
        private Graphics g;
        private Graphics l;
        private Plansza PLANSZA;
        private Image Pipi;
        private int lvl_Princess;
        private int stage = 0;
        private int lkrokow = 0;

        public Gra()
        {
            InitializeComponent();
        }

        private void Rysowanie_i_obliczanie()
        {
            g.Clear(Color.Transparent);
            g.DrawImage(Princes_Escape.Properties.Resources.Ladder__Wood_, PLANSZA.POLA[0, 0].centrumX - 32, PLANSZA.POLA[0, 0].centrumY - 32, 64, 64);
           
            ////pipi

            if (PLANSZA.POLA[Princess.get_x(), Princess.get_y()].permission == false)
                Princess.back();

            if (PLANSZA.POLA[Princess.get_x(), Princess.get_y()] == PLANSZA.POLA[wielkosc_planszy - 1, wielkosc_planszy - 1])
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        PLANSZA.POLA[i, j].permission = true;
                    }
                }
                stage++;
                label4.Text = stage.ToString();
                Princess.restart(0, 0);
                poziom.Lvl_losuj(stage);

            }
       
            ///// Przeszkody

            for (int w = 0; w < poziom.get_przeszkody().Count; w++)
            {

                g.DrawImage(poziom.get_przeszkody()[w].avatar, PLANSZA.POLA[poziom.get_przeszkody()[w].get_x(), poziom.get_przeszkody()[w].get_y()].centrumX - 32, PLANSZA.POLA[poziom.get_przeszkody()[w].get_x(), poziom.get_przeszkody()[w].get_y()].centrumY - 32, 64, 64);
            }

       

            /// WROGOWIE ////////////////////////////////////////////

            for (int w = 0; w < poziom.get_wrogowie().Count; w++)
            {
                if (PLANSZA.POLA[Princess.get_x(), Princess.get_y()] == PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()])
                {


                    if (poziom.get_wrogowie()[w].get_istnieje() == true)
                    {
                        Princess.zran(poziom.get_wrogowie()[w].atak);
                        lvl_Princess = Princess.get_lvl();
                        Princess.addXP(poziom.get_wrogowie()[w].xp);
                        progressBar1.Maximum = Princess.get_trudnosc();
                        progressBar1.Increment(poziom.get_wrogowie()[w].xp);
                        label2.Text = Princess.get_lvl().ToString();
                        if (lvl_Princess < Princess.get_lvl())
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

                for (int w = 0; w < poziom.get_wrogowie().Count; w++)
            {
                if (poziom.get_wrogowie()[w].get_istnieje() == true)
                    g.DrawImage(poziom.get_wrogowie()[w].avatar, PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()].centrumX - 32, PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()].centrumY - 32, 64, 64);
                else
                    g.DrawImage(poziom.get_wrogowie()[w].avatar_martwy, PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()].centrumX - 32, PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()].centrumY - 32, 64, 64);
            }


            ////////////////////// APTECZKI ///////////////////////////
            for (int a = 0; a < poziom.get_item().Count; a++)
            {
                if (PLANSZA.POLA[Princess.get_x(), Princess.get_y()] == PLANSZA.POLA[poziom.get_item()[a].get_x(), poziom.get_item()[a].get_y()]&& poziom.get_item()[a].get_istnieje()==true)
            {
                poziom.get_item()[a].Akcja(Princess);
            }

                        if (poziom.get_item()[a].get_istnieje() == true)
                            g.DrawImage(poziom.get_item()[a].avatar, PLANSZA.POLA[poziom.get_item()[a].get_x(), poziom.get_item()[a].get_y()].centrumX - 32, PLANSZA.POLA[poziom.get_item()[a].get_x(), poziom.get_item()[a].get_y()].centrumY - 32, 64, 64);
                    }

            for (int i = 0; i < poziom.get_przeszkody().Count; i++)
            {
                PLANSZA.POLA[poziom.get_przeszkody()[i].get_x(), poziom.get_przeszkody()[i].get_y()].permission = false;
            }
            g.DrawImage(Pipi, PLANSZA.POLA[Princess.get_x(), Princess.get_y()].centrumX - 32, PLANSZA.POLA[Princess.get_x(), Princess.get_y()].centrumY - 32, 64, 64);

            g.DrawImage(Properties.Resources.Trapdoor, PLANSZA.POLA[wielkosc_planszy - 1, wielkosc_planszy - 1].centrumX - 32, PLANSZA.POLA[wielkosc_planszy - 1, wielkosc_planszy - 1].centrumY - 32, 64, 64);
                for (int i = 0; Princess.gethp() > i; i++)
                {
                    g.DrawImage(Properties.Resources.Serce, 15, 15 + i * 65, 64, 64);
                }
            for (int i = Princess.gethp(); Princess.get_hp_max() > i; i++)
            {
                g.DrawImage(Properties.Resources.czaszka, 15, 15 + i * 65, 64, 64);
            }
            imgObrazek.Refresh();
                }
            
        private void Gra_Load(object sender, EventArgs e)
        {
            //SoundPlayer Muzyka;
           // Muzyka = new SoundPlayer(Properties.Resources.Muzyka_2);
           // Muzyka.PlayLooping();
            progressBar1.Location = new Point(Width/30,4*Height/5);
            progressBar1.Size = new Size((Width*10)/65, 24);
            label2.Location = new Point(Width / 30, 4*Height / 7);
            label4.Location = new Point(5*Width /6, 4 * Height / 7);
            label2.Parent = imgObrazek;
            label4.Parent = imgObrazek;

            poziom = new Lvl();
            poziom.Lvl_1();
           
            PLANSZA = new Plansza(Height, wielkosc_planszy, (Width - Height) / 2);
            for (int i = 0; i < poziom.get_przeszkody().Count; i++)
            {
                PLANSZA.POLA[poziom.get_przeszkody()[i].get_x(), poziom.get_przeszkody()[i].get_y()].permission = false;
            }
            Princess = new Gracz(0, 0, wielkosc_planszy);
            imgObrazek.Image = new Bitmap(Width, Height);
            g = Graphics.FromImage(imgObrazek.Image);
            l = Graphics.FromImage(imgObrazek.Image);
            
            Pipi = Princes_Escape.Properties.Resources.Princes;
            label2.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            Rysowanie_i_obliczanie();
        }

        private void Losuj_dzwiek_chodzenia() {
            int liczba_losowa;
            Random losuj_krok = new Random();
            liczba_losowa = losuj_krok.Next(1, 6);
            if (liczba_losowa == 1) 
            Krok = new SoundPlayer(Princes_Escape.Properties.Resources.Krok_1);
            else if (liczba_losowa == 2) 
            Krok = new SoundPlayer(Princes_Escape.Properties.Resources.Krok_2);
            else if (liczba_losowa == 3) 
            Krok = new SoundPlayer(Princes_Escape.Properties.Resources.Krok_3);
            else if (liczba_losowa == 4) 
            Krok = new SoundPlayer(Princes_Escape.Properties.Resources.Krok_4);
            else if (liczba_losowa == 5) 
            Krok = new SoundPlayer(Princes_Escape.Properties.Resources.Krok_5);
            else if (liczba_losowa == 6) 
            Krok = new SoundPlayer(Princes_Escape.Properties.Resources.Krok_6);

        }
        private void Gra_KeyDown(object sender, KeyEventArgs e)
        {
            Losuj_dzwiek_chodzenia();
            if (e.KeyCode == Keys.Up)
            {
                Princess.ruch_up();
                Krok.Play();
            }
            else
             if (e.KeyCode == Keys.Down)
            { 
                Princess.ruch_down();
             Krok.Play();
             }
            else
             if (e.KeyCode == Keys.Right) { 
                Princess.ruch_left();
                   Krok.Play();
            }
            else
             if (e.KeyCode == Keys.Left) { 
                Princess.ruch_right();
            Krok.Play();
        }
 
            if (e.KeyCode == Keys.Escape)
                System.Windows.Forms.Application.Exit();

            if (e.KeyCode == Keys.W) { 
                Princess.ruch_up();
                Krok.Play();
            }
            else
            if (e.KeyCode == Keys.S) { 
                Princess.ruch_down();
                Krok.Play();
            }
            else
            if (e.KeyCode == Keys.D) { 
                Princess.ruch_left();
                Krok.Play();
            }
            else
            if (e.KeyCode == Keys.A) { 
                Princess.ruch_right();
                Krok.Play();
            }

            if (e.KeyCode == Keys.Subtract)
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

            if (e.KeyCode == Keys.NumPad0)
            {
                Princess.restart(0, 0);
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        PLANSZA.POLA[i, j].permission = true;
                    }
                }
                poziom.wczytaj_z_pliku();
            }
            lkrokow++;
            Rysowanie_i_obliczanie();
        }
    }
}