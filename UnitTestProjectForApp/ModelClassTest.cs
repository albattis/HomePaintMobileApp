using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomePaint.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectForApp
{
    [TestClass]
    public class ModelClassTest
    {
        
    }

    [TestClass]

    public class DoorClassTest
    {
        [TestMethod]
        public void DoorTest()
        {
            Door testdoor = new Door(10, 10);
            testdoor.DoorArea();
            Assert.AreEqual(100, testdoor.DoorAreas);
            Assert.AreEqual(10, testdoor.Height);
            Assert.AreEqual(10, testdoor.Width);
        }




    
    }

    [TestClass]
    public class RoomControlClassTest
    {
        [TestMethod]
        public void RoomControlAllTest()
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
            c.DoorControlAndAreaCount(d);
            c.WindowRectangleControl(wr);
            c.WindowRoundControl(wround);

            Assert.AreEqual(true, c.controldoor[0]);
            Assert.AreEqual(false, c.controldoor[1]);
            Assert.AreEqual(true, c.windowrectange[0]);
            Assert.AreEqual(false, c.windowrectange[1]);
            Assert.AreEqual(true, c.windowround[0]);
            Assert.AreEqual(false, c.windowround[1]);
            Assert.AreEqual(1, c.DoorsCount);
            Assert.AreEqual(1, c.WindRoundCount);
            Assert.AreEqual(1, c.WindRectangleCount);
            c.DataSummary(myroom);
            Assert.AreEqual(2, Math.Round(c.TotalPaint));
        }
    }
    [TestClass]
    public class ViewSettingClassTest
    {
        [TestMethod]
        public void SettTest()
        {
            Assert.AreEqual(false, ViewSetting.Btn_Width.Equals(10));
            Assert.AreEqual(200, ViewSetting.Btn_Width);
            Assert.AreEqual(false, ViewSetting.IconHeight.Equals(10));
            Assert.AreEqual(120, ViewSetting.IconHeight);
        }
    }
}
