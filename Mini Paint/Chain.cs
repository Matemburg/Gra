using System;
using System.Collections.Generic;
using System.Text;

namespace Princes_Escape
{
    class Chain
    {
       public int x;
       public int y;
       public string rodzaj;
       public int nr;
        public string Akcja="";

        public Chain(int xx,int yy)
        {
            x = xx;
            y = yy;
            rodzaj = "0";
            nr = -1;
        }
        public Chain(int xx, int yy,string typ, int numer)
        {
            x = xx;
            y = yy;
            rodzaj = typ;
            nr = numer;
        }

        public Chain(int xx, int yy, string typ, int numer,string akcja)
        {
            x = xx;
            y = yy;
            rodzaj = typ;
            nr = numer;
            Akcja = akcja;
        }

    }
}
