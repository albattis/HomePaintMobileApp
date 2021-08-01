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
    public partial class DoorPage : ContentPage
    {
        Door d = new Door();
        
        public DoorPage()
        {
            InitializeComponent();
        }

        void DoorDataSend(object sender, EventArgs e)
        {
            if (DoorHeight.Text != "" && DoorWidth.Text != "")
            {
                try
                {
                    d.Height = int.Parse(DoorHeight.Text);
                    d.Weight = int.Parse(DoorWidth.Text);
                }
                catch (Exception)
                {
                    DisplayAlert("Hiba", "Csak számot lehet megadni.", "O.K.");
                }
                try
                {
                    d.DoorArea();
                }
                catch (DivideByZeroException)
                {
                    DisplayAlert("Hiba", "Hiba történt.", "OK");
                }
            }
            else 
            {
                DisplayAlert("Hiba", "Nem adott meg minden adatot", "OK");
            }
        }

        Door DoorDOne()
        {
            return d;
        }
    }
}