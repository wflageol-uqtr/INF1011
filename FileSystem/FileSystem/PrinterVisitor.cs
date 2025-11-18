using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public class PrinterVisitor : IElementVisitor
    {
        int indent = 0;

        private void Print(string text)
        {
            for (int i = 0; i < indent; i++)
                Console.Write(' ');
            Console.WriteLine(text);
        }

        public void VisitFile(File file)
            => Print(file.Name);

        public void VisitFolder(Folder folder)
        {
            Print(folder.Name);
            foreach(var element in folder)
            {
                indent += 2;
                element.Accept(this);
                indent -= 2;
            }
        }
    }
}
