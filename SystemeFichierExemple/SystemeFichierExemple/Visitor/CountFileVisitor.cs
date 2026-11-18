using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple.Visitor
{
    public class CountFileVisitor : ElementVisitor
    {
        public int Count { get; private set; }

        public override void Visit(IMyFile file) => Count++;
    }
}
