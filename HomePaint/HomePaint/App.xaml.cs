﻿using System;
using HomePaint.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomePaint
{
    public partial class App : Application
    {
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
    }
}
