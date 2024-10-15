using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class CalculateSizeVisitor : INodeVisitor
    {
        public int Size { get; private set; }

        public void VisitFile(IFile file)
        {
            if(file.Content != null)
                Size += file.Content.Length;
        }

        public void VisitFolder(IFolder folder)
        {
            // Do nothing.
        }
    }
}
