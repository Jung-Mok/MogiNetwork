using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogiNetwork.TCP
{
    public class cSession
        : cSocket 
    {
        public cSession()
        {

        }

        public virtual void OnConnected() { }
    }
}
