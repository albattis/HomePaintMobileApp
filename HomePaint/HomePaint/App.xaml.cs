using System;
using System.Threading;
using System.Threading.Tasks;
using HomePaint.Data;
using HomePaint.Model;
using HomePaint.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomePaint
{
    public partial class App : Application
    {
        private static Label labelscreen;
        private static bool hasInternet;
        private static Page currentPage;
        private static Timer timer;
        private static bool noInterShow;

        public App()
        {
            InitializeComponent();

            MainPage = new LogoPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static void StartCheckIfInternet(Label label, Page page)
        {
            labelscreen = label;
            label.Text = ViewSetting.NoInternetText;
            label.IsVisible = false;
            hasInternet = true;
            currentPage = page;
            if (timer == null)
            {
                timer = new Timer((e) =>
                {

                    CheckIfInternetOverTime();
                }, null, 10, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            }
        }

        private static void CheckIfInternetOverTime()
        {
            var NetworkConnection = DependencyService.Get<INetworkConnection>();
            NetworkConnection.CheckNetworkConnection();
            if (!NetworkConnection.Isconnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {

                    if (hasInternet)
                    {
                        if (!noInterShow)
                        {
                            hasInternet = false;
                            labelscreen.IsVisible = true;
                            await ShowDisplayAlert();
                        }
                    }
                });

            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {

                    hasInternet = true;
                    labelscreen.IsVisible = false;
                });
            }
        }

        public static Task<bool> CkechIfInternet()
        {
            var NetworkConnection = DependencyService.Get<INetworkConnection>();
            NetworkConnection.CheckNetworkConnection();
            return Task.FromResult(NetworkConnection.Isconnected);

        }

        public static async Task<bool> CheckIfINternetAlertAsync()
        {
            var NetworkConnection = DependencyService.Get<INetworkConnection>();
            NetworkConnection.CheckNetworkConnection();
            if (!NetworkConnection.Isconnected)
            {
                if (!noInterShow)
                {
                    await ShowDisplayAlert();
                }
                return false;
            }
            return true;
        }

        private static async Task ShowDisplayAlert()
        {
            noInterShow = false;
            await currentPage.DisplayAlert("Internet", "Device has no internet, please reconnect", "OK");
            noInterShow = false;
        }
    }


}
