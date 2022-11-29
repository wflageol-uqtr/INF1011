using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    class NoLogger : ILogger
    {
        public void WriteLine(string line)
        {
            // NOP
        }
    }
}
