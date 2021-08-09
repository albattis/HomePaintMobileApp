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
        public bool[] controldoor = new bool[5];
        public bool[] windowrectange = new bool[5];
        public bool[] windowround = new bool[5];
        public int DoorsCount { get; set;} 
        public int WindRectangleCount { get; set; }
        public int WindRoundCount { get; set; }
        public double TotalPaint { get; set; }

        public RoomControl() { }
        public void DoorControlAndAreaCount(Door[] door)
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

        public void DataSummary(Room room)
        {
            PaintCounter paint = new PaintCounter(room);
            TotalPaint=(paint.TotalPaintCount/10000);
        }  
    }
}
