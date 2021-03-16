using System;
using System.Collections.Generic;

namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public FCNSNode<T> root;

        public int Size()
        {
            if (root == null) return 0;

            return CountNodesRecursively(root);
        }

        private int CountNodesRecursively(FCNSNode<T> node)
        {
            if (node == null) return 0;

            return 1 + CountNodesRecursively(node.GetFirstChild()) + CountNodesRecursively(node.GetNextSibling());
        }

        public void PrintPreOrder()
        {
            if (root == null)
            {
                Console.WriteLine("NIL");
                return;
            }

            PrintPreOrderNodeRecursively(root, 0);
        }

        private void PrintPreOrderNodeRecursively(FCNSNode<T> node, int depth)
        {
            for (int i = 0; i < depth; i++)
                Console.Write("   ");

            Console.WriteLine(node.data);

            if (node.GetFirstChild() != null)
                PrintPreOrderNodeRecursively(node.GetFirstChild(), depth + 1);
            if(node.GetNextSibling() != null)
                PrintPreOrderNodeRecursively(node.GetNextSibling(), depth);
        }

        public override string ToString()
        {
            if (root == null) return "NIL";

            return CreateStringRecursively(root);
        }

        private string CreateStringRecursively(FCNSNode<T> node)
        {
            string result = node.data.ToString();

            if (node.GetFirstChild() != null)
                result += $",FC({CreateStringRecursively(node.GetFirstChild())})";
            if (node.GetNextSibling() != null)
                result += $",NS({CreateStringRecursively(node.GetNextSibling())})";

            return result;
        }

    }
}