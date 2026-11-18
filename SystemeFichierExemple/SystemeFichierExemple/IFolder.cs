namespace SystemeFichierExemple
{
    public interface IFolder : IElement
    {
        IEnumerable<IElement> Elements { get; }
        void AddSubElement(IElement element);
        void RemoveSubElement(IElement element);
    }
}