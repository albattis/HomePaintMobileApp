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

        void RoomHeightNotNUll()
        {
            if (!(MyRoom.RoomHeight > 0))
            {
                RoomHeightSet();
            }

        }

        async void Clear(object sender, EventArgs e)
        {
            MyRoom = new Room();
            await this.DisplayToastAsync("Adatok űritve", 5000);
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
        
        Task WallDelelte()
        {
            MyRoom.Wall = new int[4];
            MyRoom.RoomHeight = 0;
            return Task.CompletedTask;
        }
        Task DoorDelete()
        {
            MyRoom.doors[DoorCounts] = null;
            DoorCounts--;
            
            return Task.CompletedTask;
        }
        Task WindowsRectagleCountDelete()
        {
            MyRoom.windowRectangles[WindowRectagleCount] = null;
            WindowRectagleCount--;
            return Task.CompletedTask;
        }
        Task WindowsRoundCountDelete()
        {
            MyRoom.windowRounds[WindowRoundCount] = null;
            WindowRoundCount--;
            return Task.CompletedTask;
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
            catch (Exception t) {await DisplayAlert("s", $"{t.Message}{t}{MyRoom.doors.Length}", "OK"); }
        }
        async void WindowClicked(object sender, EventArgs e)
        {
            RoomHeightNotNUll();
            string height = await DisplayPromptAsync("Új ablak hozzáadása", "Ablak magassága Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);
            string width = await DisplayPromptAsync("Új ablak hozzáadása", "Ablak szélessége Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);

            try
            {
                if (MyRoom.windowRectangles[WindowRectagleCount] != null)
                {
                    MyRoom.windowRectangles[WindowRectagleCount].Width = int.Parse(width);
                    MyRoom.windowRectangles[WindowRectagleCount].Height = int.Parse(height);
                }
                else { MyRoom.windowRectangles[WindowRectagleCount] = new WindowRectangle(int.Parse(width), int.Parse(height)); }
                Console.WriteLine(WindowRectagleCount);
                var actions = new SnackBarActionOptions
                {
                    Action = () => WindowsRectagleCountDelete(),
                    Text = "Visszavonás"
                };

                var options = new SnackBarOptions
                {
                    MessageOptions = new MessageOptions
                    {
                        Foreground = Color.Black,
                        Message = "Ablak hozzáadva."
                    },
                    BackgroundColor = Color.FromHex("#DE9036"),
                    Duration = TimeSpan.FromSeconds(3),
                    Actions = new[] { actions }
                };
                await this.DisplaySnackBarAsync(options);
                Console.WriteLine(WindowRectagleCount);
                WindowRectagleCount++;
                

            }
            catch (FormatException)
            {
                await DisplayAlert("Hiba", "Hiba történt az ablak hozzáadás közben", "Ok.");
            }
            Console.WriteLine(WindowRectagleCount);

        }
        async void WindowRoundClicked(object sender, EventArgs e)
        {
            RoomHeightNotNUll();
            string Delimiter = await DisplayPromptAsync("Új ablak hozzáadása", "Ablak átmérője Cm-ben", maxLength: 3, keyboard: Keyboard.Numeric);

            try
            {
                MyRoom.windowRounds[WindowRoundCount] = new WindowRound(int.Parse(Delimiter));
                var actions = new SnackBarActionOptions
                {
                    Action = () => WindowsRoundCountDelete() ,
                    Text = "Visszavonás"
                };
                Console.WriteLine(WindowRoundCount);

                var options = new SnackBarOptions
                {
                    MessageOptions = new MessageOptions
                    {
                        Foreground = Color.Black,
                        Message = "Ablak hozzáadva."
                    },
                    BackgroundColor = Color.FromHex("#DE9036"),
                    Duration = TimeSpan.FromSeconds(3),
                    Actions = new[] { actions }
                };
                await this.DisplaySnackBarAsync(options);

                Console.WriteLine(WindowRoundCount);
                WindowRoundCount++;
                
            }
            catch (FormatException)
            {
                await DisplayAlert("Hiba", "Hiba történt az ablak hozzáadás közben", "Ok.");
            }
            catch (ArgumentOutOfRangeException)
            {
                await DisplayAlert("Hiba", "Nem lehet több ajtót felvenni.", "Ok");
            }
            Console.WriteLine(WindowRoundCount);
        }
        async void DoorClicked(object sender, EventArgs e)
        {
            RoomHeightNotNUll();
            string height = await DisplayPromptAsync("Új ajtó hozzáadása", "Ajtó magassága Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);
            string width = await DisplayPromptAsync("Új ajtó hozzáadása", "Ajtó szélessége Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);
            Console.WriteLine(DoorCounts);
            try
            {

                if (MyRoom.doors[DoorCounts] != null)
                {
                    MyRoom.doors[DoorCounts].Height = int.Parse(height);
                    MyRoom.doors[DoorCounts].Width = int.Parse(width);
                }
                else { MyRoom.doors[DoorCounts] = new Door(int.Parse(width), int.Parse(height)); }

                 var actions = new SnackBarActionOptions
                {
                    Action = () => DoorDelete(),
                    Text = "Visszavonás"
                };

                var options = new SnackBarOptions
                {
                    MessageOptions = new MessageOptions
                    {
                        Foreground = Color.Black,
                        Message = "Ajtó hozzáadva."
                    },
                    BackgroundColor = Color.FromHex("#DE9036"),
                    Duration = TimeSpan.FromSeconds(3),
                    Actions = new[] { actions }
                };
                await this.DisplaySnackBarAsync(options);

                DoorCounts++;
                Console.WriteLine(DoorCounts);
            }
            catch (Exception et)
            {
                await DisplayAlert("Hiba", $"Hiba történt az ajtó hozzáadás közben {et}", "Ok.");
            }
            Console.WriteLine(DoorCounts);
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
               
                var actions = new SnackBarActionOptions
                {
                    Action = () => WallDelelte(),
                    Text = "Visszavonás"
                };

                var options = new SnackBarOptions
                {
                    MessageOptions = new MessageOptions
                    {
                        Foreground = Color.Black,
                        Message = "Szoba oldalak hozzáadva."
                    },
                    BackgroundColor = Color.FromHex("#DE9036"),
                    Duration = TimeSpan.FromSeconds(10),
                    Actions = new[] { actions }
                };
                await this.DisplaySnackBarAsync(options);

            }
            catch (Exception a) { await DisplayAlert("error", $"{a}", "Ok"); }

        }
    }
}