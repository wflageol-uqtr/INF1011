using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public class RootBuilder
    {
        Folder root;

        public RootBuilder(string rootName = "Root")
        {
            root = new Folder(rootName);
        }

        public RootBuilder(Folder root)
        {
            this.root = root;
        }

        public void AddFile(string name)
        {
            File f = new(name);
            root.AddSubElement(f);
        }

        public RootBuilder AddFolder(string name)
        {
            Folder f = new(name);
            root.AddSubElement(f);

            return new RootBuilder(f);
        }

        public Folder ToRoot() => root;
    }
}
