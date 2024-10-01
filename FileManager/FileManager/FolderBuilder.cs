using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class FolderBuilder
    {
        private string? name;
        private List<INodeElement> children = new();

        public FolderBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public FolderBuilder AddChild(INodeElement element)
        {
            children.Add(element);
            return this;
        }

        public Folder GetFolder()
        {
            if (name == null)
                throw new InvalidOperationException();

            var folder = new Folder(name);
            foreach (var child in children)
                folder.AddChild(child);

            return folder;
        }
    }
}
