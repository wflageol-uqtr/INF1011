using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple.Logging
{
    public class FileLoggingStrategy : ILoggingStrategy
    {
        private string fileName;
        public FileLoggingStrategy(string fileName) 
        {
            this.fileName = fileName;
        }
        
        public void Log(string message)
        {
            Console.WriteLine($"Fichier {fileName}: {message}");
            //File.AppendAllText(fileName, message);
        }
    }
}
