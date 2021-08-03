using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HomePaint.Data;
using Xamarin.Forms.Xaml;

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

        public RoomControl() { }
        public void DoorControl(Door[] door)
        {
           
                for (int i = 0; i < door.Length; i++)
                {
                    if (door[i]!=null)
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
                if (window[i]!=null)
                {
                   windowrectange[WindRectangleCount] = Control.ControlWindowRectangle(window[i].Height, window[i].Width, window[i].Areas);
                    WindRectangleCount++;
                   
                }
            }
        }
        public void WindowRoundControl(WindowRound[] winRound)
        {
            for (int i = 0; i < winRound.Length; i++)
            {
                if (winRound[i]!=null)
                {
                    windowround[WindRoundCount] = Control.ControlWindowRound(winRound[i].Diameter,winRound[i].Area);
                    WindRoundCount++;
                   
                }
            }
        }

        public bool DataSummary(Room room)
        {
            if (room.doors.Length > 0 && room.RoomHeight > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
