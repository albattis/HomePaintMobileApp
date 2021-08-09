using System;
using HomePaint.Data;
using HomePaint.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectForApp
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    [TestClass]

    public class Controll
    {
        [TestMethod]

        public void ControlDataDoors()
        {

            Assert.AreEqual(true, Control.ControlDoor(1, 1, 1));
            Assert.AreEqual(false, Control.ControlDoor(0, 1, 1));
            Assert.AreEqual(false, Control.ControlDoor(0, 0, 0));
            Assert.AreEqual(true, Control.ControlDoor(310, 100, 310000));
            
        }

        [TestMethod]
        public void ControlDataWindow()
        {
            Assert.AreEqual(true, Control.ControlWindowRectangle(1, 1, 2));
            Assert.AreEqual(false, Control.ControlWindowRectangle(0, 1, 2));
            Assert.AreEqual(false, Control.ControlWindowRectangle(0,0,0));
            Assert.AreEqual(true, Control.ControlWindowRectangle(100, 100, 100000));

            Assert.AreEqual(true, Control.ControlWindowRound(100, 134.00));
            Assert.AreEqual(false, Control.ControlWindowRound(0, 134.00));
            Assert.AreEqual(false, Control.ControlWindowRound(0,0));
            Assert.AreEqual(true, Control.ControlWindowRound(1,1));
        }


        
    }
    [TestClass]
    public class DoorControllers
    {
        [TestMethod]
        public void DoorControlArea()
            {
            Assert.AreEqual(0, DoorController.AreaCount(0, 10));
            Assert.AreEqual(0, DoorController.AreaCount(0, 0));
            Assert.AreEqual(100, DoorController.AreaCount(10, 10));
            }
    }

    [TestClass]
    public class PaintCounterTest
    {
        [TestMethod]
       public void AllMethodsTest()
        {
            RoomControl c = new RoomControl();
            WindowRectangle[] wr = new WindowRectangle[5];
            WindowRound[] wround = new WindowRound[5];
            Door[] d = new Door[5];
            int[] w = new int[4];

            d[0] = new Door(210, 100);
            wr[0] = new WindowRectangle(210, 200);
            wround[0] = new WindowRound(100);
            w[0] = 210;
            w[1] = 230;
            w[2] = 210;
            w[3] = 230;

            Room myroom = new Room
            {
                RoomHeight = 320,
                doors = d,
                Wall = w,
                windowRectangles = wr,
                windowRounds = wround
            };

            PaintCounter p = new PaintCounter(myroom);
            p.DoorTotalArea = 0;
            p.RoomTotalArea = 0;
            p.WindowRectangleTotalArea = 0;
            p.WindowRoundTotalArea = 0;

            p.DoorAreaCount();
            p.RoomCount();
            p.WindowsRectangleCount();
            p.WindowsRoundCount();
            p.PaintCount();
            
            Assert.AreEqual(21000, p.DoorTotalArea);
            Assert.AreEqual(281600, p.RoomTotalArea);
            Assert.AreEqual(42000, p.WindowRectangleTotalArea);
            Assert.AreEqual(7854, Math.Round(p.WindowRoundTotalArea));
            Assert.AreEqual(21075, Math.Round(p.TotalPaintCount));
           
        }
    

    }

    [TestClass]

    public class WindowControllerTest
    {

        [TestMethod]

        public void WindowCount()
        {
            Assert.AreEqual(7854,Math.Round(WindowController.RoundArea(100)));
            Assert.AreEqual(0, WindowController.RoundArea(0));
            Assert.AreEqual(100, WindowController.RectagleArea(10, 10));
            

        }
    }
}
