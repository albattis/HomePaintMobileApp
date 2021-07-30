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
    public partial class LogoPage : ContentPage
    {
        public LogoPage()
        {
            InitializeComponent();
        }

        void StartProcedure(object sender, EventArgs e)
        {
            DisplayAlert("Induléás", "Xs", "OK");
        }
    }
}