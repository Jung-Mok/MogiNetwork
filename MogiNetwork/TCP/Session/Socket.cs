using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MogiNetwork.TCP
{
    public class cSocket
    {
        public cSocket()
        {

        }

        private Socket _socket = null;

        public Socket Socket { get { return _socket; } set { _socket = value; } }

        public bool CreateSocket(AddressFamily addressFamily)
        {
            if(_socket != null)
            {
                return false;
            }

            _socket = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);

            if(_socket == null)
            {
                Close(SocketShutdown.Both);
                return false;
            }
            
            return true;
        }

        public bool Close(SocketShutdown how) 
        {
            if(_socket == null)
            {
                return false;
            }

            _socket.Shutdown(how);
            _socket.Close();
            _socket = null;

            return true;
        }

        public bool Bind(IPEndPoint endPoint)
        {
            _socket.Bind(endPoint);

            return true;
        }

        public bool Listen(int backlog = 128)
        {
            _socket.Listen(backlog);

            return true;
        }
    }
}
