using System;
using System.Collections.Generic;
using System.Text;

namespace HomePaint.Data
{
    abstract class DoorController
    {
        public static int AreaCount(int height,int weight)
        {
            return height * weight;
        }
    }
}
