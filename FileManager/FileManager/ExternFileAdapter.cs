using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    internal class ExternFileAdapter : NodeElement, IFile
    {
        private ExternFile target;
        public string? Content { get => ""; set => throw new NotImplementedException(); }

        public ExternFileAdapter(ExternFile target) : base(target.GetName())
        {
            this.target = target;
        }

        public override void Accept(INodeVisitor visitor)
        {
            visitor.VisitFile(this);
        }
    }
}
