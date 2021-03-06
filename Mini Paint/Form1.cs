using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;
using System.IO;
using System.Threading;

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
        private bool innyPoziom = false;
        public string nick = "edytor";
        private List<Chain> Lancuch = new List<Chain>();
        Thread thread1;
        DateTime poczatek;
        TimeSpan ts;


        public Gra(string nazwa)
        {
            InitializeComponent();
            nick = nazwa;
        }
        public Gra(bool edytor)
        {
            if (edytor == true)
            {
                innyPoziom = true;
            }
            InitializeComponent();

        }

        private void Rysowanie_i_obliczanie()
        {
            Rysowanie_i_obliczanie("", "");
        }
        private void Rysowanie_i_obliczanie(string akcja)
        {
            Rysowanie_i_obliczanie(akcja, "");
        }
        private void Rysowanie_i_obliczanie(string akcja, string kierunek)
        {
            // thread1.GetApartmentState();
            // backgroundWorker1.InitializeLifetimeService();
            bool back = false;
            bool lancuch_natysowany = false;
            g.Clear(Color.Transparent);
            g.DrawImage(Princes_Escape.Properties.Resources.Ladder__Wood_, PLANSZA.POLA[0, 0].centrumX - 32, PLANSZA.POLA[0, 0].centrumY - 32, 64, 64);

            ////pipi
            //HELLO ITS ME

            if (PLANSZA.POLA[Princess.get_x(), Princess.get_y()].permission == false)
            {
                Princess.back();
                back = true;
            }
            else
            {
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
                    Princess.restart();
                    Lancuch.Clear();
                    poziom.Lvl_losuj_V2(stage);
                    Poziom_Plasza_inicjalizacja();


                }



                /// WROGOWIE ////////////////////////////////////////////
                if (PLANSZA.POLA[Princess.get_x(), Princess.get_y()].pusto == false)
                {
                    if (PLANSZA.POLA[Princess.get_x(), Princess.get_y()].przeciwnik == true)
                    {
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

                                        MessageBox.Show("Koniec GRY" + " Liczba krokow wyniosła " + lkrokow.ToString());
                                        //   Form4.InicjalizacjaDanych();
                                        //MessageBox.Show(nick);
                                        Users.DodajUsera(lkrokow, nick);
                                        
                                        
                                        new Form2().Show();
                                        this.Hide();
                                        thread1.Abort();

                                        
                                        //  System.Windows.Forms.Application.Exit();
                                    }

                                    SoundPlayer simpleSound;
                                    simpleSound = new SoundPlayer(Princes_Escape.Properties.Resources.Kill);
                                    simpleSound.Play();
                                    poziom.get_wrogowie()[w].zabij();
                                    if (Princess.pozycjapoprzednia_x == poziom.get_wrogowie()[w].get_x() || Princess.pozycjapoprzednia_y == poziom.get_wrogowie()[w].get_y())
                                    {
                                        if (akcja == "")
                                        {
                                            lancuch_dodaj(Princess.pozycjapoprzednia_x, Princess.pozycjapoprzednia_y, w, "przeciwnik", kierunek);
                                            lancuch_natysowany = true;

                                        }
                                    }
                                    break;
                                }
                            }
                            label5.Text = string.Format("{0} / {1}", Princess.get_xp(), Princess.get_trudnosc());

                        }

                    }
                    if (PLANSZA.POLA[Princess.get_x(), Princess.get_y()].przedmiot==true)
                    {


                        ////////////////////// APTECZKI ///////////////////////////
                        for (int a = 0; a < poziom.get_item().Count; a++)
                        {
                            if (PLANSZA.POLA[Princess.get_x(), Princess.get_y()] == PLANSZA.POLA[poziom.get_item()[a].get_x(), poziom.get_item()[a].get_y()] && poziom.get_item()[a].get_istnieje() == true)
                            {
                                poziom.get_item()[a].Akcja(Princess);
                                if (Princess.pozycjapoprzednia_x == poziom.get_item()[a].get_x() || Princess.pozycjapoprzednia_y == poziom.get_item()[a].get_y())
                                {
                                    if (akcja == "")
                                    {
                                        lancuch_dodaj(Princess.pozycjapoprzednia_x, Princess.pozycjapoprzednia_y, a, "item", kierunek);
                                        lancuch_natysowany = true;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }


                g.DrawImage(Pipi, PLANSZA.POLA[Princess.get_x(), Princess.get_y()].centrumX - 32, PLANSZA.POLA[Princess.get_x(), Princess.get_y()].centrumY - 32, 64, 64);

                g.DrawImage(Properties.Resources.Trapdoor, PLANSZA.POLA[wielkosc_planszy - 1, wielkosc_planszy - 1].centrumX - 32, PLANSZA.POLA[wielkosc_planszy - 1, wielkosc_planszy - 1].centrumY - 32, 64, 64);
                if (akcja == "")
                {

                    if (back == false)
                    {
                        if (Princess.pozycjapoprzednia_x != Princess.get_x() || Princess.pozycjapoprzednia_y != Princess.get_y())
                        {
                            if (lancuch_natysowany == false)
                            {
                                if (Lancuch.Count == 0)
                                    lancuch_dodaj(Princess.pozycjapoprzednia_x, Princess.pozycjapoprzednia_y, -1, "0", kierunek);
                                else
                                {
                                    // int x = Lancuch[Lancuch.Count - 1].x;
                                    //  MessageBox.Show(x.ToString());
                                    if (Lancuch[Lancuch.Count - 1].x == Princess.get_x() && Lancuch[Lancuch.Count - 1].y == Princess.get_y())
                                    {
                                        lkrokow--;
                                        // MessageBox.Show(Lancuch.Count.ToString());
                                        if (Lancuch[Lancuch.Count - 1].rodzaj == "przeciwnik")
                                        {
                                            poziom.get_wrogowie()[Lancuch[Lancuch.Count - 1].nr].wskrzes();
                                            Princess.lecz(poziom.get_wrogowie()[Lancuch[Lancuch.Count - 1].nr].atak);
                                            Princess.addXP(-(poziom.get_wrogowie()[Lancuch[Lancuch.Count - 1].nr].xp));
                                            progressBar1.Increment(-poziom.get_wrogowie()[Lancuch[Lancuch.Count - 1].nr].xp);
                                        }
                                        if (Lancuch[Lancuch.Count - 1].rodzaj == "item")
                                        {
                                            poziom.get_item()[Lancuch[Lancuch.Count - 1].nr].AntyAkcja(Princess);
                                        }
                                        if (Lancuch[Lancuch.Count - 1].Akcja == "miecz")
                                        {
                                            Princess.dajkase(0);//// MIECZ KASA
                                            for (int w = 0; w < poziom.get_wrogowie().Count; w++)
                                            {
                                                if (Princess.pozycjapoprzednia_x + 1 == poziom.get_wrogowie()[w].get_x() && Princess.pozycjapoprzednia_y == poziom.get_wrogowie()[w].get_y())
                                                    poziom.get_wrogowie()[w].wskrzes();

                                                if (Princess.pozycjapoprzednia_x - 1 == poziom.get_wrogowie()[w].get_x() && Princess.pozycjapoprzednia_y == poziom.get_wrogowie()[w].get_y())
                                                    poziom.get_wrogowie()[w].wskrzes();

                                                if (Princess.pozycjapoprzednia_x == poziom.get_wrogowie()[w].get_x() && Princess.pozycjapoprzednia_y + 1 == poziom.get_wrogowie()[w].get_y())
                                                    poziom.get_wrogowie()[w].wskrzes();

                                                if (Princess.pozycjapoprzednia_x == poziom.get_wrogowie()[w].get_x() && Princess.pozycjapoprzednia_y - 1 == poziom.get_wrogowie()[w].get_y())
                                                    poziom.get_wrogowie()[w].wskrzes();
                                            }
                                        }
                                        if (Lancuch[Lancuch.Count - 1].Akcja == "kilof")
                                        {
                                            Princess.dajkase(0);//// Kilof KASA
                                            for (int w = 0; w < poziom.get_przeszkody().Count; w++)
                                            {
                                                if (Princess.pozycjapoprzednia_x + 1 == poziom.get_przeszkody()[w].get_x() && Princess.pozycjapoprzednia_y == poziom.get_przeszkody()[w].get_y())
                                                    poziom.get_przeszkody()[w].wskrzes();

                                                if (Princess.pozycjapoprzednia_x - 1 == poziom.get_przeszkody()[w].get_x() && Princess.pozycjapoprzednia_y == poziom.get_przeszkody()[w].get_y())
                                                    poziom.get_przeszkody()[w].wskrzes();

                                                if (Princess.pozycjapoprzednia_x == poziom.get_przeszkody()[w].get_x() && Princess.pozycjapoprzednia_y + 1 == poziom.get_przeszkody()[w].get_y())
                                                    poziom.get_przeszkody()[w].wskrzes();

                                                if (Princess.pozycjapoprzednia_x == poziom.get_przeszkody()[w].get_x() && Princess.pozycjapoprzednia_y - 1 == poziom.get_przeszkody()[w].get_y())
                                                    poziom.get_przeszkody()[w].wskrzes();
                                                //imgObrazek.Refresh();
                                            }
                                        }
                                        else if (Lancuch[Lancuch.Count - 1].Akcja == "apteczka")
                                        {
                                            Princess.dajkase(2);
                                            Princess.zran(1);
                                        }
                                        Lancuch.RemoveRange(Lancuch.Count - 1, 1);

                                        if (Lancuch.Count != 0)
                                            PLANSZA.POLA[Lancuch[Lancuch.Count - 1].x, Lancuch[Lancuch.Count - 1].y].permission = true;


                                    }
                                    else
                                    {
                                        lancuch_dodaj(Princess.pozycjapoprzednia_x, Princess.pozycjapoprzednia_y, -1, "0", kierunek);
                                        PLANSZA.POLA[Lancuch[Lancuch.Count - 2].x, Lancuch[Lancuch.Count - 2].y].permission = false;
                                    }
                                }
                            }
                        }
                    }
                }
                label3.Text = Princess.monety.ToString();
                for (int i = 0; Princess.gethp() > i; i++)
                {
                    g.DrawImage(Properties.Resources.Serce, 15, 15 + i * 65, 64, 64);
                }
                for (int i = Princess.gethp(); Princess.get_hp_max() > i; i++)
                {
                    g.DrawImage(Properties.Resources.czaszka, 15, 15 + i * 65, 64, 64);
                }
                for (int a = 0; a < poziom.get_item().Count; a++)
                {
                    if (poziom.get_item()[a].get_istnieje() == true)
                        g.DrawImage(poziom.get_item()[a].avatar, PLANSZA.POLA[poziom.get_item()[a].get_x(), poziom.get_item()[a].get_y()].centrumX - 32, PLANSZA.POLA[poziom.get_item()[a].get_x(), poziom.get_item()[a].get_y()].centrumY - 32, 64, 64);
                }
                for (int w = 0; w < poziom.get_wrogowie().Count; w++)
                {
                    if (poziom.get_wrogowie()[w].get_istnieje() == true)
                        g.DrawImage(poziom.get_wrogowie()[w].avatar, PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()].centrumX - 32, PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()].centrumY - 32, 64, 64);
                    else
                        g.DrawImage(poziom.get_wrogowie()[w].avatar_martwy, PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()].centrumX - 32, PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()].centrumY - 32, 64, 64);
                }

                for (int i = 0; i < Lancuch.Count - 1; i++)
                {
                    PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].permission = false;
                }

                ///// Przeszkody

                for (int w = 0; w < poziom.get_przeszkody().Count; w++)
                {
                    if (poziom.get_przeszkody()[w].get_istnieje() == true)
                        g.DrawImage(poziom.get_przeszkody()[w].avatar, PLANSZA.POLA[poziom.get_przeszkody()[w].get_x(), poziom.get_przeszkody()[w].get_y()].centrumX - 32, PLANSZA.POLA[poziom.get_przeszkody()[w].get_x(), poziom.get_przeszkody()[w].get_y()].centrumY - 32, 64, 64);
                }



                for (int i = 0; i < Lancuch.Count; i++)
                {
                    if (Lancuch[i].kierunek == "left")
                        g.DrawImage(Properties.Resources.chain, PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].getcentrum_x(), PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].getcentrum_y() - (PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok / 2), PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok, PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok);
                    if (Lancuch[i].kierunek == "right")
                        g.DrawImage(Properties.Resources.chain, PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].getcentrum_x() - PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok, PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].getcentrum_y() - (PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok / 2), PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok, PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok);
                    if (Lancuch[i].kierunek == "down")
                        g.DrawImage(Properties.Resources.chain1, PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].getcentrum_x() - (PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok / 2), PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].getcentrum_y(), PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok, PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok);
                    if (Lancuch[i].kierunek == "up")
                        g.DrawImage(Properties.Resources.chain1, PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].getcentrum_x() - (PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok / 2), PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].getcentrum_y() - PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok, PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok, PLANSZA.POLA[Lancuch[i].x, Lancuch[i].y].bok);
                }
                ts = DateTime.Now - poczatek;
                label7.Text = ts.ToString();
                imgObrazek.Refresh();
            }
        }

        private void Gra_Load(object sender, EventArgs e)
        {
            //SoundPlayer Muzyka;
            //Muzyka = new SoundPlayer(Properties.Resources.Muzyka_2);
            // Muzyka.PlayLooping();
            // WaveOut muzyka = new WaveOut();
            //MemoryStream mp3file = new MemoryStream(Properties.Resources.Motivated);
            //Mp3FileReader mp3reader = new Mp3FileReader(mp3file);

            //muzyka.Init(mp3reader);
            poczatek = new DateTime(DateTime.Now.Ticks);
            timer1.Start();
            thread1 = new Thread(Muzyka.Play);
             thread1.Start();
            backgroundWorker1.RunWorkerAsync();
            pictureBox2.Parent = imgObrazek;
            pictureBox3.Parent = imgObrazek;
            label2.Parent = imgObrazek;
            label1.Parent = imgObrazek;
            label3.Parent = imgObrazek;
            pictureBox1.Location = new Point(Width - 3 * 64 - 3 * 5, Height - 110);
            pictureBox2.Location = new Point(Width - 2 * 64 - 2 * 5, Height - 110);
            pictureBox3.Location = new Point(Width - 1 * 64 - 1 * 5, Height - 110);
            pictureBox4.Location = new Point(Width - 22 * 64 - 1 * 5, Height - (Height - 20));
            pictureBox1.Image = new Bitmap(64, 64);
            pictureBox2.Image = new Bitmap(64, 64);
            pictureBox3.Image = new Bitmap(64, 64);
            pictureBox4.Image = new Bitmap(64, 64);
            Graphics p1 = Graphics.FromImage(pictureBox1.Image);
            Graphics p2 = Graphics.FromImage(pictureBox2.Image);
            Graphics p3 = Graphics.FromImage(pictureBox3.Image);
            Graphics p4 = Graphics.FromImage(pictureBox4.Image);
            pictureBox1.Parent = imgObrazek;
            pictureBox4.Parent = imgObrazek;
            p1.Clear(Color.Transparent);
            p1.DrawImage(Properties.Resources.MEDIC, 0, 0, 64, 64);
            p2.Clear(Color.Transparent);
            p2.DrawImage(Properties.Resources.katana, 0, 0, 64, 64);
            p3.Clear(Color.Transparent);
            p3.DrawImage(Properties.Resources.Diamond_Pickaxe_icon, 0, 0, 64, 64);
            p4.Clear(Color.Transparent);
            p4.DrawImage(Properties.Resources.moneta_1, 0, 0, 64, 64);
            progressBar1.Location = new Point(Width / 30, 4 * Height / 5);
            progressBar1.Size = new Size((Width * 10) / 65, 50);
            label2.Location = new Point(Width / 29+35, 4 * Height / 7);
            label1.Location = new Point(Width - 330, Height - 50);
            label4.Location = new Point(Width -250, 4 * Height / 7);
            label3.Location = new Point(Width - 21 * 64 - 1 * 5, Height - (Height - 30));
            label5.Location = new Point(Width / 13, 4 * Height / 5 + 60);
            label6.Location = new Point(Width - 330, Height - 150);
            label2.Parent = imgObrazek;
            label1.Parent = imgObrazek;
            label4.Parent = imgObrazek;
            label5.Parent = imgObrazek;
            label6.Parent = imgObrazek;
            label7.Parent = imgObrazek;

            if (innyPoziom == false)
            {
                poziom = new Lvl();
                poziom.Lvl_1();
            }
            else
            {
                poziom = new Lvl();
                poziom_z_pliku();
            }
            PLANSZA = new Plansza(Height, wielkosc_planszy, (Width - Height) / 2);
            for (int i = 0; i < poziom.get_przeszkody().Count; i++)
            {
                PLANSZA.POLA[poziom.get_przeszkody()[i].get_x(), poziom.get_przeszkody()[i].get_y()].permission = false;
            }
            Princess = new Gracz(0, 0, wielkosc_planszy);
            imgObrazek.Image = new Bitmap(Width, Height);
            g = Graphics.FromImage(imgObrazek.Image);
            l = Graphics.FromImage(imgObrazek.Image);
            int x = new Random().Next(3);
            if (x == 0) 
            Pipi = Princes_Escape.Properties.Resources.Princes;
            if (x == 1)
            Pipi = Princes_Escape.Properties.Resources.KK_2;
            else
            Pipi = Princes_Escape.Properties.Resources.księżniczka_3;
            label2.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            // lancuch_dodaj(0, 0, 0, "0");
            Rysowanie_i_obliczanie();
            Poziom_Plasza_inicjalizacja();

        }

        private void lancuch_dodaj(int x, int y, int nr, string type, string kierunek)
        {
            Lancuch.Add(new Chain(kierunek, x, y, type, nr));

        }

        private void Losuj_dzwiek_chodzenia()
        {
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
        private void atakmieczem()
        {
            int koszt = 3;
            if (Princess.monety >= koszt)
            {
                Princess.dajkase(-koszt);
                for (int w = 0; w < poziom.get_wrogowie().Count; w++)
                {
                    if (Princess.get_x() + 1 == poziom.get_wrogowie()[w].get_x() && Princess.get_y() == poziom.get_wrogowie()[w].get_y())
                        if (poziom.get_wrogowie()[w].get_istnieje() == true)
                            poziom.get_wrogowie()[w].zabij();

                    if (Princess.get_x() - 1 == poziom.get_wrogowie()[w].get_x() && Princess.get_y() == poziom.get_wrogowie()[w].get_y())
                        if (poziom.get_wrogowie()[w].get_istnieje() == true)
                            poziom.get_wrogowie()[w].zabij();

                    if (Princess.get_x() == poziom.get_wrogowie()[w].get_x() && Princess.get_y() + 1 == poziom.get_wrogowie()[w].get_y())
                        if (poziom.get_wrogowie()[w].get_istnieje() == true)
                            poziom.get_wrogowie()[w].zabij();

                    if (Princess.get_x() == poziom.get_wrogowie()[w].get_x() && Princess.get_y() - 1 == poziom.get_wrogowie()[w].get_y())
                        if (poziom.get_wrogowie()[w].get_istnieje() == true)
                            poziom.get_wrogowie()[w].zabij();
                    Lancuch[Lancuch.Count - 1].Akcja = "miecz";

                }
                Rysowanie_i_obliczanie("miecz");
            }
        }

        private void uderzeniekilofem()
        {
            int koszt = 3;
            if (Princess.monety >= koszt)
            {
                Princess.dajkase(-koszt);
                for (int w = 0; w < poziom.get_przeszkody().Count; w++)
                {
                    if (Princess.get_x() + 1 == poziom.get_przeszkody()[w].get_x() && Princess.get_y() == poziom.get_przeszkody()[w].get_y())
                        if (poziom.get_przeszkody()[w].get_istnieje() == true)
                            poziom.get_przeszkody()[w].zabij();

                    if (Princess.get_x() - 1 == poziom.get_przeszkody()[w].get_x() && Princess.get_y() == poziom.get_przeszkody()[w].get_y())
                        if (poziom.get_przeszkody()[w].get_istnieje() == true)
                            poziom.get_przeszkody()[w].zabij();

                    if (Princess.get_x() == poziom.get_przeszkody()[w].get_x() && Princess.get_y() + 1 == poziom.get_przeszkody()[w].get_y())
                        if (poziom.get_przeszkody()[w].get_istnieje() == true)
                            poziom.get_przeszkody()[w].zabij();

                    if (Princess.get_x() == poziom.get_przeszkody()[w].get_x() && Princess.get_y() - 1 == poziom.get_przeszkody()[w].get_y())
                        if (poziom.get_przeszkody()[w].get_istnieje() == true)
                            poziom.get_przeszkody()[w].zabij();
                    PLANSZA.POLA[poziom.get_przeszkody()[w].get_x(), poziom.get_przeszkody()[w].get_y()].permission = true;
                    Lancuch[Lancuch.Count - 1].Akcja = "kilof";

                }
                Rysowanie_i_obliczanie("kilof");
            }
        }
        private void leczenieapteczkaz()
        {
            if (Princess.monety >= 2)
            {
                Princess.dajkase(-2);
                Princess.lecz(1);
                Rysowanie_i_obliczanie("apteczka");
            }
        }
        private void Gra_KeyDown(object sender, KeyEventArgs e)
        {
            //label5.Text = string.Format("{0} / {1}", Princess.get_xp(), Princess.get_trudnosc());
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
             if (e.KeyCode == Keys.Right)
            {
                Princess.ruch_left();
                Krok.Play();
            }
            else
             if (e.KeyCode == Keys.Left)
            {
                Princess.ruch_right();
                Krok.Play();
            }

            if (e.KeyCode == Keys.Escape)
            {
                thread1.Abort();
                System.Windows.Forms.Application.Exit();
            }
            if (e.KeyCode == Keys.W)
            {
                Princess.ruch_up();
                Krok.Play();
            }
            else
            if (e.KeyCode == Keys.S)
            {
                Princess.ruch_down();
                Krok.Play();
            }
            else
            if (e.KeyCode == Keys.D)
            {
                Princess.ruch_left();
                Krok.Play();
            }
            else
            if (e.KeyCode == Keys.A)
            {
                Princess.ruch_right();
                Krok.Play();
            }
            if (e.KeyCode == Keys.Add)
            {
                stage++;
            }
            else
            if (e.KeyCode == Keys.Z)
            {
                leczenieapteczkaz();
            }
            else
            if (e.KeyCode == Keys.X)
            {
                atakmieczem();
            }
            else
            if (e.KeyCode == Keys.C)
            {
                uderzeniekilofem();
            }
            else
            if (e.KeyCode == Keys.Subtract)
            {
                Princess.restart();
                Lancuch.Clear();

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        PLANSZA.POLA[i, j].permission = true;
                    }
                }
                poziom.Lvl_losuj_V2(stage);
                Poziom_Plasza_inicjalizacja();
                Rysowanie_i_obliczanie("mapa");


            }
            else
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
                Rysowanie_i_obliczanie("mapa");
            }
            else
            if (e.KeyCode == Keys.NumPad5)
            {
                Princess.restart(0, 0);
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        PLANSZA.POLA[i, j].permission = true;
                    }
                }
                string mapy = File.ReadAllText(@"mapy.txt");
                poziom.wczytaj_z_pliku(mapy);
                Rysowanie_i_obliczanie("mapa");
            }
            if (Princess.zmiana_poloenia == true)
            {
                lkrokow++;
                Rysowanie_i_obliczanie("", Princess.kierunek);
                Princess.zmiana_poloenia = false;

            }
            label5.Text = string.Format("{0} / {1}", Princess.get_xp(), Princess.get_trudnosc());

            if (e.KeyCode == Keys.NumPad9)
            {
                Poziom_Plasza_inicjalizacja();
            }
        }



        public void Poziom_Plasza_inicjalizacja()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    PLANSZA.POLA[i, j].pusto = true; ;
                }
            }

            for (int w = 0; w < poziom.get_wrogowie().Count; w++)
            {
                PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()].pusto = false;
                PLANSZA.POLA[poziom.get_wrogowie()[w].get_x(), poziom.get_wrogowie()[w].get_y()].przeciwnik = true;
            }
            for (int w = 0; w < poziom.get_item().Count; w++)
            {
                PLANSZA.POLA[poziom.get_item()[w].get_x(), poziom.get_item()[w].get_y()].pusto = false;
                PLANSZA.POLA[poziom.get_item()[w].get_x(), poziom.get_item()[w].get_y()].przedmiot = true;
            }
            for (int i = 0; i < poziom.get_przeszkody().Count; i++)
            {
                if (poziom.get_przeszkody()[i].get_istnieje() == true)
                    PLANSZA.POLA[poziom.get_przeszkody()[i].get_x(), poziom.get_przeszkody()[i].get_y()].permission = false;
            }

        }

        public void poziom_z_pliku()
        {
            string mapy = File.ReadAllText(@"mapy.txt");
            poziom.wczytaj_z_pliku(mapy);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            leczenieapteczkaz();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            atakmieczem();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            uderzeniekilofem();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
                // string test;
            ts = DateTime.Now - poczatek;
            label7.Text = ts.ToString();
            
        }
    }
}