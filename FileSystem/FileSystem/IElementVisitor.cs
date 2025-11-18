using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public interface IElementVisitor
    {
        public void VisitFile(File file);
        public void VisitFolder(Folder folder);
    }
}
