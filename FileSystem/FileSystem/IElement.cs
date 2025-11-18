using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public interface IElement
    {
        string Name { get; }

        void Accept(IElementVisitor visitor);
    }
}
