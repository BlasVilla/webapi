using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleConsole.Calculations
{
    public interface ICalculatorFactory
    {
        ICalculator Create();
    }
}
