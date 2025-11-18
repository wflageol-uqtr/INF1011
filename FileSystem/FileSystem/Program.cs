// See https://aka.ms/new-console-template for more information


using FileSystem;

RootBuilder builder = new();

builder.AddFile("File 1");
builder.AddFolder("Folder 1");
var folder2builder = builder.AddFolder("Folder 2");

folder2builder.AddFile("Fichier 2");
folder2builder.AddFile("Fichier 3");

var root = builder.ToRoot();

var printVisitor = new PrinterVisitor();
root.Accept(printVisitor);