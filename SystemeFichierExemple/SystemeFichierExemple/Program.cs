using SystemeFichierExemple;
using SystemeFichierExemple.Extensions;
using SystemeFichierExemple.Factory;
using SystemeFichierExemple.Logging;
using SystemeFichierExemple.Visitor;

FileSystemFacade fileSystem = new FileSystemFacade(
    new ObservableFactory([new LoggingObserver(new FileLoggingStrategy("FileSystem.dat"))]));

var root = fileSystem.CreateRoot("Root");
var folder1 = fileSystem.CreateFolder(root, "Folder 1");
var folder2 = fileSystem.CreateFolder(root, "Folder 2");
var file1 = fileSystem.CreateFile(folder1, "File 1", "abc");
var file2 = fileSystem.CreateFile(folder2, "File 2", "def");
var file3 = fileSystem.CreateFile(folder2, "File 3", "ghi");

var printVisitor = new PrintElementVisitor();
root.Accept(printVisitor);
//PrintExtension.Print((dynamic)root);

var countVisitor = new CountFileVisitor();
root.Accept(countVisitor);
Console.WriteLine(countVisitor.Count);

