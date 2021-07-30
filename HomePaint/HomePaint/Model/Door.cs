using System;
using System.Collections.Generic;
using System.Text;
using HomePaint.Data;

namespace HomePaint.Model
{
   public class Door:IRectangle
    {
       
        public int DoorAreas { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

        public Door()
        {   }

        public void DoorArea()
        {
            DoorController control = new DoorController();
            DoorAreas=control.AreaCount(this.Height,this.Weight);
        }
    }
}
