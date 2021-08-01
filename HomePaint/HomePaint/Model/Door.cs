using System;
using System.Collections.Generic;
using System.Text;
using HomePaint.Data;

namespace HomePaint.Model
{
   public class Door:IRectangle
    {
       
        public int DoorAreas { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Door() { }
        public Door(int wid,int heigh)
        {
            this.Height = heigh;
            this.Width = wid;
            DoorArea();
        }

        public void DoorArea() => DoorAreas = DoorController.AreaCount(this.Height, this.Width);
    }
}
