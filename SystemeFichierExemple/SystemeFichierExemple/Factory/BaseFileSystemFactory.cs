using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple.Factory
{
    public class BaseFileSystemFactory : IFileSystemFactory
    {
        public virtual IMyFile CreateFile(string name, string content)
            => new MyFile(name, content);

        public virtual IFolder CreateFolder(string name)
            => new Folder(name);
    }
}
