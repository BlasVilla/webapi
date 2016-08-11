using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleConsole.Calculations
{
    public class App
    {
        private readonly ICalculatorFactory _factory;

        public App(ICalculatorFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _factory = factory;
        }

        public int DoStuff()
        {
            var calculator = _factory.Create();

            var value1 = 4;
            var value2 = 5;

            var result = calculator.Calculation(value1, value2);

            return result;
        }
    }
}
