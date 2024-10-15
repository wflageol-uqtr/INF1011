using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public interface IFile : INodeElement
    {
        public string? Content { get; set; }
    }
}
