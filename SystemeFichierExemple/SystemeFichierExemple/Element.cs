using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemeFichierExemple.Visitor;

namespace SystemeFichierExemple
{
    public abstract class Element : IElement
    {
        public string Name { get; }

        public Element(string name)
        {
            Name = name;
        }

        public abstract void Accept(IElementVisitor visitor);
    }
}
