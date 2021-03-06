﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Princes_Escape
{
    class Lvl
    {
        private List<Przeciwnik> Wrogowie;
        private List<Item> Przedmioty;
        private List<Przeszkody> Przeszkadajki;


        public Lvl ()
        {
            Wrogowie = new List<Przeciwnik>();
            Przeszkadajki = new List<Przeszkody>();
            Przedmioty = new List<Item>();
        }
        public void Lvl_1 (){

            Przedmioty.Add(new Item("apteczka", 2, 2));


            Wrogowie.Add(new Przeciwnik(2, 3));
            Wrogowie.Add(new Przeciwnik(4, 4));
            Wrogowie.Add(new Przeciwnik(7, 7));
            Wrogowie.Add(new Przeciwnik(7, 8));
            Wrogowie.Add(new Przeciwnik(8, 7));
            Wrogowie.Add(new Przeciwnik(6, 7));
            Wrogowie.Add(new Przeciwnik(6, 6));
            Wrogowie.Add(new Przeciwnik(7, 4));
            Wrogowie.Add(new Przeciwnik(5, 8));
            Wrogowie.Add(new Przeciwnik(8, 5));

            Przeszkadajki.Add( new Przeszkody("lawa", 3, 3));
            Przeszkadajki.Add(new Przeszkody("totem", 3, 4));
            Przeszkadajki.Add(new Przeszkody("stone3", 5, 5));
            Przeszkadajki.Add(new Przeszkody("mstone",5, 6));
            Przeszkadajki.Add(new Przeszkody("pillar", 5, 7));
            Przeszkadajki.Add(new Przeszkody("stone2", 4, 8));

        }

        public void Lvl_losuj_V2(int stage)
        {
            Przedmioty.Clear();
            Wrogowie.Clear();
            Przeszkadajki.Clear();
            Random random = new Random(DateTime.Now.Millisecond);
            int Liczba_losowa;
            int L_przeciwnik = 0;
            int L_apteczka = 0;
            int L_Lava = 0;
            int L_monet = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Liczba_losowa = random.Next(100);
                    if (i == 0 && j == 0)
                    { }
                    else if (i == 8 && j == 8)
                    { }
                    else if (Liczba_losowa <= 10)
                    {
                        if (L_apteczka < (50-stage)+2)
                        {
                            Przedmioty.Add(new Item("apteczka", i, j));
                            L_apteczka++;
                        }
                        else
                            Liczba_losowa = random.Next(10, 100);
                    }

                    if (10<Liczba_losowa && 50> Liczba_losowa)
                    {
                        if (L_przeciwnik < i + j + (stage / (j + 1)))
                        {
                            if (j > 2 || i > 1)
                            {
                                if (j < 8 || i < 7)
                                {
                                    if (Liczba_losowa % 12 == 0)
                                        Wrogowie.Add(new Przeciwnik(i, j, 2, 2, "wąż"));

                                    else if (Liczba_losowa % 25 == 0)
                                        Wrogowie.Add(new Przeciwnik(i, j, 3, 2, "Niebieski_wąż"));
                                    else if (Liczba_losowa % 8 == 0)
                                        Wrogowie.Add(new Przeciwnik(i, j, 1, 1, "pajak_fioletowy"));

                                    else
                                        Wrogowie.Add(new Przeciwnik(i, j));

                                    L_przeciwnik++;
                                }
                            }
                        }
                        else
                            Liczba_losowa = random.Next(50, 100);
                    }

                    if (50 < Liczba_losowa && 89 > Liczba_losowa)
                    {
                        if (j > 2 || i > 2)
                        {
                            if (j < 7 || i < 7)
                            {
                                if (L_Lava <  3 * j + ((stage-1)/(i+1)))
                                {
                                    Random losowanie_przeszkody = new Random(DateTime.Now.Millisecond);
                                    int los = losowanie_przeszkody.Next(0, 10);
                                    if (los == 1)
                                        Przeszkadajki.Add(new Przeszkody("lawa", i, j));
                                    else if (los == 1)
                                        Przeszkadajki.Add(new Przeszkody("stone1", i, j));
                                    else if (los == 3)
                                        Przeszkadajki.Add(new Przeszkody("stone2", i, j));
                                    else if (los == 4)
                                        Przeszkadajki.Add(new Przeszkody("coffin", i, j));
                                    else if (los == 5)
                                        Przeszkadajki.Add(new Przeszkody("column", i, j));
                                    else if (los == 6)
                                        Przeszkadajki.Add(new Przeszkody("ccolumn", i, j));
                                    else if (los == 7)
                                        Przeszkadajki.Add(new Przeszkody("totem", i, j));
                                    else if (los == 8)
                                        Przeszkadajki.Add(new Przeszkody("mstone", i, j));
                                    else if (los == 9)
                                        Przeszkadajki.Add(new Przeszkody("pillar", i, j));
                                    else
                                        Przeszkadajki.Add(new Przeszkody("stone3", i, j));
                                    L_Lava++;
                                }
                            }
                        }

                        else
                            Liczba_losowa = random.Next(80, 100);
                    }
                    else
                    if (Liczba_losowa > 90)
                        if (L_monet < 4)
                        {
                            if (j > 2 || i > 2)
                            {
                                if (j < 7 || i < 7)
                                {
                                    Przedmioty.Add(new Item("moneta", i, j));
                                    L_monet++;
                                }
                            }
                        }
                }

            }
        }




        public void Lvl_losuj(int stage)
        {
            Przedmioty.Clear();
            Wrogowie.Clear();
            Przeszkadajki.Clear();
            Random random = new Random(DateTime.Now.Millisecond);
            int Liczba_losowa;
     
            int L_przeciwnik = 0;
            int L_apteczka = 0;
            int L_Lava = 0;
            int L_monet = 0;

            for (int i = 0; i < 9; i++)
                {
                 L_przeciwnik--;
                 L_apteczka--;
                for (int j = 0; j < 9; j++)
                {
                    Liczba_losowa = random.Next(10);
                    if (i == 0 && j == 0)
                    { }
                    else if (i == 8 && j == 8)
                    { }
                    else if (Liczba_losowa == 1)
                    {
                        if (L_apteczka < (2 * i) - stage)
                        {
                            Przedmioty.Add(new Item("apteczka", i, j));
                            L_apteczka++;
                        }
                        else
                            Liczba_losowa = random.Next(2, 8);
                    }

                    if (Liczba_losowa == 2 || Liczba_losowa == 3 || Liczba_losowa == 4 || Liczba_losowa == 5)
                    {
                        if (L_przeciwnik < i + stage)
                        {
                            if (j > 2 || i > 1)

                            {
                                if (Liczba_losowa == 2)
                                    Wrogowie.Add(new Przeciwnik(i, j, 2, 2, "wąż"));

                                else if (Liczba_losowa == 3)
                                    Wrogowie.Add(new Przeciwnik(i, j, 3, 2, "Niebieski_wąż"));
                                else if (Liczba_losowa == 4)
                                    Wrogowie.Add(new Przeciwnik(i, j, 1, 1, "pajak_fioletowy"));

                                else
                                    Wrogowie.Add(new Przeciwnik(i, j));

                                L_przeciwnik++;
                            }
                        }
                        else
                            Liczba_losowa = random.Next(6, 10);
                    }

                    if (Liczba_losowa == 6 || Liczba_losowa == 7 || Liczba_losowa == 8)
                    {
                        if (j < 2 || i < 2)
                        {
                            if (j < 7 || i < 7)
                            {
                                if (L_Lava < 2 * j - i)
                                {
                                    Random losowanie_przeszkody = new Random(DateTime.Now.Millisecond);
                                    int los = losowanie_przeszkody.Next(0, 10);
                                    if (los == 1)
                                        Przeszkadajki.Add(new Przeszkody("lawa", i, j));
                                    else if (los == 1)
                                        Przeszkadajki.Add(new Przeszkody("stone1", i, j));
                                    else if (los == 3)
                                        Przeszkadajki.Add(new Przeszkody("stone2", i, j));
                                    else if (los == 4)
                                        Przeszkadajki.Add(new Przeszkody("coffin", i, j));
                                    else if (los == 5)
                                        Przeszkadajki.Add(new Przeszkody("column", i, j));
                                    else if (los == 6)
                                        Przeszkadajki.Add(new Przeszkody("ccolumn", i, j));
                                    else if (los == 7)
                                        Przeszkadajki.Add(new Przeszkody("totem", i, j));
                                    else if (los == 8)
                                        Przeszkadajki.Add(new Przeszkody("mstone", i, j));
                                    else if (los == 9)
                                        Przeszkadajki.Add(new Przeszkody("pillar", i, j));
                                    else
                                        Przeszkadajki.Add(new Przeszkody("stone3", i, j));
                                    L_Lava++;
                                }
                            }
                        }
                    }
                    if (Liczba_losowa == 9)
                        if (L_monet < i-4)
                        {
                            Przedmioty.Add(new Item("moneta", i, j));
                            L_monet++;
                        }
                }
                 
                }
            }
       
     

        public List<Przeciwnik>  get_wrogowie()
        {
            return Wrogowie;
        }

        public List<Item> get_item()
        {
            return Przedmioty;
        }

        public List<Przeszkody> get_przeszkody()
        {
            return Przeszkadajki;
        }

        public void wczytaj_z_pliku()
        {
            Przedmioty.Clear();
            Wrogowie.Clear();
            Przeszkadajki.Clear();
            int linia = 0;
            string poziom = Properties.Resources.Mapy;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (poziom[i * 9 + j + linia] == 'p')
                        Wrogowie.Add(new Przeciwnik(j, i));
                    else if (poziom[i * 9 + j + linia] == 'a')
                        Przedmioty.Add(new Item("apteczka", j, i));
                    else if (poziom[i * 9 + j + linia] == 'l')
                        Przeszkadajki.Add(new Przeszkody("lawa", j, i));
                    else if (poziom[i * 9 + j + linia] == 'w')
                        Wrogowie.Add(new Przeciwnik(j, i, 2, 2, "wąż"));


                }
            }
        }

                 public void wczytaj_z_pliku(string mapa)
        {
            Przedmioty.Clear();
            Wrogowie.Clear();
            Przeszkadajki.Clear();
            int linia = 0;
            string poziom = mapa;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (poziom[i * 9 + j + linia] == 'p')
                        Wrogowie.Add(new Przeciwnik(j, i));
                    else if (poziom[i * 9 + j + linia] == 'a')
                        Przedmioty.Add(new Item("apteczka", j, i));
                    else if (poziom[i * 9 + j + linia] == 'l')
                    {
                        Random losowanie_przeszkody = new Random(DateTime.Now.Millisecond);
                        int los = losowanie_przeszkody.Next(0, 10);
                        if (los == 1)
                            Przeszkadajki.Add(new Przeszkody("lawa", j, i));
                        else if (los == 1)
                            Przeszkadajki.Add(new Przeszkody("stone1", j, i));
                        else if (los == 3)
                            Przeszkadajki.Add(new Przeszkody("stone2", j, i));
                        else if (los == 4)
                            Przeszkadajki.Add(new Przeszkody("coffin", j, i));
                        else if (los == 5)
                            Przeszkadajki.Add(new Przeszkody("column", j, i));
                        else if (los == 6)
                            Przeszkadajki.Add(new Przeszkody("ccolumn", j, i));
                        else if (los == 7)
                            Przeszkadajki.Add(new Przeszkody("totem", j, i));
                        else if (los == 8)
                            Przeszkadajki.Add(new Przeszkody("mstone", j, i));
                        else if (los == 9)
                            Przeszkadajki.Add(new Przeszkody("pillar", j, i));
                        else
                            Przeszkadajki.Add(new Przeszkody("stone3", j, i));
                    }
                    else if (poziom[i * 9 + j + linia] == 'w')
                        Wrogowie.Add(new Przeciwnik(j, i, 2, 2, "wąż"));


                }
                //linia++;

            }
        }
    }
}
