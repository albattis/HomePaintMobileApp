using System;
using Android.Content;
using Android.Net;
using HomePaint.Droid.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(NetworkConnection))]

namespace HomePaint.Droid.Data
{
    public class NetworkConnection : HomePaint.Data.INetworkConnection
    {
        public bool Isconnected { get; set; }
        [Obsolete]
        public void CheckNetworkConnection()
        {
            var ConnectivityManager = (ConnectivityManager)Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
            var ActiveNetworkInfo = ConnectivityManager.ActiveNetworkInfo;
            if (ActiveNetworkInfo == null && ActiveNetworkInfo.IsConnectedOrConnecting)
            {
                Isconnected = true;
            }
            else {
                Isconnected = false;
                 }
        }
    }
}