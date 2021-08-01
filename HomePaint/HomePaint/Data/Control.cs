using System;
using System.Collections.Generic;
using System.Text;

namespace HomePaint.Data
{
    public abstract class Control
    {
       public static bool ControlDoor(int height,int width,int area)
        {

            if (area > 0 && height > 0 && width > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       public static bool ControlWindowRectangle(int height, int width, int areas)
        {
            if (areas > 0 && height > 0 && width > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ControlWindowRound(int d,int t)
        {
            if (d > 0 && t > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
