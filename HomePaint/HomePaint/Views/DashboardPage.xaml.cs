using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomePaint.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomePaint.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        Room MyRoom = new Room();
        int DoorCounts = 0;
        int WindowRectagleCount = 0;
        int WindowRoundCount = 0;
        public DashboardPage()
        {
            InitializeComponent();
            Init();
        }

        void RoomHeightNotNUll()
        {
            if (!(MyRoom.RoomHeight > 0))
            {
                RoomHeghtSet();
            }
            
        }

        async void RoomHeghtSet()
        {
            
            string a=await DisplayPromptAsync("Szoba magassága", "Szoba magassága Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric);
            MyRoom.RoomHeight = int.Parse(a);
        }

        void Init()
        {
            image_logo.HeightRequest = ViewSetting.IconHeight;
            Btn_Doors.WidthRequest = ViewSetting.Btn_Width;

        }
         async void DoorClicked(object sender, EventArgs e)
        {
            RoomHeightNotNUll();
            string height = await DisplayPromptAsync("Új ajtó hozzáadása","Ajtó magassága Cm-ben","OK",maxLength:3,keyboard:Keyboard.Numeric);
            string width = await DisplayPromptAsync("Új ajtó hozzáadása", "Ajtó szélessége Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);

            try
            {
                

                MyRoom.doors[DoorCounts] = new Door(int.Parse(width),int.Parse(height));
                DoorCounts++;
                Door_Label.Text = $"Ajtó sikeresen hozzáadva.\n\t Összesen: {DoorCounts} Db.";
                
            }
            catch (FormatException)
            {
               await DisplayAlert("Hiba", "Hiba történt az ajtó hozzáadás közben", "Ok.");
            }
            
        }

        void AllDataCounter(object sender, EventArgs e)
        {
           
            Control.Text = "Adatok ellenőrzése....";
            Control.IsVisible = true;
            Thread.Sleep(1000);
            Control.Text = "Ajtók adatainak ellenőrzése...";
            Thread.Sleep(1000);

            RoomControl Rc = new RoomControl();
            Rc.DoorControl(MyRoom.doors);
            Rc.Wait();
            Control.Text = "Ablakok ellenörzése...";
            Rc.Wait(); ;
            Rc.WindowRoundControl(MyRoom.windowRounds);
            Control.Text = "Adatok ellenörzése...";
            Rc.Wait();
            if (Rc.DoorsCount.Equals(DoorCounts)&&Rc.WindRectangleCount.Equals(WindowRectagleCount)&&Rc.WindRoundCount.Equals(WindowRoundCount))
            {
                Control.Text = "Ajtók rendben...";
                Rc.Wait();
                Control.Text += " Ablakok rendben...";
                Rc.Wait(); Rc.Wait(); Rc.Wait();
                Control.Text += " Adatok Rendben.";
            }

        }


        async void WindowClicked(object sender, EventArgs e)
        {
            RoomHeightNotNUll();
            string height = await DisplayPromptAsync("Új ablak hozzáadása", "Ablak magassága Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);
            string width = await DisplayPromptAsync("Új ablak hozzáadása", "Ablak szélessége Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);

            try
            {

                MyRoom.windowRectangles[WindowRectagleCount] = new WindowRectangle(int.Parse(width), int.Parse(height));
                WindowRectagleCount++;
                Window_Label.Text = $"Ablak sikeresen hozzáadva.\n\t Összesen: {WindowRectagleCount + WindowRoundCount} Db.";

            }
            catch (FormatException)
            {
                await DisplayAlert("Hiba", "Hiba történt az ablak hozzáadás közben", "Ok.");
            }
            catch (ArgumentOutOfRangeException)
            {
                await DisplayAlert("Hiba", "Nem lehet több ajtót felvenni.", "Ok");
            }

        }
    }
}