using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public class Folder : IElement, IEnumerable<IElement>
    {
        private List<IElement> subElements = new();

        public string Name { get; }

        public Folder(string name)
        {
            Name = name;
        }

        public void AddSubElement(IElement element)
            => subElements.Add(element);

        public IEnumerator<IElement> GetEnumerator() => subElements.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => subElements.GetEnumerator();

        public void Accept(IElementVisitor visitor)
            => visitor.VisitFolder(this);
    }
}
