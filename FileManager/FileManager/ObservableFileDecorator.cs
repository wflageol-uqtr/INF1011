using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    internal class ObservableFileDecorator : IFile
    {
        public ObserverList ObserverList { get; } = new();

        private IFile target;
        INodeElement? INodeElement.Parent { get => target.Parent; set => target.Parent = value; }

        public string? Content 
        { 
            get => target.Content;
            set 
            {
                target.Content = value;
                ObserverList.Notify();
            }
        }

        public string Name => target.Name;


        public ObservableFileDecorator(IFile target)
        {
            this.target = target;
        }

        public void Accept(INodeVisitor visitor)
        {
            target.Accept(visitor);
        }
    }
}
