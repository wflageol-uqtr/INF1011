using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class FileBuilder
    {
        private string? name { get; set; }
        private string? extension { get; set; }
        private string? content { get; set; }

        public FileBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }
        public FileBuilder SetExtension(string extension)
        {
            this.extension = extension;
            return this;
        }
        public FileBuilder SetContent(string content)
        {
            this.content = content;
            return this;
        }

        public File GetFile()
        {
            if (name == null || content == null)
                throw new InvalidOperationException();

            var file = new File(name, extension);
            file.Content = content;

            return file;
        }
    }
}
