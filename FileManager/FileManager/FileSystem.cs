using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class FileSystem
    {
        public IFolder Root { get; }

        public FileSystem(IFolder root)
        {
            Root = root;
        }
        
        public FileSystem PlaceElementAt(INodeElement element, string path)
        {
            var folderNames = path.Split("/");

            var current = Root;
            foreach (var folderName in folderNames)
            {
                var target = current.Children.FirstOrDefault(element => element.Name == folderName);

                if (target == null)
                {
                    target = new FolderBuilder().SetName(folderName).GetFolder();
                    current.AddChild(target);
                }

                if (target is IFolder folder)
                    current = folder;
                else
                    throw new InvalidOperationException($"{folderName} is not a folder.");
            }

            current.AddChild(element);

            return this;
        }
    }
}
