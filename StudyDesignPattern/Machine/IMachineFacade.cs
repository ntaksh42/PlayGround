using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine
{
    public interface IMachineFacade
    {
        int BoxInternalTemperature();
        int BoxExternalTemperature();
    }
}
