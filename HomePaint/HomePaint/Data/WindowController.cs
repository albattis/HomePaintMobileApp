using System;
using System.Collections.Generic;
using System.Text;

namespace HomePaint.Data
{
     public abstract class WindowController
    {
        public static double RoundArea(int diameter)
        {
            return double.Parse(((Math.Pow((diameter/2), 2)) * Math.PI).ToString());

        }

        public static int RectagleArea(int h, int w)
        {
            return h * w;
        }


    }
}
