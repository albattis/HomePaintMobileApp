using System;
using System.Collections.Generic;
using System.Text;
using HomePaint.Model;

namespace HomePaint.Data
{
    public class PaintCounter
    {
        int RoomTotalArea;
        int DoorTotalArea = 0;
        int WindowRectangleTotalArea=0;
        double WindowRoundTotalArea=0;
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

        void DoorAreaCount()
        {
            for (int i = 0; i < myroom.doors.Length; i++)
            {
                if (myroom.doors[i]!=null)
                { DoorTotalArea += myroom.doors[i].DoorAreas; }
            }
        }
        void RoomCount()
        {
            for (int i = 0; i < myroom.Wall.Length; i++)
            {
                RoomTotalArea += (myroom.Wall[i] * myroom.RoomHeight);
            }
        }
        void WindowsRectangleCount()
        {
            for (int i = 0; i < myroom.windowRectangles.Length; i++)
            {
                if (myroom.windowRectangles[i] != null)
                {
                    WindowRectangleTotalArea += myroom.windowRectangles[i].Areas;
                }
            }
        }
         void WindowsRoundCount()
        {
            for (int i = 0; i < myroom.windowRounds.Length; i++)
            {
                if (myroom.windowRounds[i] != null)
                {
                    WindowRoundTotalArea += myroom.windowRounds[i].Area;
                }
            }
        }

        void PaintCount()
        {
            TotalPaintCount = RoomTotalArea - (DoorTotalArea + WindowRectangleTotalArea + WindowRoundTotalArea);
            TotalPaintCount = TotalPaintCount / 10;
        }
    }
}
