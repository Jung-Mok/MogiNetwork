using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogiNetwork.TCP.Event
{
    public interface iTcpEvent<T>
    {
        void OnConnected(T session);
        void OnDisconnected(T session);
        void OnReceived(T session, Packet packet);
    }
}
