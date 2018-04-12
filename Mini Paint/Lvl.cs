using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Princes_Escape
{
    class Lvl
    {
        private Przeciwnik[] Wrogowie { get; set; }
        private Item[] Przedmioty { get; set; }
        private Przeszkody[] Przeszkadajki { get; set; }


        public Lvl ()
        {
            Wrogowie = new Przeciwnik[81];
            Przeszkadajki = new Przeszkody[81];
            Przedmioty = new Item[81];
        }
        public void Lvl_1 (){

            Przedmioty[0]=(new Item("apteczka", 2, 2));



            Wrogowie[0] = (new Przeciwnik(2, 3));
            Wrogowie[1] = (new Przeciwnik(4, 4));
            Wrogowie[2] = (new Przeciwnik(7, 7));
            Wrogowie[3] = (new Przeciwnik(7, 8));
            Wrogowie[4] = (new Przeciwnik(8, 7));
            Wrogowie[5] = (new Przeciwnik(6, 7));
            Wrogowie[6] = (new Przeciwnik(6, 6));
            Wrogowie[7] = (new Przeciwnik(7, 4));
            Wrogowie[8] = (new Przeciwnik(5, 8));
            Wrogowie[9] = (new Przeciwnik(8, 5));

            Przeszkadajki[0] = new Przeszkody("lawa", 3, 3);
            Przeszkadajki[1] = new Przeszkody("totem", 3, 4);
            Przeszkadajki[2] = new Przeszkody("stone3", 5, 5);
            Przeszkadajki[3] = new Przeszkody("mstone",5, 6);
            Przeszkadajki[4] = new Przeszkody("pillar", 5, 7);
            Przeszkadajki[5] = new Przeszkody("stone2", 4, 8);


        }


        public void Lvl_2()
        {
            Przedmioty[0].restet();
            Wrogowie[0].restet();
            Przeszkadajki[0].restet();


            Przedmioty[0] = (new Item("apteczka", 2, 2));
            Przedmioty[1] = (new Item("apteczka", 8, 4));



            Wrogowie[0] = (new Przeciwnik(1, 2));
            Wrogowie[1] = (new Przeciwnik(2, 3));
            Wrogowie[2] = (new Przeciwnik(3, 4));
            Wrogowie[3] = (new Przeciwnik(5, 6));
            Wrogowie[4] = (new Przeciwnik(7, 8));
            Wrogowie[5] = (new Przeciwnik(2, 6));
            Wrogowie[6] = (new Przeciwnik(4, 0));
            Wrogowie[7] = (new Przeciwnik(4, 5));
            Wrogowie[8] = (new Przeciwnik(4, 6));
            Wrogowie[9] = (new Przeciwnik(4, 7));
            Wrogowie[10] = (new Przeciwnik(4, 8));
            Wrogowie[11] = (new Przeciwnik(5, 4));
            Wrogowie[12] = (new Przeciwnik(6, 2));
            Wrogowie[13] = (new Przeciwnik(6, 7));
            Wrogowie[14] = (new Przeciwnik(7, 1));
            Wrogowie[15] = (new Przeciwnik(7, 3));
            Wrogowie[16] = (new Przeciwnik(0, 1));
            Wrogowie[17] = (new Przeciwnik(8, 0));
            Wrogowie[18] = (new Przeciwnik(4, 8));
            Wrogowie[19] = (new Przeciwnik(5, 8));
            Wrogowie[20] = (new Przeciwnik(8, 3));
            Wrogowie[21] = (new Przeciwnik(8, 5));
            Wrogowie[22] = (new Przeciwnik(8, 6));

            Przeszkadajki[0] = new Przeszkody("lawa", 3, 3);
            Przeszkadajki[1] = new Przeszkody("stone3", 4, 3);
            Przeszkadajki[2] = new Przeszkody("totem", 5, 3);
            Przeszkadajki[3] = new Przeszkody("ccolumn", 6, 6);
            Przeszkadajki[4] = new Przeszkody("stone1", 5, 7);
            Przeszkadajki[5] = new Przeszkody("ccolumn", 7, 7);


        }

        public void Lvl_losuj(int stage)
        {
            Przedmioty[0].restet();
            Wrogowie[0].restet();
            Przeszkadajki[0].restet();
            Random random = new Random();
            int u;
            int a = 0;
            int b = 0;
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
                    
                        u = random.Next(8);
                    if (i == 0 && j == 0)
                    { }
                    else if (i == 8 && j == 8)
                    { }
                    else if (u == 1)
                    {
                        if (L_apteczka < (2*i)-stage)
                        {
                            Przedmioty[a] = (new Item("apteczka", i, j));
                            a++;
                            L_apteczka++;
                        }
                        else
                        {
                            u++;
                        }
                    }
                    if (u == 2 || u == 3 || u == 5)
                    {
                        if (L_przeciwnik < i+stage)
                        {
                            if (j > 2 || i > 1)


                            {
                                if(u==2)
                                Wrogowie[b] = (new Przeciwnik(i, j));
                                else
                                Wrogowie[b] = (new Przeciwnik(i, j,true));
                                b++;
                                L_przeciwnik++;
                            }

                        }
                        else
                        {
                            u = 4;
                        }
                    }

                     if (u == 4 || u==8)
                    {
                        if (j < 2 || i < 2)
                        {
                            if (j < 7 || i < 7)
                            {
                                if (L_Lava < 2*i)
                                {
                                    System.Random losowanie = new Random(System.DateTime.Now.Millisecond);
                                    int los = losowanie.Next(0, 10);
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
       
     

        public Przeciwnik [] get_wrogowie()
        {
            return Wrogowie;
        }

        public Item[] get_item()
        {
            return Przedmioty;
        }

        public Przeszkody[] get_przeszkody()
        {
            return Przeszkadajki;
        }

    }
}
