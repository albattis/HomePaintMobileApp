using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomePaint.Model;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
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

        

        async void Clear(object sender, EventArgs e)
        {
            MyRoom = new Room();
            await this.DisplayToastAsync("Adatok űritve", 5000);
        }
        
        void Init()
        {
            Btn_Doors.WidthRequest = ViewSetting.Btn_Width;
            Btn_Doors.IsVisible = false;
            Btn_Window.IsVisible = false;
            Btn_WindowRound.IsVisible = false;
            Competed.IsVisible = false;
        }             
        [Obsolete]
        async void AllDataCounterAsync(object sender, EventArgs e)
        {
           
            RoomControl Rc = new RoomControl();

            try
            {
                Rc.DoorControlAndAreaCount(MyRoom.doors);
                Rc.WindowRectangleControl(MyRoom.windowRectangles);
                Rc.WindowRoundControl(MyRoom.windowRounds);
                if (Rc.DoorsCount.Equals(DoorCounts) && Rc.WindRectangleCount.Equals(WindowRectagleCount) && Rc.WindRoundCount.Equals(WindowRoundCount))
                {
                    if (MyRoom.RoomHeight > 0 && DoorCounts > 0)
                    {
                        Rc.DataSummary(MyRoom);
                        if (Device.OS == TargetPlatform.Android)
                        { Application.Current.MainPage = new NavigationPage(new PaintData(Rc.TotalPaint)); }
                    }
                    else
                    {
                        await this.DisplayToastAsync("Adatok űresek", 5000);
                    }
                }
                else
                {
                    await this.DisplayToastAsync("Adatok űresek", 5000);
                }
            }
            catch (DivideByZeroException) { await this.DisplayToastAsync("Nem lehet 0-át megadni adatnak.", 3000); }
            catch (Exception) { await DisplayAlert("s", "Hiba történt.", "OK"); }
            
        }
        async void WindowClicked(object sender, EventArgs e)
        {
            try
            {
                string height = await DisplayPromptAsync("Új ablak hozzáadása", "Ablak magassága Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);
                string width = await DisplayPromptAsync("Új ablak hozzáadása", "Ablak szélessége Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);
            
                MyRoom.windowRectangles[WindowRectagleCount] = new WindowRectangle(int.Parse(width), int.Parse(height)); 
                await this.DisplayToastAsync("Ablak hozzáadva.", 5000);
                WindowRectagleCount++;
            }
            catch (FormatException)
            {
                await DisplayAlert("Hiba", "Hiba történt az ablak hozzáadás közben", "Ok.");
            }
            

        }
        async void WindowRoundClicked(object sender, EventArgs e)
        {
            try
            {
                string Delimiter = await DisplayPromptAsync("Új ablak hozzáadása", "Ablak átmérője Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric);

                MyRoom.windowRounds[WindowRoundCount] = new WindowRound(int.Parse(Delimiter));
                await this.DisplayToastAsync("Ablak hozzáadva.", 5000);

                WindowRoundCount++;
                
            }
            catch (FormatException)
            {
                await DisplayAlert("Hiba", "Hiba történt az ablak hozzáadás közben", "Ok.");
            }
            catch (ArgumentOutOfRangeException)
            {
                await DisplayAlert("Hiba", "Nem lehet több ablakot felvenni.", "Ok");
            }
            Console.WriteLine(WindowRoundCount);
        }
        async void DoorClicked(object sender, EventArgs e)
        {
            try
            {
                string height = await DisplayPromptAsync("Új ajtó hozzáadása", "Ajtó magassága Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);
                string width = await DisplayPromptAsync("Új ajtó hozzáadása", "Ajtó szélessége Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);

               MyRoom.doors[DoorCounts] = new Door(int.Parse(width), int.Parse(height)); 

                await this.DisplayToastAsync("Ajtó hozzáadva.", 5000);
                DoorCounts++;
                Competed.IsVisible = true;
            }
            catch (Exception)
            {
                await DisplayAlert("Hiba", $"Hiba történt az ajtó hozzáadás közben", "Ok.");
            }   
        }
        async void RoomPAgeAdd(object sender, EventArgs e)
        {
            try
            {
                await DisplayAlert("Figyelmeztetés", "Kedves felhasználó! Elöször a szoba magasságát adja meg. Következö három lépésben peddig a szoba oldalainak szélességét.", "Ok");
            MyRoom.RoomHeight =int.Parse( await DisplayPromptAsync("Szoba magassága", "Szoba magassága Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric));
            MyRoom.Wall[0] = int.Parse(await DisplayPromptAsync("Első fal", "Első fal szélessége Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric));
            MyRoom.Wall[1] = int.Parse(await DisplayPromptAsync("Második fal", "Második fal szélessége Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric));
            MyRoom.Wall[2] = int.Parse(await DisplayPromptAsync("Harmadik fal", "Harmadik fal szélessége Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric));
            MyRoom.Wall[3] = int.Parse(await DisplayPromptAsync("Negyedik fal", "Negyedik fal szélessége Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric));

                await this.DisplayToastAsync("Szoba hozzáadva.", 5000);
                Btn_Doors.IsVisible = true;
                Btn_Window.IsVisible = true;
                Btn_WindowRound.IsVisible = true;

            }
            catch (Exception) { await DisplayAlert("Hiba","Nem sikerült felvenni a Szoba adatait.", "Ok"); }

        }
    }
}