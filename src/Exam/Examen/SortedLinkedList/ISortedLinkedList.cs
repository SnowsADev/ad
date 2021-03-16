﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AD
{
    public interface ISortedLinkedList
    {
        SortedLinkedListNode GetFirst();
        SortedLinkedListNode GetFirstSorted();

        void AddFirst(int value);

        SortedLinkedListNode Find(int data);

        string ToString();

        string ToStringSorted();
    }
}
