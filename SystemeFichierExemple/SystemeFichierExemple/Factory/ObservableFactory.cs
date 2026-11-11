using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple.Factory
{
    internal class ObservableFactory : BaseFileSystemFactory
    {
        private IEnumerable<IFolderObserver> folderObservers;

        public ObservableFactory(IEnumerable<IFolderObserver> folderObservers)
        {
            this.folderObservers = folderObservers;
        }

        public override IMyFile CreateFile(string name, string content)
        {
            var file = base.CreateFile(name, content);
            // TODO: Add observable state to File.
            return file;
        }

        public override IFolder CreateFolder(string name)
        {
            var folder = base.CreateFolder(name);

            var decoratedFolder = new FolderObserverDecorator(folder);
            foreach (var observer in folderObservers)
                decoratedFolder.AddObserver(observer);

            return decoratedFolder;
        }
    }
}
