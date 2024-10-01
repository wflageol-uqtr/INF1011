using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class Folder : NodeElement
    {
        private List<INodeElement> children = new();

        public IEnumerable<INodeElement> Children => children;

        public Folder(string name) : base(name)
        {
        }

        public void AddChild(INodeElement element)
        {
            children.Add(element);
            element.Parent = this;
            ObserverList.Notify();
        }

        public void RemoveChild(INodeElement element)
        {
            children.Remove(element);
            ObserverList.Notify();
        }
    }
}
