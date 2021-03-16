using System;

namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public IFCNSNode<T> FindParent(T data)
        {
            if (root == null) return null;
            if (root.data.Equals(data)) return null;

            return FindParent(data, root);
        }

        private IFCNSNode<T> FindParent(T data, IFCNSNode<T> prt)
        {
            IFCNSNode<T> currentNode = prt.GetFirstChild();
            IFCNSNode<T> lastResult = null;

            while (currentNode != null)
            {
                //node is found
                if (currentNode.GetData().Equals(data)) return prt;

                //Check Children
                if (currentNode.GetFirstChild() != null)
                    lastResult = FindParent(data, currentNode);

                //Next sibling
                if (lastResult == null)
                    currentNode = currentNode.GetNextSibling();
                else
                    return lastResult;

            }

            return null;
        }



        public string SiblingsToString(T data)
        {
            //Find parent
            IFCNSNode<T> prt = FindParent(data);
            
            string strResult = $"Siblings of {data}: ";

            //Null Checks
            if (prt == null) return strResult.Trim();
            if (prt.GetFirstChild() == null) return strResult.Trim();
            
            //add to string
            IFCNSNode<T> node = prt.GetFirstChild();
            while (node != null)
            {
                if (!node.GetData().Equals(data))
                    strResult += node.ToString() + " ";

                node = node.GetNextSibling();
            }

            return strResult.Trim();
        }
    }

}