using System;
using System.Collections.Generic;
using System.Text;

namespace AD
{
    public partial class SortedLinkedList : ISortedLinkedList
    {
        public SortedLinkedListNode first;
        public SortedLinkedListNode firstSorted;

        public SortedLinkedList()
        {
            first = firstSorted = null;
        }

        public SortedLinkedListNode GetFirst()
        {
            return first;
        }
        public SortedLinkedListNode GetFirstSorted()
        {
            return firstSorted;
        }
        public void AddFirst(int value)
        {
            SortedLinkedListNode newNode = new SortedLinkedListNode(value);
            newNode.next = first;

            if (GetFirst() == null) { 
                first = newNode;
                firstSorted = newNode;
                return;
            }
            first = newNode;
            Sort();
        }
        /// <summary>
        /// Sorts the list
        /// </summary>
        private void Sort()
        {
            SortedLinkedListNode currentNode = GetFirst();
            while (currentNode != null)
            {
                currentNode.nextSorted = FindNextSorted(currentNode.data);
                currentNode = currentNode.next;
            }
        }
        /// <summary>
        /// Finds the closest node with a value bigger than the parameter value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private SortedLinkedListNode FindNextSorted(int value)
        {
            SortedLinkedListNode currentNode = GetFirst();
            SortedLinkedListNode nextSorted = null;
            int nextSortedValue = int.MaxValue;

            //find smallest node with a value that is bigger than parameter "value"
            while(currentNode != null)
            {
                if (currentNode.data > value && currentNode.data <= nextSortedValue) { 
                    nextSorted = currentNode;
                    nextSortedValue = currentNode.data;
                }

                //assign firstSorted
                if (currentNode.data < firstSorted.data) 
                    firstSorted = currentNode;

                currentNode = currentNode.next;
            }

            return nextSorted;
        }

        public SortedLinkedListNode Find(int data)
        {
            return FindRecursive(data, first);
        }

        private SortedLinkedListNode FindRecursive(int data, SortedLinkedListNode node)
        {
            if (node == null) return null;

            if (node.data == data) 
                return node;
            else
                return FindRecursive(data, node.next);
        }

        public override string ToString()
        {
            if (first == null) return "NULL";

            return ToStringRecursive(first);
        }

        private string ToStringRecursive(SortedLinkedListNode node)
        {
            if (node == null) return "";

            return node.data + (node.next != null ? "->" : "") + ToStringRecursive(node.next);
        }

        public string ToStringSorted()
        {
            
            return "[" +ToStringSortedRecursive(firstSorted).TrimEnd(',') + "]";
        }

        private string ToStringSortedRecursive(SortedLinkedListNode node)
        {
            if (node == null) return "";

            return node.data + "," + ToStringSortedRecursive(node.nextSorted);
        }
    }
}
