using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple.Visitor
{
    public abstract class ElementVisitor : IElementVisitor
    {
        public abstract void Visit(IMyFile file);

        public virtual void Visit(IFolder folder)
        {
            foreach (var element in folder.Elements)
                element.Accept(this);
        }
    }
}
