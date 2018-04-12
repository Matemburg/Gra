using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Princes_Escape
{
    class Przeciwnik
    {
        private static int Count=0;
        private int pozycja_x;
        private int pozycja_y;
        private bool istnieje;
        public Image avatar = Princes_Escape.Properties.Resources.spider;



        public void restet()
        {
            Count = 0;
        }

        public Przeciwnik(int x, int y)
        {
            
            pozycja_x = x;
            pozycja_y = y;
            istnieje = true;
            Count++;
        }
        public Przeciwnik(int x, int y,bool waz)
        {
            avatar = Princes_Escape.Properties.Resources.wąż;
            pozycja_x = x;
            pozycja_y = y;
            istnieje = true;
            Count++;
        }

        public int get_Count()
        {
            return Count;
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
