using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Princes_Escape
{
    class Item
    {
        private string type;
        public int pozycja_x;
        public int pozycja_y;
        public Image avatar;
        private bool istnieje = true;

        public void used()
        {
            istnieje = false;
        }


        public bool get_istnieje()
        {
            return istnieje;
        }

        public int get_x()
        {
            return pozycja_x;
        }

        public int get_y()
        {
            return pozycja_y;
        }


        public Item (string Type,int X,int Y)
        {
            pozycja_x = X;
            pozycja_y = Y;
            type = Type;
            if (type == "apteczka")
            {
                avatar = Princes_Escape.Properties.Resources.MEDIC;
            }
        }

        public void Akcja (Gracz A)
        {
            if(type=="apteczka")
            {
                A.lecz(1);
                istnieje = false;
            }
        }
        public void AntyAkcja(Gracz A)
        {
            if (type == "apteczka")
            {
                A.lecz(-1);
                istnieje = true;
            }
        }
}
}
