using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemeFichierExemple.Logging;

namespace SystemeFichierExemple
{
    public class Configuration
    {
        public static Configuration Singleton { get; } = new Configuration();
        private Configuration() { }

        public ILoggingStrategy Logging { get; set; } = new ConsoleLoggingStrategy();
    }
}
