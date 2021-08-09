using System;
using System.Collections.Generic;
using System.Text;
using HomePaint.Data;

namespace HomePaint.Model
{
    public class WindowRound
    {
        public int Diameter { get; set; }
        public double Area { get; set; }

        public WindowRound(int dia)
        {
            Diameter = dia;
            WindowRoundArea();
        }

        public void WindowRoundArea()
        {

            Area = WindowController.RoundArea(Diameter);
        }
    }
}
