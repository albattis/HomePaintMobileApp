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
                RoomHeightSet();
            }

        }

        async void RoomHeightSet()
        {
            string a = await DisplayPromptAsync("Szoba magassága", "Szoba magassága Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric);
            MyRoom.RoomHeight = int.Parse(a);
        }
        void Init()
        {
            Btn_Doors.WidthRequest = ViewSetting.Btn_Width;
        }
        async void DoorClicked(object sender, EventArgs e)
        {
            RoomHeightNotNUll();
            string height = await DisplayPromptAsync("Új ajtó hozzáadása", "Ajtó magassága Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);
            string width = await DisplayPromptAsync("Új ajtó hozzáadása", "Ajtó szélessége Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);

            try
            {


                MyRoom.doors[DoorCounts] = new Door(int.Parse(width), int.Parse(height));
                DoorCounts++;
                Door_Label.Text = $"Ajtó sikeresen hozzáadva.\n\t Összesen: {DoorCounts} Db.";

            }
            catch (Exception et)
            {
                await DisplayAlert("Hiba", $"Hiba történt az ajtó hozzáadás közben {et}", "Ok.");
            }

        }

        void AllDataCounter(object sender, EventArgs e)
        {

            RoomControl Rc = new RoomControl();
            Control.IsVisible = true;
            try
            {
                Rc.DoorControl(MyRoom.doors);
                Rc.WindowRectangleControl(MyRoom.windowRectangles);
                Rc.WindowRoundControl(MyRoom.windowRounds);


                if (Rc.DoorsCount.Equals(DoorCounts) && Rc.WindRectangleCount.Equals(WindowRectagleCount) && Rc.WindRoundCount.Equals(WindowRoundCount))
                {

                    Control.Text += " Adatok Rendben.";
                }
                else
                {
                    Control.BackgroundColor = Color.Red;
                    Control.TextColor = Color.White;
                    Control.Text = "Sikertelen ellenörzés";

                }

            }
            catch (Exception t) { DisplayAlert("s", $"{t.Message}{t}{MyRoom.doors.Length}", "OK"); }
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
        async void WindowRoundClicked(object sender, EventArgs e)
        {
            RoomHeightNotNUll();
            string Delimiter = await DisplayPromptAsync("Új ablak hozzáadása", "Ablak átmérője Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric);

            try
            {

                MyRoom.windowRounds[WindowRoundCount] = new WindowRound(int.Parse(Delimiter));
                WindowRoundCount++;
                Window_RoundLabel.Text = $"Ablak sikeresen hozzáadva.\n\t Összesen: {WindowRectagleCount + WindowRoundCount} Db.";

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
        async void RoomPAgeAdd(object sender, EventArgs e)
        {
            await DisplayAlert("Figyelmeztetés", "Tisztelt felhazsnáló! Elöször a szoba magasságát adja meg. Következö három lépésben peddig a szoba oldalainak szélességét.", "Ok");
            string Height = await DisplayPromptAsync("Szoba magassága", "Szoba magassága Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric);
            string FirstWidth = await DisplayPromptAsync("Első fal", "Első fal szélessége Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric);
            string SencondWidth = await DisplayPromptAsync("Második fal", "Második fal szélessége Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric);
            string ThirdWidth = await DisplayPromptAsync("Harmadik fal", "Harmadik fal szélessége Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric);
            string FourdWidth = await DisplayPromptAsync("Negyedik fal", "Negyedik fal szélessége Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric);

        }
    }
}