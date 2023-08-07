using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogiNetwork.Util
{
    public class iSingleton<T>
    {
        private static readonly Lazy<iSingleton<T>> lazy = new Lazy<iSingleton<T>>(() => new iSingleton<T>());

        public static iSingleton<T> Instance { get { return lazy.Value; } }

        protected iSingleton()
        {
        }
    }
}
