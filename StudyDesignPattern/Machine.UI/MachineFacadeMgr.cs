using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Machine.UI
{
    internal class MachineFacadeMgr
    {
        public static IMachineFacade MachineFacade { get; private set; }

        // interface をかませて、facadeを丸々差し替える。
        public MachineFacadeMgr()
        {
            MachineFacade = new MachineFacade();

#if false
            if (false)
            {
                MachineFacade = new DmyMachineFacade();
            }
#endif
        }

        private class DmyMachineFacade : IMachineFacade
        {
            public int BoxExternalTemperature()
            {
                return 0;
            }

            public int BoxInternalTemperature()
            {
                return 10;
            }
        }
    }
}
