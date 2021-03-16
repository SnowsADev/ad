namespace AD
{
    //
    // This class offers static methods to create datastructures.
    // It is called by unit tests.
    //
    public partial class DSBuilder
    {
        public static ISortedLinkedList CreateSortedLinkedListEmpty()
        {
            return new SortedLinkedList();
        }

        public static ISortedLinkedList CreateSortedLinkedList3()
        {
            SortedLinkedListNode node3 = new SortedLinkedListNode(3);
            node3.next = null;
            node3.nextSorted = null;

            SortedLinkedList l = new SortedLinkedList();

            l.first = node3;
            l.firstSorted = node3;
            return l;
        }

        public static ISortedLinkedList CreateSortedLinkedList3714()
        {
            // Zou identiek moeten zijn na toevoegen van 3,7,1,4
            // aan lege SortedLinkedList
            SortedLinkedListNode node3 = new SortedLinkedListNode(3);
            SortedLinkedListNode node7 = new SortedLinkedListNode(7);
            SortedLinkedListNode node1 = new SortedLinkedListNode(1);
            SortedLinkedListNode node4 = new SortedLinkedListNode(4);
            node4.next = node1;
            node1.next = node7;
            node7.next = node3;
            node3.next = null;
            node1.nextSorted = node3;
            node3.nextSorted = node4;
            node4.nextSorted = node7;
            node7.nextSorted = null;

            SortedLinkedList l = new SortedLinkedList();

            l.first = node4;
            l.firstSorted = node1;
            return l;
        }

        public static ISortedLinkedList CreateSortedLinkedList37140()
        {
            SortedLinkedListNode node3 = new SortedLinkedListNode(3);
            SortedLinkedListNode node7 = new SortedLinkedListNode(7);
            SortedLinkedListNode node1 = new SortedLinkedListNode(1);
            SortedLinkedListNode node4 = new SortedLinkedListNode(4);
            SortedLinkedListNode node0 = new SortedLinkedListNode(0);

            node0.next = node4;
            node4.next = node1;
            node1.next = node7;
            node7.next = node3;
            node3.next = null;
            node0.nextSorted = node1;
            node1.nextSorted = node3;
            node3.nextSorted = node4;
            node4.nextSorted = node7;
            node7.nextSorted = null;

            SortedLinkedList l = new SortedLinkedList();

            l.first = node0;
            l.firstSorted = node0;
            return l;
        }

        public static ISortedLinkedList CreateSortedLinkedList37149()
        {
            //4,1,7,3 (dus uit opgave na Add van 3,7,1,4)
            SortedLinkedListNode node3 = new SortedLinkedListNode(3);
            SortedLinkedListNode node7 = new SortedLinkedListNode(7);
            SortedLinkedListNode node1 = new SortedLinkedListNode(1);
            SortedLinkedListNode node4 = new SortedLinkedListNode(4);
            SortedLinkedListNode node9 = new SortedLinkedListNode(9);

            node9.next = node4;
            node4.next = node1;
            node1.next = node7;
            node7.next = node3;
            node3.next = null;
            node1.nextSorted = node3;
            node3.nextSorted = node4;
            node4.nextSorted = node7;
            node7.nextSorted = node9;
            node9.nextSorted = null;

            SortedLinkedList l = new SortedLinkedList();

            l.first = node9;
            l.firstSorted = node1;
            return l;
        }

        public static ISortedLinkedList CreateSortedLinkedList37145()
        {
            SortedLinkedListNode node3 = new SortedLinkedListNode(3);
            SortedLinkedListNode node7 = new SortedLinkedListNode(7);
            SortedLinkedListNode node1 = new SortedLinkedListNode(1);
            SortedLinkedListNode node4 = new SortedLinkedListNode(4);
            SortedLinkedListNode node5 = new SortedLinkedListNode(5);

            node5.next = node4;
            node4.next = node1;
            node1.next = node7;
            node7.next = node3;
            node3.next = null;
            node1.nextSorted = node3;
            node3.nextSorted = node4;
            node4.nextSorted = node5;
            node5.nextSorted = node7;
            node7.nextSorted = null;

            SortedLinkedList l = new SortedLinkedList();

            l.first = node5;
            l.firstSorted = node1;
            return l;
        }

        public static ISortedLinkedList CreateSortedLinkedList37141()
        {
            SortedLinkedListNode node3 = new SortedLinkedListNode(3);
            SortedLinkedListNode node7 = new SortedLinkedListNode(7);
            SortedLinkedListNode node1 = new SortedLinkedListNode(1);
            SortedLinkedListNode node4 = new SortedLinkedListNode(4);
            SortedLinkedListNode node1b = new SortedLinkedListNode(1);

            node1b.next = node4;
            node4.next = node1;
            node1.next = node7;
            node7.next = node3;
            node3.next = null;
            node1b.nextSorted = node1;
            node1.nextSorted = node3;
            node3.nextSorted = node4;
            node4.nextSorted = node7;
            node7.nextSorted = null;

            SortedLinkedList l = new SortedLinkedList();

            l.first = node1b;
            l.firstSorted = node1b;
            return l;
        }
        public static ISortedLinkedList CreateSortedLinkedList37143()
        {
            SortedLinkedListNode node3 = new SortedLinkedListNode(3);
            SortedLinkedListNode node7 = new SortedLinkedListNode(7);
            SortedLinkedListNode node1 = new SortedLinkedListNode(1);
            SortedLinkedListNode node4 = new SortedLinkedListNode(4);
            SortedLinkedListNode node3b = new SortedLinkedListNode(3);

            node3b.next = node4;
            node4.next = node1;
            node1.next = node7;
            node7.next = node3;
            node3.next = null;
            node1.nextSorted = node3;
            node3.nextSorted = node3b;
            node3b.nextSorted = node4;
            node4.nextSorted = node7;
            node7.nextSorted = null;

            SortedLinkedList l = new SortedLinkedList();

            l.first = node3b;
            l.firstSorted = node1;
            return l;
        }
        public static ISortedLinkedList CreateSortedLinkedList37147()
        {
            SortedLinkedListNode node3 = new SortedLinkedListNode(3);
            SortedLinkedListNode node7 = new SortedLinkedListNode(7);
            SortedLinkedListNode node1 = new SortedLinkedListNode(1);
            SortedLinkedListNode node4 = new SortedLinkedListNode(4);
            SortedLinkedListNode node7b = new SortedLinkedListNode(7);

            node7b.next = node4;
            node4.next = node1;
            node1.next = node7;
            node7.next = node3;
            node3.next = null;
            node1.nextSorted = node3;
            node3.nextSorted = node4;
            node4.nextSorted = node7;
            node7.nextSorted = node7b;
            node7b.nextSorted = null;

            SortedLinkedList l = new SortedLinkedList();

            l.first = node7b;
            l.firstSorted = node1;
            return l;
        }
    }
}
