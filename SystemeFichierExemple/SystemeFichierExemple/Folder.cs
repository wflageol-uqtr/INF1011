using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple
{
    public class Folder : Element, IFolder
    {
        private List<IElement> subElements = [];

        public Folder(string name) : base(name)
        {
        }

        public void AddSubElement(IElement element)
            => subElements.Add(element);

        public void RemoveSubElement(IElement element)
            => subElements.Remove(element);

        public override void Print()
        {
            Console.WriteLine(Name);
            foreach (var element in subElements)
                element.Print();
        }
    }
}
