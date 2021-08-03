using System;
using System.Collections.Generic;
using System.Text;

namespace HomePaint.Model
{
   public class Room
    {
        public int RoomHeight = 0;
        public Door[] doors = new Door[100];
        public WindowRectangle[] windowRectangles = new WindowRectangle[100];
        public WindowRound[] windowRounds = new WindowRound[100];
        public int[]  Wall = new int[4];
        public Room() { }
    }
}
