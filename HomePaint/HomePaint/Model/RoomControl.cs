using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using HomePaint.Data;

namespace HomePaint.Model
{
    public class RoomControl
    {
        bool[] controldoor = new bool[100];
        bool[] windowrectange = new bool[100];
        bool[] windowround = new bool[100];
        public int DoorsCount = 0;
        public int WindRectangleCount = 0;
        public int WindRoundCount = 0;
        public void Wait()
        {
        Thread.Sleep(10000);
        }

        public void DoorControl(Door[] door)
        {
            for (int i = 0; i < door.Length; i++)
            {
                if (!door[i].Equals(null))
                {
                    controldoor[DoorsCount] = Control.ControlDoor(door[i].Height, door[i].Width, door[i].DoorAreas);
                    DoorsCount++;
                }
            }
        }

        public void WindowRectangleControl(WindowRectangle[] window)
        {
            for (int i = 0; i < window.Length; i++)
            {
                if (!window[i].Equals(null))
                {
                   windowrectange[WindRectangleCount] = Control.ControlWindowRectangle(window[i].Height, window[i].Width, window[i].Areas);
                    WindRectangleCount++;
                    Wait();
                }
            }
        }
        public void WindowRoundControl(WindowRound[] winRound)
        {
            for (int i = 0; i < winRound.Length; i++)
            {
                if (!winRound[i].Equals(null))
                {
                    windowround[WindRoundCount] = Control.ControlWindowRound(winRound[i].Diameter,winRound[i].Area);
                    WindRoundCount++;
                    Wait();
                }
            }
        }

    }
}
