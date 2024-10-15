// See https://aka.ms/new-console-template for more information




using FileManager;
using System.IO.Enumeration;


var file1 = new FileBuilder()
    .SetName("Fichier1")
    .SetExtension("dat")
    .SetContent("Hello World!")
    .GetFile();

var observedFile1 = new ObservableFileDecorator(file1);

var file2 = new FileBuilder()
    .SetName("Fichier2")
    .SetExtension("dat")
    .SetContent("1234")
    .GetFile();


var folder1 = new FolderBuilder()
    .SetName("Répertoire1")
    .GetFolder();

var root = new FolderBuilder()
    .SetName("Répertoires")
    .AddChild(observedFile1)
    .AddChild(file2)
    .AddChild(folder1)
    .GetFolder();


observedFile1.ObserverList.Add(() => Console.WriteLine("File1 has changed!"));

observedFile1.Content = "12354";
file1.Content = "14";

// Utilisateur

var fileSystem = new FileSystem(root);


var externFile3 = new ExternFile("Fichier3 Externe");

var file3 = new ExternFileAdapter(externFile3);

fileSystem.PlaceElementAt(file3, "Répertoire2");

var sizeVisitor = new CalculateSizeVisitor();
root.Accept(sizeVisitor);

Console.WriteLine($"Root size: {sizeVisitor.Size}");

var sizeVisitor2 = new CalculateSizeVisitor2();
sizeVisitor2.VisitFolder(root);

Console.WriteLine($"Root size: {sizeVisitor2.Size}");