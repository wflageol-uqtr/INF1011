using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple.Visitor
{
    public class PrintElementVisitor : ElementVisitor
    {
        private int indentation = 0;

        public override void Visit(IMyFile file)
        {
            Indent();
            Console.WriteLine(file.Name);
        }

        public override void Visit(IFolder folder)
        {
            Indent();
            Console.WriteLine(folder.Name);
            indentation += 2;
            base.Visit(folder);
            indentation -= 2;
        }

        private void Indent()
        {
            for (int i = 0; i < indentation; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
