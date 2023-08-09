using MogiNetwork.TCP.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogiNetwork.TCP
{
    public abstract class cClient<T>
        : iService
        , iTcpEvent<T>
    {
        #region iService
        // 재정의
        public abstract void OnInitialize();
        public abstract void OnRelease();
        #endregion

        #region iTcpEvent
        // 재정의
        public abstract void OnConnected(T session);
        public abstract void OnDisconnected(T session);
        public abstract void OnReceived(T session, Packet packet);
        #endregion
    }
}
