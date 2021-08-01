using System;
using System.Collections.Generic;
using System.Text;
using HomePaint.Data;

namespace HomePaint.Model
{
    public class WindowRectangle : IRectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Areas { get; set; }

        public WindowRectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
           this.Areas = WindowController.RectagleArea(this.Height, this.Width);

        }

    }

    
}
