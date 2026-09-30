using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple
{
    public class LoggingFolder : IFolder
    {
        private IFolder innerFolder;

        public string Name => innerFolder.Name;

        public LoggingFolder(IFolder innerFolder)
        {
            this.innerFolder = innerFolder;
        }

        public void AddSubElement(IElement element)
        {
            innerFolder.AddSubElement(element);
            Console.WriteLine($"{element.Name} ajouté à {innerFolder.Name}.");
        }

        public void RemoveSubElement(IElement element)
        {
            innerFolder.RemoveSubElement(element);
            Console.WriteLine($"{element.Name} supprimé de {innerFolder.Name}.");
        }

        public void Print()
        {
            innerFolder.Print();
        }
    }
}
