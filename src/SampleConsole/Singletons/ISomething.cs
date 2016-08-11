using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleConsole.Singletons
{
    public interface ISomething
    {
        int InnerValue { get; }
        
        int DoSomething(int value);
    }
}
