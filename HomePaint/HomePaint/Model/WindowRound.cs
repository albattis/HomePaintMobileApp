using System;
using System.Collections.Generic;
using System.Text;
using HomePaint.Data;

namespace HomePaint.Model
{
    public class WindowRound
    {
        public int Diameter { get; set; }
        public int Area { get; set; }

        public WindowRound() { }

        public void WindowRoundArea()
        {
            WindowController window = new WindowController();
            Area = window.RoundArea(Diameter);
        }
    }
}
