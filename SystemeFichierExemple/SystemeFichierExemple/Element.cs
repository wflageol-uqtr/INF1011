using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple
{
    public abstract class Element : IElement
    {
        public string Name { get; }

        public Element(string name)
        {
            Name = name;
        }

        public abstract void Print();
    }
}
