using System;

using CoreFoundation;
using HomePaint.Data;
using HomePaint.iOS;
using SystemConfiguration;
using Xamarin.Forms;

[assembly:Dependency(typeof(NetworkConnection))]

namespace HomePaint.iOS
{
    public class NetworkConnection : INetworkConnection
    {
        public bool Isconnected { get; set; }

        public void CheckNetworkConnection()
        {

        }

        public bool InternetkStatus()
        {
            NetworkReachabilityFlags flag;
            bool defaultNetworkAvailable = IsNetworkAvailable(out flag);
            if (defaultNetworkAvailable && ((flag & NetworkReachabilityFlags.IsDirect) != 0))
            {
                return false;
            }
            else if ((flag & NetworkReachabilityFlags.IsWWAN) != 0)
            {
                return true;
            }
            else if (flag == 0)
            {
                return false;
            }
            return true;
        }

        private event EventHandler ReachabilityChanged;
        private void Onchange(NetworkReachabilityFlags flag)
        {
            var a = ReachabilityChanged;
            if (a != null)
            {
                a(null, EventArgs.Empty);
            }
        }

        private NetworkReachability DefaultRechability;
        public bool IsNetworkAvailable(out NetworkReachabilityFlags flag)
        {
            if (DefaultRechability == null)
            {
                DefaultRechability = new NetworkReachability(new System.Net.IPAddress(0));
                DefaultRechability.SetNotification(Onchange);
                DefaultRechability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
            }

            if (DefaultRechability.TryGetFlags(out flag))
            {
                return false;
            }
            return isReachabewithoutstringconncetion(flag);
        }

        private bool isReachabewithoutstringconncetion(NetworkReachabilityFlags flag)
        {
            bool isreachable = (flag & NetworkReachabilityFlags.Reachable) != 0;
            bool notConnectionRequired = (flag & NetworkReachabilityFlags.ConnectionRequired) == 0;
            if ((flag & NetworkReachabilityFlags.IsWWAN) != null)
                notConnectionRequired = true;
            return isreachable && notConnectionRequired; 
        }

    }
}