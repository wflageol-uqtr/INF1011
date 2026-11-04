using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple.Logging
{
    public interface ILoggingStrategy
    {
        void Log(string message);
    }
}
