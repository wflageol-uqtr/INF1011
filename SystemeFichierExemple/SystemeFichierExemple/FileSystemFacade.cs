using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemeFichierExemple.Factory;

namespace SystemeFichierExemple
{
    public class FileSystemFacade
    {
        private IFileSystemFactory factory;
        private IFolder root;

        public FileSystemFacade(IFileSystemFactory factory)
        {
            this.factory = factory;
        }

        public IFolder CreateRoot(string name)
        {
            root = factory.CreateFolder(name);
            return root;
        }

        public IMyFile CreateFile(IFolder parent, string name, string content = "")
        {
            var file = factory.CreateFile(name, content);
            parent.AddSubElement(file);

            return file;
        }

        public IFolder CreateFolder(IFolder parent, string name)
        {
            var folder = factory.CreateFolder(name);
            parent.AddSubElement(folder);
            return folder;
        }
    }
}
