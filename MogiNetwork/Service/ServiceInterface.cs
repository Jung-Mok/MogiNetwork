using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogiNetwork
{
    public interface iService
    {
        void OnInitialize();
        void OnRelease();
    }
}
