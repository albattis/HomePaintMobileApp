using System;
using System.Collections.Generic;
using System.Text;
using HomePaint.Model;

namespace HomePaint.Data
{
    public class PaintCounter
    {
        public int RoomTotalArea;
        public int DoorTotalArea;
        public int WindowRectangleTotalArea=0;
        public double WindowRoundTotalArea=0;
        public double TotalPaintCount=0;
        Room myroom;

        public PaintCounter(Room myroom)
        {
            this.myroom = myroom;

            DoorAreaCount();
            RoomCount();
            WindowsRectangleCount();
            WindowsRoundCount();
            PaintCount();
        }
       public void DoorAreaCount()
        {
            for (int i = 0; i < myroom.doors.Length; i++)
            {
                if (myroom.doors[i]!=null)
                { DoorTotalArea += myroom.doors[i].DoorAreas; }
            }
        }
       public void RoomCount()
        {
            for (int i = 0; i < myroom.Wall.Length; i++)
            {
                RoomTotalArea += (myroom.Wall[i] * myroom.RoomHeight);
            }
        }
       public void WindowsRectangleCount()
        {
            for (int i = 0; i < myroom.windowRectangles.Length; i++)
            {
                if (myroom.windowRectangles[i] != null)
                {
                    WindowRectangleTotalArea += myroom.windowRectangles[i].Areas;
                }
            }
        }
       public void WindowsRoundCount()
        {
            for (int i = 0; i < myroom.windowRounds.Length; i++)
            {
                if (myroom.windowRounds[i] != null)
                {
                    WindowRoundTotalArea += myroom.windowRounds[i].Area;
                }
            }
        }
       public void PaintCount()
        {
            TotalPaintCount = RoomTotalArea - (DoorTotalArea + WindowRectangleTotalArea + WindowRoundTotalArea);
            TotalPaintCount = TotalPaintCount / 10;
        }
    }
}
