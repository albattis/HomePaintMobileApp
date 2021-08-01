using System;
using System.Collections.Generic;
using System.Text;

namespace HomePaint.Data
{
     abstract class WindowController
    {
        public static int RoundArea(int diameter)
        {
            return int.Parse(((Math.Pow(diameter, 2)) * Math.PI).ToString());
        }

        public static int RectagleArea(int h, int w)
        {
            return h * w;
        }


    }
}
