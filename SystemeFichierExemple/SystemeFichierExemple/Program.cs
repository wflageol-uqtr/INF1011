using SystemeFichierExemple;

IFolder root = new Folder("Root");
IFolder folder1 = new Folder("Folder 1");
IFolder folder2 = new Folder("Folder 2");
IMyFile file1 = new MyFile("File 1", "abc");
IMyFile file2 = new MyFile("File 2", "def");
IMyFile file3 = new MyFile("File 3", "ghi");

folder2 = new LoggingFolder(folder2);

root.AddSubElement(folder1);
root.AddSubElement(folder2);
folder1.AddSubElement(file1);
folder2.AddSubElement(file2);
folder2.AddSubElement(file3);

root.Print();