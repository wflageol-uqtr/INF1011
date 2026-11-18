using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemeFichierExemple.Extensions
{
    public static class PrintExtension
    {
        public static void Print(IFolder element)
        {
            Console.WriteLine(element.Name);
            foreach (dynamic subelement in element.Elements)
                Print(subelement);
        }

        public static void Print(IMyFile element)
        {
            Console.WriteLine(element.Name);
        }
    }
}
