using System;
using System.Collections.Generic;
using System.Text;

namespace Princes_Escape
{
    class Plansza
    {
        private int x;
        private int y;
        public pole[,] POLA;

        
        //public pole start;
        // public pole koniec;

        public Plansza(int wymiar, int ilePol, int odstep)
        {
            //   start =POLA [0, 0];
            //  koniec =POLA [ilePol, ilePol];
            x = wymiar;
            y = wymiar;
            POLA = new pole[ilePol, ilePol];
            for (int ix = 0; ix < ilePol; ix++)
            {
                for (int iy = 0; iy < ilePol; iy++)
                {
                    POLA[ix, iy] = new pole((ix * wymiar / ilePol) + odstep, iy * wymiar / ilePol, wymiar / ilePol,true);
                }
            }
        }

       

    }
}
