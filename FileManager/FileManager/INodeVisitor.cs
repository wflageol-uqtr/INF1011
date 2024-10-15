using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public interface INodeVisitor
    {
        void VisitFile(IFile file);
        void VisitFolder(IFolder folder);
    }
}
