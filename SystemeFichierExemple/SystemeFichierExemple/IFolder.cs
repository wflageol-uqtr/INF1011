namespace SystemeFichierExemple
{
    public interface IFolder : IElement
    {
        void AddSubElement(IElement element);
        void RemoveSubElement(IElement element);
    }
}