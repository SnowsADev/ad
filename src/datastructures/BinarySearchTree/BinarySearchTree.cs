namespace AD
{
    public partial class BinarySearchTree<T> : BinaryTree<T>, IBinarySearchTree<T>
        where T : System.IComparable<T>
    {

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public void Insert(T x)
        {
            BinaryNode<T> parent = null;
            BinaryNode<T> ptr = root;
            int result;
            while (ptr != null)
            {
                parent = ptr;

                result = x.CompareTo(ptr.data);

                if (result == 0)
                    throw new BinarySearchTreeDoubleKeyException();
                else if (result < 0)
                    ptr = ptr.left;
                else
                    ptr = ptr.right;
            }

            if (parent == null)
                root = new BinaryNode<T>() { data = x };
            else if (x.CompareTo(parent.data) < 0)
                parent.left = new BinaryNode<T>() { data = x };
            else
                parent.right = new BinaryNode<T>() { data = x };

        }

        public T FindMin()
        {
            if (root == null) throw new BinarySearchTreeEmptyException();

            return FindMinRecursively(root).data;
        }

        private BinaryNode<T> FindMinRecursively(BinaryNode<T> node)
        {
            if (node.left != null) return FindMinRecursively(node.left);

            return node;
        }

        public void RemoveMin()
        {
            if (root == null) throw new BinarySearchTreeEmptyException();

            BinaryNode<T> parent = null;
            BinaryNode<T> node = root;

            //find most left node
            while (node.left != null)
            {
                parent = node;
                node = node.left;
            }

            //smallest node is the root
            if (parent == null)
                if (node.right != null)
                    root = node.right;
                else
                    root = null;

            //smallest node has no children (trivial)
            else if (node.right == null)
                parent.left = null;
            //replace node with right subtree (one child)
            else
                parent.left = node.right;
        }

        private BinaryNode<T> RemoveMinFromSubtree(BinaryNode<T> node)
        {
            if (node == null) 
                throw new BinarySearchTreeElementNotFoundException();
            else if (node.left != null)
            {
                node.left = RemoveMinFromSubtree(node.left);
                return node;
            } 
            else
            {
                return node.right;
            }

        }

        public void Remove(T x)
        {
            if (root == null) throw new BinarySearchTreeElementNotFoundException();

            Remove(x, root);
            //BinaryNode<T> parent = null;
            //BinaryNode<T> node = root;

            //while (node.data.CompareTo(x) != 0)
            //{
            //    parent = node;

            //    //Node is a leaf
            //    if (node.left == null && node.right == null)
            //        throw new BinarySearchTreeElementNotFoundException();
                
            //    //x is smaller than value
            //    else if (x.CompareTo(node.data) < 0) {
            //        if (node.left != null)
            //            node = node.left;
            //        else throw new BinarySearchTreeElementNotFoundException();
                
            //    //x is bigger than value
            //    } else {
            //        if (node.right != null)
            //            node = node.right;
            //        else throw new BinarySearchTreeElementNotFoundException();
                
            //    }
            //}

            //// X equals root.data
            //if(parent == null)
            //{
            //    if (node.left == null && node.right == null)
            //        root = null;
            //    else if (node.left == null)
            //        root = node.right;
            //    else if (node.right == null)
            //        root = node.left;
            //    else {
            //        BinaryNode<T> newNode = FindMinRecursively(node.right);
            //        node.data = newNode.data;

            //        while (newNode.left != null && newNode.right != null)
            //        {
            //            newNode = FindMinRecursively(node.right)
            //        }
            //    }
            //}

        }

        private BinaryNode<T> Remove(T x, BinaryNode<T> node)
        {
            //Element not found
            if (node == null) throw new BinarySearchTreeElementNotFoundException();

            //x is smaller than node.data
            if (x.CompareTo(node.data) < 0)
                node.left = Remove(x, node.left);
            //x is bigger than node.data
            else if (x.CompareTo(node.data) > 0)
                node.right = Remove(x, node.right);
            //node has 2 children
            else if (node.left != null && node.right != null)
            {
                node.data = FindMinRecursively(node.right).data;
                node.right = RemoveMinFromSubtree(node.right);
            }
            else
                node = node.left ?? node.right;
            
            return node;
        }

        public string InOrder()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            if (root == null) return string.Empty;

            return ToString(root, "").Trim();
        }

        private string ToString(BinaryNode<T> node, string str)
        {
            return $"{(node.left != null ? ToString(node.left, str) : string.Empty)}{node.data} {(node.right != null ? ToString(node.right, str) : string.Empty)}";
        }

    }
}
