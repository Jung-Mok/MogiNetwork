﻿using MogiNetwork;
using MogiNetwork.TCP;

namespace TestServer
{
    class Player : cSession<Player>
    {
        public Player() 
        {
        
        }

        // 재정의
        public override void OnConnected()
        {

        }
    }

    class TestServer: cServer<Player>
    {
        public TestServer() 
        {

        }
        #region iService
        // 재정의
        public override void OnInitialize() 
        {
            Console.WriteLine("Test Server OnInitialize");
        }
        public override void OnRelease() 
        {
            Console.WriteLine("Test Server OnRelease");
        }
        #endregion

        #region iTcpEvent
        // 재정의
        public override void OnConnected(Player session) 
        { 
        
        }
        public override void OnDisconnected(Player session) 
        { 
        
        }
        public override void OnReceived(Player session, Packet packet) 
        { 
        
        }
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hi");

            TestServer server = cService.Instance.CreateTCPServer<TestServer>();

            server.Start("127.0.0.1", 20000);

            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}