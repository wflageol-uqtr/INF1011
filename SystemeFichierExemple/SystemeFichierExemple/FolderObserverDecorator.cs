using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple
{
    public class FolderObserverDecorator : IFolder
    {
        private IFolder innerFolder;
        private List<IFolderObserver> observers = [];

        public FolderObserverDecorator(IFolder innerFolder)
        {
            this.innerFolder = innerFolder;
        }

        public void AddObserver(IFolderObserver observer)
            => observers.Add(observer);

        public void RemoveObserver(IFolderObserver observer)
            => observers.Remove(observer);

        public string Name => innerFolder.Name;

        public void AddSubElement(IElement element)
        {
            innerFolder.AddSubElement(element);
            foreach (var observer in observers)
                observer.OnAddSubElement(element);
        }

        public void RemoveSubElement(IElement element)
        {
            innerFolder.RemoveSubElement(element);
            foreach(var observer in observers)
                observer.OnRemoveSubElement(element);
        }

        public void Print()
        {
            innerFolder.Print();
        }
    }
}
