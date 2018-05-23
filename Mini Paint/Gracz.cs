using System;
using System.Collections.Generic;
using System.Text;

namespace Princes_Escape
{
    class Gracz
    {

        private int pozycja_x;
        private int pozycja_y;
        public int pozycjapoprzednia_x;
        public int pozycjapoprzednia_y;
        private int wielkosc_planszy;
        private int maxhp = 3;
        private int hp = 3;
        private int xp = 0;
        private int lvl = 1;
        private int trudnosc=5;
        public int monety = 0;
        public bool zmiana_poloenia = false; // wykorzystywane przy lancuchu przy wychodzenniu za krawędź mapy
        public string kierunek;


        public void addXP(int a)
        {
            xp += a;
            checkXP();
        }

        private void checkXP()
        {
            trudnosc = lvl * 5;
            if (xp >= trudnosc)
            {
                xp = 0;
                lvl++;
                if(maxhp<5)
                {
                    maxhp++;
                }
                
                hp = maxhp;
            }
        }
       
        
        public void dajkase(int i)
        {
            monety +=  i;
        }

        public void restart(int x, int y)
        {
            pozycja_x = x;
            pozycja_y = y;
        }
        public void restart()
        {
            pozycja_x = 0;
            pozycja_y = 0;
            pozycjapoprzednia_x = 0;
            pozycjapoprzednia_y = 0;
        }

        public Gracz(int x_start, int y_start, int Wielkosc_Planszy)
        {
            wielkosc_planszy = Wielkosc_Planszy;

            pozycja_x = x_start;
            pozycja_x = y_start;
            pozycjapoprzednia_x = pozycja_x;
            pozycjapoprzednia_y = pozycja_y;
        }

        public void lecz(int ile)
        {
            while (ile > 0 && hp < maxhp)
            {
                hp++;
                ile--;
            }
        }

        public void zran(int ile)
        {
            hp=hp-ile;
            if (hp < 0)
                hp = 0;
        }
        public int gethp()
        {
            return hp;
        }
        public int get_x()
        {
            return pozycja_x;
        }

        public int get_y()
        {
            return pozycja_y;
        }

        public int get_lvl()
        {
            return lvl;
        }
        
        public int get_trudnosc()
        {
            return trudnosc;
        }
        public int get_xp()
        {
            return xp;
        }

        public void ruch_up()
        {

            if (pozycja_y > 0)
            {
                pozycjapoprzednia_x = pozycja_x;
                pozycjapoprzednia_y = pozycja_y;
                pozycja_y--;
                zmiana_poloenia = true;
            }
            kierunek = "up";
        }

        public void ruch_down()
        {

            if (pozycja_y < wielkosc_planszy - 1)
            {
                pozycjapoprzednia_x = pozycja_x;
                pozycjapoprzednia_y = pozycja_y;
                pozycja_y++;
                zmiana_poloenia = true;
            }
            kierunek = "down";
        }

        public void ruch_right()
        {

            if (pozycja_x > 0)
            {
                pozycjapoprzednia_x = pozycja_x;
                pozycjapoprzednia_y = pozycja_y;
                pozycja_x--;
                zmiana_poloenia = true;
                kierunek = "right";
            }

        }

        public void ruch_left()
        {

            if (pozycja_x < wielkosc_planszy - 1)
            {
                pozycjapoprzednia_x = pozycja_x;
                pozycjapoprzednia_y = pozycja_y;
                pozycja_x++;
                zmiana_poloenia = true;
            }
            kierunek = "left";

        }
        public void back()
        {
            pozycja_y = pozycjapoprzednia_y;
            pozycja_x = pozycjapoprzednia_x;
        }
        public int get_hp_max()
        {
            return maxhp;
        }

    }
}
