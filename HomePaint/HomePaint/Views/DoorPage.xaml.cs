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
            
        }

       public Door DoorDOne()
        {
            return d;
        }
    }
}