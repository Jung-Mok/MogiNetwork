using MogiNetwork.TCP;
using MogiNetwork.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogiNetwork
{
    public class cService : cSingleton<cService>
    {
        public cService() { }

        private uint counter = 0;

        private Dictionary<uint, iService> dicService = new Dictionary<uint, iService>();

        public T CreateTCPServer<T>() where T : iService, new()
        {
            T server = new T();

            dicService.Add(++counter, server);

            server.OnInitialize();

            return server;
        }

        public U CreateTCPClient<T, U>() where T : cSession where U : cClient<T>, new()
        {
            U client = new U();

            dicService.Add(++counter, client);

            client.OnInitialize();

            return client;
        }
    }
}
