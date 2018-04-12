using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Princes_Escape
{
    class Przeszkody
    {
        private static int Count = 0;
        private string type;
        public int pozycja_x;
        public int pozycja_y;
        public Image avatar;

        public void restet()
        {
            Count = 0;
        }

        public int get_Count()
        {
            return Count;
        }

        public Przeszkody(string Type, int X, int Y)
        {
            pozycja_x = X;
            pozycja_y = Y;
            type = Type;
            if (type == "lawa")
            {              
                    avatar = Princes_Escape.Properties.Resources.Fire;               
            }
            else if(type=="stone1")
            {
                avatar = Princes_Escape.Properties.Resources.Stone1;            
            }
            else if (type == "stone2")
            {
                avatar = Princes_Escape.Properties.Resources.Stone2;
            }
            else if (type == "coffin")
            {
                avatar = Princes_Escape.Properties.Resources.Coffin;
            }
            else if (type == "column")
            {
                avatar = Princes_Escape.Properties.Resources.Column;
            }
            else if (type == "ccolumn")
            {
                avatar = Princes_Escape.Properties.Resources.Crystal_Column;
            }
            else if (type == "totem")
            {
                avatar = Princes_Escape.Properties.Resources.Totem_Pole;
            }
            else if (type == "mstone")
            {
                avatar = Princes_Escape.Properties.Resources.Mossy_Stone__Normal_;
            }
            else if (type == "pillar")
            {
                avatar = Princes_Escape.Properties.Resources.Stone_Pillar__Kazordoon_Ornamented_;
            }
            else if (type == "stone3")
            {
                avatar = Princes_Escape.Properties.Resources.Stone3;
            }
            Count++;
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
