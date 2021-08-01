using System;
using System.Collections.Generic;
using System.Text;

namespace HomePaint.Model
{
   public class Room
    {
        public int RoomHeight { get; set; }
        public Door[] doors;
        public int DoorCounts { get { return doors.Length; }}
       public WindowRectangle[] windowRectangles;
        
        public int WindowRoundCount { get { return windowRounds.Length; } }
       public int WindowRectagleCount { get { return windowRectangles.Length; } }
       public WindowRound[] windowRounds;

        public Room() { }
    }
}
