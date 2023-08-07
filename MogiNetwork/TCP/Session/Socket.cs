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
        public Socket socket { get { return this.socket; } private set { this.socket = value; } }

        public bool CreateSocket(AddressFamily addressFamily)
        {
            if(this.socket == null)
            {
                return false;
            }

            this.socket = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);

            if(this.socket == null)
            {
                this.Close(SocketShutdown.Both);
                return false;
            }
            
            return true;
        }

        public bool Close(SocketShutdown how) 
        {
            if(this.socket == null)
            {
                return false;
            }

            this.socket.Shutdown(how);
            this.socket.Close();
            this.socket = null;

            return true;
        }
    }
}
