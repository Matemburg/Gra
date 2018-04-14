using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Princes_Escape
{
    class Przeciwnik
    {
        public int atak;
        public int xp;
        private int pozycja_x;
        private int pozycja_y;
        private bool istnieje;
        public Image avatar = Princes_Escape.Properties.Resources.spider;



        public Przeciwnik(int x, int y)
        {
            
            pozycja_x = x;
            pozycja_y = y;
            istnieje = true;
            xp = 1;
            atak = 1;
            
        }
        private Image Dopasuj_typ(string avatar)
        {
            if(avatar=="wąż")
                return Princes_Escape.Properties.Resources.wąż;
            else
                return Princes_Escape.Properties.Resources.spider;
    }
        public Przeciwnik(int x, int y,int XP,int ATAK, string Avatar)
        {
            avatar = Dopasuj_typ(Avatar);
            atak = ATAK;
            xp = XP;
            pozycja_x = x;
            pozycja_y = y;
            istnieje = true;

        }
        public Przeciwnik(int x, int y,bool waz)
        {
            avatar = Princes_Escape.Properties.Resources.wąż;
            pozycja_x = x;
            pozycja_y = y;
        }


        public bool get_istnieje()
        {
            return istnieje;
        }


        public void zabij()
        {
            
            istnieje = false;
            
        }

        public int get_x()
        {
            return pozycja_x;
        }

        public int get_y()
        {
            return pozycja_y;
        }
        

        
    }
}
