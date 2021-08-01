using System;
using System.Collections.Generic;
using System.Text;

namespace HomePaint.Model
{
   public class Room
    {
        int RoomHeight { get; set; }
        Door[] doors;
        WindowRectangle[] windowRectangles;
        WindowRound[] windowRounds;

        public Room() { }
    }
}
