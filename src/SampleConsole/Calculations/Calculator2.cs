using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleConsole.Calculations
{
    public class Calculator2: ICalculator
    {
        public int Calculation(int x, int y)
        {
            return x * y;
        }
    }
}
