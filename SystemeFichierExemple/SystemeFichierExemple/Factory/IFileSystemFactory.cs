using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple.Factory
{
    public interface IFileSystemFactory
    {
        public IMyFile CreateFile(string name, string content);
        public IFolder CreateFolder(string name);
    }
}
