using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    internal class CalculateSizeVisitor2
    {
        public int Size { get; private set; }

        public void VisitFile(IFile file)
        {
            if (file.Content != null)
                Size += file.Content.Length;
        }

        public void VisitFolder(IFolder folder)
        {
            foreach (var child in folder.Children)
            {
                if (child is IFile file)
                    VisitFile(file);
                else if (child is IFolder childFolder)
                    VisitFolder(childFolder);
            }
        }
    }
}
