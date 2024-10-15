using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public interface IFolder : INodeElement
    {
        public IEnumerable<INodeElement> Children { get; }

        public void AddChild(INodeElement element);
    }
}
