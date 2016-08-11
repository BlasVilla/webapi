using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleConsole.Calculations
{
    public class Calculator2Factory : ICalculatorFactory
    {
        public ICalculator Create()
        {
            return new LoggingCalculator(new Calculator2());
        }
    }
}
