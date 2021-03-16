using System;

namespace AD
{
    public partial class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        //----------------------------------------------------------------------
        // Cunstructors
        //----------------------------------------------------------------------

        public BinaryTree()
        {

        }

        public BinaryTree(T rootItem)
        {
            this.root = new BinaryNode<T>() { data = rootItem };
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public BinaryNode<T> GetRoot()
        {
            return this.root;
        }

        public int Size()
        {
            if (root == null) return 0;

            return HandleSizeRecursively(root);
        }

        private int HandleSizeRecursively(BinaryNode<T> node)
        {
            if (node == null) return 0;

            return 1 + HandleSizeRecursively(node.left) + HandleSizeRecursively(node.right);
        }

        public int Height()
        {
            if (root == null) return -1;

            return HandleHeightRecursively(root);
        }

        private int HandleHeightRecursively(BinaryNode<T> node)
        {
            if (node.left == null && node.right == null) return 0;

            int Left = int.MinValue;
            int Right = int.MinValue;

            if (node.left != null) Left = HandleHeightRecursively(node.left);
            if (node.right != null) Right = HandleHeightRecursively(node.right);


            return 1 + Math.Max(Left, Right);
        }

        public void MakeEmpty()
        {
            this.root = null;
        }

        public bool IsEmpty()
        {
            return this.root == null;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            if (root == null) root = new BinaryNode<T>();

            root.data = rootItem;

            if (t1 != null)
                root.left = t1.root;
            if (t2 != null)
                root.right = t2.root;
        }

        public string ToPrefixString()
        {
            if (root == null) return "NIL";

            string sResult = "";

            ToPrefixStringRecursively(root, ref sResult);

            return sResult.Trim();

        }
        private void ToPrefixStringRecursively(BinaryNode<T> node, ref string str)
        {

            str += $"[ {node.data} ";
            // Left
            if (node.left != null)
                ToPrefixStringRecursively(node.left, ref str);
            else
                str += "NIL ";

            // Right
            if (node.right != null)
                ToPrefixStringRecursively(node.right, ref str);
            else
                str += "NIL ";


            str += "] ";
        }

        public string ToInfixString()
        {
            if (root == null) return "NIL";

            string sResult = "";

            ToInfixStringRecursively(root, ref sResult);

            return sResult.Trim();

        }

        private void ToInfixStringRecursively(BinaryNode<T> node, ref string str)
        {
            str += "[ ";

            //Left
            if (node.left != null)
                ToInfixStringRecursively(node.left, ref str);
            else
                str += "NIL ";

            //Add to string
            str += $"{node.data} ";

            //Right 
            if (node.right != null)
                ToInfixStringRecursively(node.right, ref str);
            else
                str += "NIL ";

            str += "] ";
        }
        public string ToPostfixString()
        {
            if (root == null) return "NIL";

            string sResult = "";

            ToPostfixStringRecursively(root, ref sResult);

            return sResult.Trim();

        }

        private void ToPostfixStringRecursively(BinaryNode<T> node, ref string str)
        {
            str += "[ ";

            //Left
            if (node.left != null)
                ToPostfixStringRecursively(node.left, ref str);
            else
                str += "NIL ";

            //Right
            if (node.right != null)
                ToPostfixStringRecursively(node.right, ref str);
            else
                str += "NIL ";

            //String
            str += $"{node.data} ] ";
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves()
        {
            if (root == null) return 0;

            return NumberofleavesRecursive(root);
        }

        private int NumberofleavesRecursive(BinaryNode<T> node)
        {
            //Node is a leaf
            if (node.left == null && node.right == null)
                return 1;

            //Node has 2 children
            if (node.left != null && node.right != null)
                return NumberofleavesRecursive(node.left) + NumberofleavesRecursive(node.right);

            //Node has just 1 child
            if (node.left != null)
                return NumberofleavesRecursive(node.left);
            else if (node.right != null)
                return NumberofleavesRecursive(node.right);
            else
                return 0;
        }

        public int NumberOfNodesWithOneChild()
        {
            if (root == null) return 0;

            return NumberOfNodesWithOneChildRecursive(root);
        }

        private int NumberOfNodesWithOneChildRecursive(BinaryNode<T> node)
        {
            //Node is a leaf
            if (node.left == null && node.right == null)
                return 0;

            //Node has 2 children
            if (node.left != null && node.right != null)
                return NumberOfNodesWithOneChildRecursive(node.left) + NumberOfNodesWithOneChildRecursive(node.right);

            //Node has just 1 child
            if (node.left != null)
                return 1 + NumberOfNodesWithOneChildRecursive(node.left);
            else if (node.right != null)
                return 1 + NumberOfNodesWithOneChildRecursive(node.right);
            else
                return 0;
        }

        public int NumberOfNodesWithTwoChildren()
        {
            if (root == null) return 0;

            return NumberOfNodesWithTwoChildrenRecursive(root);
        }

        private int NumberOfNodesWithTwoChildrenRecursive(BinaryNode<T> node)
        {
            //Node is a leaf
            if (node.left == null && node.right == null)
                return 0;

            //Node has 2 children
            if (node.left != null && node.right != null)
                return 1 + NumberOfNodesWithTwoChildrenRecursive(node.left) + NumberOfNodesWithTwoChildrenRecursive(node.right);

            //Node has just 1 child
            if (node.left != null)
                return NumberOfNodesWithTwoChildrenRecursive(node.left);
            else if (node.right != null)
                return NumberOfNodesWithTwoChildrenRecursive(node.right);
            else
                return 0;
        }
    }
}