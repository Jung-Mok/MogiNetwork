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

        public cServer<T> CreateServer<T, U>()
        {

            return new cServer<T>();
        }
    }
}
