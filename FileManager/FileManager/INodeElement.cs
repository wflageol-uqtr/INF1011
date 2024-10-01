using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public interface INodeElement
    {
        public INodeElement? Parent { get; set; }
        public string Name { get; }
    }
}
