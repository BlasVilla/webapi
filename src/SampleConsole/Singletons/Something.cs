using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleConsole.Singletons
{
    public class Something : ISomething
    {
        public int InnerValue { get; private set; }


        public Something()
        {
            InnerValue = 0;
        }

        public int DoSomething(int value)
        {
            var result =  InnerValue + value;
            
            InnerValue = result;

            return result;
        }
    }
}
