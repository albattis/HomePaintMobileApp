using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public DashboardPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            image_logo.HeightRequest = ViewSetting.IconHeight;
            Btn_Doors.WidthRequest = ViewSetting.Btn_Width;

        }
         async void DoorClicked(object sender, EventArgs e)
        {
            string height = await DisplayPromptAsync("Új ajtó hozzáadása","Ajtó magassága Cm-ben","OK",maxLength:3,keyboard:Keyboard.Numeric);
            string width = await DisplayPromptAsync("Új ajtó hozzáadása", "Ajtó szélessége Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);

            try
            {
                MyRoom.doors[MyRoom.DoorCounts] = new Door(int.Parse(width),int.Parse(height));
                Door_Label.Text = $"Ajtó sikeresen hozzáadva: {MyRoom.DoorCounts} Db.";
                
            }
            catch (Exception)
            {
               await DisplayAlert("Hiba", "Hiba történt az ajtó hozzáadás közben", "Ok.");
            }
            
        }

        void AllDataCounter(object sender, EventArgs e)
        {
            DisplayAlert("s", "s", "OK");
        }


        async void WindowClicked(object sender, EventArgs e)
        {
            string height = await DisplayPromptAsync("Új ablak hozzáadása", "Ablak magassága Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);
            string width = await DisplayPromptAsync("Új ablak hozzáadása", "Ablak szélessége Cm-ben", "OK", maxLength: 3, keyboard: Keyboard.Numeric);

            try
            {
                MyRoom.windowRectangles[MyRoom.WindowRectagleCount] = new WindowRectangle(int.Parse(width), int.Parse(height));
                Window_Label.Text = $"Ablak sikeresen hozzáadva: {MyRoom.WindowRectagleCount+MyRoom.WindowRectagleCount} Db.";
            }
            catch (Exception)
            {
                await DisplayAlert("Hiba", "Hiba történt az ablak hozzáadás közben", "Ok.");
            }

        }
    }
}