using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immo.CSharp.Day7
{
    /*
     * Class Should be sealed
     * Private Constructor
     * Static Instance 
     * Readonly property which return instance
     * (Optional : Thread Safe)
     * (Optional : Lazy Loading)
     */
    public sealed class SimpleSingleton
    {
        private static SimpleSingleton _instance = null;
        private static readonly object _instanceLock = new object();
        public static int Counter { get; set; }
        private SimpleSingleton()
        {
        }

        public static SimpleSingleton Instance
        {
            get
            {
                //Double Check Lock
                if (_instance == null)
                {
                    //Thread Safe
                    lock (_instanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SimpleSingleton();
                            Counter++;
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
