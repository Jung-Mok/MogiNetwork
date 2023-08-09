using MogiNetwork.TCP;
using MogiNetwork.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogiNetwork
{
    public class cService : iSingleton<cService>
    {
        public cService() { }

        private uint counter = 0;

        private Dictionary<uint, iService> dicService = new Dictionary<uint, iService>();

        //T = cSession을 상속 받은 클래스
        public U CreateTCPServer<T, U>() where T : cSession where U : cServer<T>, new()
        {
            





            U server = new U();

            iService service = server as iService;

            if(service == null)
            {
                return null;
            }

            dicService.Add(++counter, service);

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
