using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public class File : IElement
    {
        public string Name { get; }

        public File(string name)
        {
            Name = name;
        }

        public void Accept(IElementVisitor visitor)
            => visitor.VisitFile(this);
    }
}
