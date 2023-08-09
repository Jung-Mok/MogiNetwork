using MogiNetwork.TCP.Event;
using System;
using System.Net;
using System.Net.Sockets;
using static System.Collections.Specialized.BitVector32;

namespace MogiNetwork.TCP
{
    public abstract class cServer<T>  where T : cSession
        , iService
        , iTcpEvent<T>
        , new()
    {
        public cServer() { }
        private cSocket _listenSocket = null;

        #region iService 재정의
        // 재정의
        public abstract void OnInitialize();
        public abstract void OnRelease();
        #endregion

        #region iTcpEvent 재정의
        // 재정의
        public abstract void OnConnected(T session);
        public abstract void OnDisconnected(T session);
        public abstract void OnReceived(T session, Packet packet);
        #endregion

        #region Start
        public bool Start(string bindIpAddress, ushort bindPort, int prepardSocketCount = 128)
        {
            if(_listenSocket != null) 
            {
                Console.WriteLine("cServer Start Failed : listenSocket is not null");
                return false;
            }

            _listenSocket = new cSocket();

            IPAddress[] ipAddress = Dns.GetHostAddresses(bindIpAddress);
            IPEndPoint endPoint = new IPEndPoint(ipAddress[0], bindPort);

            if(_listenSocket.CreateSocket(endPoint.AddressFamily) == false)
            {
                Console.WriteLine("Server Create Socket Failed");
                return false;
            }

            if (_listenSocket.Bind(endPoint) == false)
            {
                Console.WriteLine("Server Bind Socket Failed");
                return false;
            }

            if (_listenSocket.Listen() == false)
            {
                Console.WriteLine("Server listen Socket Failed");
                return false;
            }

            for(int i=0; i<prepardSocketCount; ++i)
            {
                Accept();
            }

            return true;
        }
        #endregion

        #region Accept
        private bool Accept()
        {
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.Completed += new EventHandler<SocketAsyncEventArgs>(OnAcceptCompleted);
            args.AcceptSocket = null;
            bool pending = _listenSocket.Socket.AcceptAsync(args);

            if (pending == false)
            {
                OnAcceptCompleted(null, args);
            }
            // TODO : 나중에 exception 이 나면.. accept 개수가 줄어들것 같음..
            return true;
        }

        public void OnAcceptCompleted(object sender, SocketAsyncEventArgs args)
        {
            Console.WriteLine("On Accept Completed");

            if (args.SocketError == SocketError.Success)
            {
                T session = new T();

                //session.Start(args.AcceptSocket);
                //session.OnConnected(args.AcceptSocket.RemoteEndPoint);
            }
            else
            {
                System.Console.WriteLine(args.SocketError.ToString());
            }

            Accept();
        }
        #endregion
    }
}
