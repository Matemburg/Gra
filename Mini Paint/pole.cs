using System;
using System.Collections.Generic;
using System.Text;

namespace Princes_Escape
{
    class pole
    {
        private int x;
        private int y;
        public int centrumX;
        public int centrumY;
        public int bok;
        public bool permission;
        public bool pusto= true;
        public bool przeciwnik = false;


        public pole(int xx, int yy, int bokk,bool permissionn)
        {
            x = xx;
            y = yy;
            bok = bokk;
            centrumX = x + (bok / 2);
            centrumY = y + (bok / 2);
            permission = permissionn;
        }

        public int getcentrum_x()
        {
            return centrumX;
        }

        public int getcentrum_y()
        {
            return centrumY;
        }
    }
}
