using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleConsole.Calculations
{
    public class LoggingCalculator : ICalculator
    {
        private readonly ICalculator _innerCalculator;

        public LoggingCalculator(ICalculator innerCalculator)
        {
            if (innerCalculator == null)
            {
                throw new ArgumentNullException(nameof(innerCalculator));
            }

            _innerCalculator = innerCalculator;
        }

        public int Calculation(int x, int y)
        {
            Console.WriteLine(
                $"[{nameof(LoggingCalculator)}]Input parameters were x = '{x}', y = '{y}'");

            var result = _innerCalculator.Calculation(x, y);

            Console.WriteLine(
                $"[{nameof(LoggingCalculator)}]Output was x = '{result}'");
            
            return result;
        }
    }
}
