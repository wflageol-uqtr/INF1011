using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple
{
    public class MyFile : Element, IMyFile
    {
        public string Content { get; }

        public MyFile(string name, string content) : base(name)
        {
            Content = content;
        }

        public override void Print()
        {
            Console.WriteLine(Name);
        }
    }
}
