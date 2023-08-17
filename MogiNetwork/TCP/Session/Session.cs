using MogiNetwork.TCP.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Buffers;

namespace MogiNetwork.TCP
{
    public class cSession<T>
        : cSocket 
    {
        private iTcpEvent<T> _tcpEvent = null;

        public cSession()
        {
            _receiveEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnReceiveCompleted);
        }

        public void SetTcpEventInterface(iTcpEvent<T> tcpEvent)
        {
            _tcpEvent = tcpEvent;
        }

        public virtual void OnConnected() { }

        #region Receive 
        private SocketAsyncEventArgs _receiveEventArgs = new SocketAsyncEventArgs();
        private Buffer _receiveBuffer = null;

        public bool RegisterReceive()
        {
            if (Socket == null)
            {
                Console.WriteLine("Register Receive Error");
                return false;
            }

            MemoryPool<byte> memoryPool = MemoryPool<byte>.Shared;
            var buffer = memoryPool.Rent(1024);

            _receiveEventArgs.SetBuffer(buffer.Memory.ToArray(), 0, 1024);

            bool pending = Socket.ReceiveAsync(_receiveEventArgs);

            if(pending == false)
            {
                OnReceiveCompleted(null, _receiveEventArgs);
            }

            return true;
        }
        

        public void OnReceiveCompleted(object sender, SocketAsyncEventArgs args)
        {
            if(args.BytesTransferred > 0 && args.SocketError == SocketError.Success)
            {
                //Socket.
            }

        }
        #endregion
    }
}
