using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public abstract class NodeElement : INodeElement
    {
        public INodeElement? Parent { get; set; }
        public string Name { get; }

        protected NodeElement(string name)
        {
            Name = name;
        }

        public virtual string Path() => throw new NotImplementedException();

        public abstract void Accept(INodeVisitor visitor);
    }
}
