using System;
using System.Collections.Generic;
using System.Text;

namespace HomePaint.Model
{
   public class Room
    {
        public int RoomHeight = 0;
        public Door[] doors = new Door[5];
        public WindowRectangle[] windowRectangles = new WindowRectangle[5];
        public WindowRound[] windowRounds = new WindowRound[5];
        public int[]  Wall = new int[4];
        public Room() { }
    }
}
