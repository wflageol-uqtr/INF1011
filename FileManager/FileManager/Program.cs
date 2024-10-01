// See https://aka.ms/new-console-template for more information




using FileManager;
using System.IO.Enumeration;


var file1 = new FileBuilder()
    .SetName("Fichier1")
    .SetExtension("dat")
    .SetContent("Hello World!")
    .GetFile();

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
    .AddChild(file1)
    .AddChild(file2)
    .AddChild(folder1)
    .GetFolder();


file1.ObserverList.Add(() => Console.WriteLine("File1 has changed!"));

file1.Content = "12354";

// Utilisateur

var fileSystem = new FileSystem(root);


var file3 = new FileBuilder()
    .SetName("Fichier3")
    .SetExtension("dat")
    .SetContent("1234")
    .GetFile();

fileSystem.PlaceElementAt(file3, "Répertoire2");

Console.WriteLine(file3.Parent.Name);