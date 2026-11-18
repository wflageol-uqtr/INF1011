namespace SystemeFichierExemple.Visitor
{
    public interface IElementVisitor
    {
        void Visit(IMyFile file);
        void Visit(IFolder folder);
    }
}