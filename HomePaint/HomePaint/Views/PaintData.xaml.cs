using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomePaint.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaintData : ContentPage
    {
        public PaintData(double data)
        {
            InitializeComponent();
            DataScreen(data);
        }

        void DataScreen(double d)
        {
            App.StartCheckIfInternet(lbl_Nointernet, this);

            DataLoad.Text = $"A festékshez szükséges átlagolt festékmennyiség:\n\t\t{Math.Round(d)} Liter festék kell.";

        }

        void Back(object sender, EventArgs e)
        {
             Application.Current.MainPage= new DashboardPage();
        }
    }
}