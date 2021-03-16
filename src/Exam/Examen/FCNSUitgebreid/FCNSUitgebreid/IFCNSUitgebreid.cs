namespace AD
{
    public partial interface IFirstChildNextSibling<T>
    {
        IFCNSNode<T> FindParent(T data);
        string SiblingsToString(T data);
    }
}
