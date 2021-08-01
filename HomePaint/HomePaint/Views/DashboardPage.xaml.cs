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
        void DoorClicked(object sender, EventArgs e)
        {
            App.Current.MainPage=new DoorPage();
        }
    }
}