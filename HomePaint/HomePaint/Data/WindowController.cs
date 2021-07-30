using System;
using System.Collections.Generic;
using System.Text;

namespace HomePaint.Data
{
    public class WindowController
    {

        public WindowController() { }

        public int RoundArea(int diameter)
        {
            return int.Parse(((Math.Pow(diameter, 2)) * Math.PI).ToString());
        }

        public int RectagleArea(int h,int w)    
        {
            return h * w;
        }


    }
}
