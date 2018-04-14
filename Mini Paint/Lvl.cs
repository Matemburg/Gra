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
        private Przeszkody[] Przeszkadajki { get; set; }


        public Lvl ()
        {
            Wrogowie = new List<Przeciwnik>();
            Przeszkadajki = new Przeszkody[81];
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

            Przeszkadajki[0] = new Przeszkody("lawa", 3, 3);
            Przeszkadajki[1] = new Przeszkody("totem", 3, 4);
            Przeszkadajki[2] = new Przeszkody("stone3", 5, 5);
            Przeszkadajki[3] = new Przeszkody("mstone",5, 6);
            Przeszkadajki[4] = new Przeszkody("pillar", 5, 7);
            Przeszkadajki[5] = new Przeszkody("stone2", 4, 8);

        }

        public void Lvl_losuj(int stage)
        {
            Przedmioty.Clear();
            Wrogowie.Clear();
            Przeszkadajki[0].restet();
            Random random = new Random(DateTime.Now.Millisecond);
            int Liczba_losowa;
            int c = 0;

            int L_przeciwnik = 0;
            int L_apteczka = 0;
            int L_Lava = 0;

            for (int i = 0; i < 9; i++)
                {
                 L_przeciwnik--;
                 L_apteczka--;
                for (int j = 0; j < 9; j++)
                    {
                    Liczba_losowa = random.Next(8);
                    if (i == 0 && j == 0)
                    { }
                    else if (i == 8 && j == 8)
                    { }
                    else if (Liczba_losowa == 1)
                    {
                        if (L_apteczka < (2*i)-stage)
                        {
                            Przedmioty.Add(new Item("apteczka", i, j));
                            L_apteczka++;
                        }
                        else
                            Liczba_losowa = random.Next(2,8);
                    }
                    
                    if (Liczba_losowa == 2 || Liczba_losowa == 3 || Liczba_losowa == 5)
                    {
                        if (L_przeciwnik < i+stage)
                        {
                            if (j > 2 || i > 1)

                            {
                                if(Liczba_losowa == 2)
                                Wrogowie.Add(new Przeciwnik(i, j));
                                else
                                Wrogowie.Add(new Przeciwnik(i, j,2,2,"wąż"));
                                
                                L_przeciwnik++;
                            }
                        }
                        else
                            Liczba_losowa = random.Next(6, 8);
                    }

                     if (Liczba_losowa == 6 || Liczba_losowa == 8)
                    {
                        if (j < 2 || i < 2)
                        {
                            if (j < 7 || i < 7)
                            {
                                if (L_Lava < 2*i)
                                {
                                    Random losowanie_przeszkody = new Random(DateTime.Now.Millisecond);
                                    int los = losowanie_przeszkody.Next(0, 10);
                                    if (los == 1)
                                        Przeszkadajki[c] = new Przeszkody("lawa", i, j);
                                    else if (los == 1)
                                        Przeszkadajki[c] = new Przeszkody("stone1", i, j);
                                    else if (los == 3)
                                        Przeszkadajki[c] = new Przeszkody("stone2", i, j);
                                    else if (los == 4)
                                        Przeszkadajki[c] = new Przeszkody("coffin", i, j);
                                    else if (los == 5)
                                        Przeszkadajki[c] = new Przeszkody("column", i, j);
                                    else if (los == 6)
                                        Przeszkadajki[c] = new Przeszkody("ccolumn", i, j);
                                    else if (los == 7)
                                        Przeszkadajki[c] = new Przeszkody("totem", i, j);
                                    else if (los == 8)
                                        Przeszkadajki[c] = new Przeszkody("mstone", i, j);
                                    else if (los == 9)
                                        Przeszkadajki[c] = new Przeszkody("pillar", i, j);
                                    else
                                        Przeszkadajki[c] = new Przeszkody("stone3", i, j);
                                    c++;
                                    L_Lava++;
                                }
                            }
                        }
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

        public Przeszkody[] get_przeszkody()
        {
            return Przeszkadajki;
        }

    }
}
