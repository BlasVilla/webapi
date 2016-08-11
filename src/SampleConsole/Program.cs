using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleConsole.Calculations;
using SampleConsole.Singletons;

namespace SampleConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory1 = new CalculatorFactory();

            var app1 = new App(factory1);

            var result = app1.DoStuff();

            Console.WriteLine($"Result is: {result}");
            
            Console.WriteLine("-----------------------");

            var factory2 = new Calculator2Factory();

            var app2 = new App(factory2);

            var result2 = app2.DoStuff();

            Console.WriteLine($"Result is: {result2}");

            Console.ReadKey();
        }
    }
}
