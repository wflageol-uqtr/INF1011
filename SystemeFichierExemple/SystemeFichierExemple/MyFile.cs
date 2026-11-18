using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemeFichierExemple.Visitor;

namespace SystemeFichierExemple
{
    public class MyFile : Element, IMyFile
    {
        public string Content { get; }

        public MyFile(string name, string content) : base(name)
        {
            Content = content;
        }

        public override void Accept(IElementVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
