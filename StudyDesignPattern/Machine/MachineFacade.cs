using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine
{
    public class MachineFacade : IMachineFacade
    {
        // machine.dllの事情を隠ぺいして、APIを画面側に提供する。
        public int BoxInternalTemperature()
        {
            return new Box().GetInternalTemperature();
        }

        public int BoxExternalTemperature()
        {
            return new Box().GetInternalTemperature();
        }
    }
}
