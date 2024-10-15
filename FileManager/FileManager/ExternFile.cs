using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    internal class ExternFile
    {
        private string name;
        public string GetName() => name;

        public ExternFile(string name)
        {
            this.name = name;
        }
    }
}
