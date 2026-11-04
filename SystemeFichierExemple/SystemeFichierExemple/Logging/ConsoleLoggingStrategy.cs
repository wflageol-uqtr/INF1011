using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple.Logging
{
    public class ConsoleLoggingStrategy : ILoggingStrategy
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
