using MogiNetwork.TCP.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogiNetwork.TCP
{
    public class cSession<T>
        : cSocket 
    {
        private iTcpEvent<T> _tcpEvent = null;

        public cSession()
        {

        }

        public void SetTcpEventInterface(iTcpEvent<T> tcpEvent)
        {
            _tcpEvent = tcpEvent;
        }

        public virtual void OnConnected() { }
    }
}
