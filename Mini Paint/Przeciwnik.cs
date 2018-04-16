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
        public Image avatar_martwy = Princes_Escape.Properties.Resources.pajak_ded;



        public Przeciwnik(int x, int y)

        {
            
            pozycja_x = x;
            pozycja_y = y;
            istnieje = true;
            xp = 1;
            atak = 1;
            
        }
        private void Dopasuj_typ(string Avatar)
        {
            if (Avatar == "wąż")
            {

                avatar_martwy = Properties.Resources.waz_ded;
                avatar= Princes_Escape.Properties.Resources.wąż;
            }
            else if (Avatar== "Niebieski_wąż")
            {

                avatar_martwy = Properties.Resources.waz_niebieski_ded;
                avatar = Princes_Escape.Properties.Resources.waz_niebieski;
            }

            else
            {
                avatar = Princes_Escape.Properties.Resources.spider;
                avatar_martwy = Princes_Escape.Properties.Resources.pajak_ded;
            }
    }

        public Przeciwnik(int x, int y,int XP,int ATAK, string Avatar)
        {
            Dopasuj_typ(Avatar);
            atak = ATAK;
            xp = XP;
            pozycja_x = x;
            pozycja_y = y;
            istnieje = true;

        }
        public Przeciwnik(int x, int y,bool waz)
        {
            avatar = Princes_Escape.Properties.Resources.wąż;
            avatar_martwy = Properties.Resources.waz_ded;
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
