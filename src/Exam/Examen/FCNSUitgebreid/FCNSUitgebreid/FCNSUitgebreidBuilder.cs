namespace AD
{
    public partial class DSBuilder
    {
        public static IFirstChildNextSibling<int> CreateFirstChildNextSibling_Practicum()
        {
            FCNSNode<int> n8 = new FCNSNode<int>(8);
            FCNSNode<int> n7 = new FCNSNode<int>(7, null, n8);
            FCNSNode<int> n6 = new FCNSNode<int>(6, null, n7);
            FCNSNode<int> n5 = new FCNSNode<int>(5);
            FCNSNode<int> n4 = new FCNSNode<int>(4, n6, null);
            FCNSNode<int> n3 = new FCNSNode<int>(3, null, n4);
            FCNSNode<int> n2 = new FCNSNode<int>(2, n5, n3);
            FCNSNode<int> n1 = new FCNSNode<int>(1, n2, null);

            IFirstChildNextSibling<int> tree = new FirstChildNextSibling<int>() { root = n1};
            
            return tree;
            
        }
    }
}
