using System;
using System.Collections.Generic;
using System.Text;

namespace HomePaint.Data
{
    public interface INetworkConnection
    {
        bool Isconnected { get; }
        void CheckNetworkConnection();
    }
}
