using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class File : NodeElement
    {

        private string? content;

        public string? Extension { get; set; }
        public string? Content 
        { 
            get => content;
            set
            {
                content = value;
                ObserverList.Notify();
            }
        }

        public File(string name, string? extension = null) : base(name)
        {
            Extension = extension;
        }
    }
}
