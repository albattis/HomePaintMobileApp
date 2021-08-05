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
        }

        void DataScreen(double d)
        {
            
            DataLoad.Text = $"A festékshez szükséges átlagolt festékmennyiség:\n\t\t{d}";

        }
    }
}