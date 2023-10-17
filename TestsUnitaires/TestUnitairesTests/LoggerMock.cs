using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsUnitaires;

namespace TestUnitairesTests
{
    class LoggerMock : ILogger
    {
        public Stack<string> loggedData = new();

        public void WriteLine(string line)
        {
            loggedData.Push(line);
        }
    }
}
