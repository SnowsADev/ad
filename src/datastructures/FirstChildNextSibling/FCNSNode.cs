namespace AD
{
    public partial class FCNSNode<T> : IFCNSNode<T>
    {
        public FCNSNode<T> firstChild;
        public FCNSNode<T> nextSibling;
        public T data;

        public FCNSNode(T data, FCNSNode<T> firstChild, FCNSNode<T> nextSibling)
        {
            this.data = data;
            this.firstChild = firstChild;
            this.nextSibling = nextSibling;
        }

        public FCNSNode(T data) : this(data, null, null) { }

        public T GetData()
        {
            return data;
        }

        public FCNSNode<T> GetFirstChild()
        {
            return this.firstChild;
        }

        public FCNSNode<T> GetNextSibling()
        {
            return this.nextSibling;
        }

        public override string ToString()
        {
            return this.data.ToString();
        }
    }
}