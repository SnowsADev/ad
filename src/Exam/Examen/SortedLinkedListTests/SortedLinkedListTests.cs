using NUnit.Framework;

namespace AD
{
    [TestFixture]
    public partial class SortedLinkedListTests
    {
        #region UtilitiesForComparingLists

        // Only checks data, not addresses!
        public static bool CompareLinkedLists(SortedLinkedListNode x, SortedLinkedListNode y)
        {
            if (x == null && y == null)
                return true;

            if (x == null || y == null || x.data != y.data)
                return false;
            return CompareLinkedLists(x.next, y.next);
        }

        // Only checks data, not addresses!
        public static bool CompareSortedLists(SortedLinkedListNode x, SortedLinkedListNode y)
        {
            if (x == null && y == null)
                return true;

            if (x == null || y == null || x.data != y.data)
                return false;
            return CompareSortedLists(x.nextSorted, y.nextSorted);
        }

        public static bool ListsAreEqual(ISortedLinkedList x, ISortedLinkedList y)
        {
            return CompareLinkedLists(x.GetFirst(), y.GetFirst()) &&
                CompareSortedLists(x.GetFirstSorted(), y.GetFirstSorted());
        }
        #endregion

        #region Constructor
        [Test]
        public void SortedLinkedList_01_Constructor_01_FirstIsNull()
        {
            // Act
            SortedLinkedList l = new SortedLinkedList();

            // Assert
            Assert.IsNull(l.GetFirst());
        }

        [Test]
        public void SortedLinkedList_01_Constructor_02_FirstSortedIsNull()
        {
            // Act
            SortedLinkedList l = new SortedLinkedList();

            // Assert
            Assert.IsNull(l.GetFirstSorted());
        }
        #endregion

        #region AddFirst
        [Test]
        public void SortedLinkedList_02_AddFirst_01_OnEmptyList_01_First_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedListEmpty();

            // Act
            l.AddFirst(3);

            // Assert
            Assert.IsNotNull(l.GetFirst());
            Assert.AreEqual(3, l.GetFirst().data);
            Assert.IsNull(l.GetFirst().next);
        }

        [Test]
        public void SortedLinkedList_02_AddFirst_01_OnEmptyList_02_FirstSorted_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedListEmpty();

            // Act
            l.AddFirst(3);

            // Assert
            Assert.IsNotNull(l.GetFirstSorted());
            Assert.AreEqual(3, l.GetFirstSorted().data);
            Assert.IsNull(l.GetFirstSorted().nextSorted);
        }

        [Test]
        public void SortedLinkedList_02_AddFirst_02_OnOneElement_01_Ascending_01_First_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3();

            // Act
            l.AddFirst(5);

            // Assert
            Assert.IsNotNull(l.GetFirst());
            Assert.AreEqual(5, l.GetFirst().data);
            Assert.IsNotNull(l.GetFirst().next);
            Assert.AreEqual(3, l.GetFirst().next.data);
            Assert.IsNull(l.GetFirst().next.next);
        }

        [Test]
        public void SortedLinkedList_02_AddFirst_02_OnOneElement_01_Ascending_02_FirstSorted_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3();

            // Act
            l.AddFirst(5);

            // Assert
            Assert.IsNotNull(l.GetFirstSorted());
            Assert.AreEqual(3, l.GetFirstSorted().data);
            Assert.IsNotNull(l.GetFirstSorted().nextSorted);
            Assert.AreEqual(5, l.GetFirstSorted().nextSorted.data);
            Assert.IsNull(l.GetFirstSorted().nextSorted.nextSorted);
        }

        [Test]
        [Category("bla")]
        public void SortedLinkedList_02_AddFirst_02_OnOneElement_02_Descending_01_First_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3();

            // Act
            l.AddFirst(1);

            // Assert
            Assert.IsNotNull(l.GetFirst());
            Assert.AreEqual(1, l.GetFirst().data);
            Assert.IsNotNull(l.GetFirst().next);
            Assert.AreEqual(3, l.GetFirst().next.data);
            Assert.IsNull(l.GetFirst().next.next);
        }

        [Test]
        public void SortedLinkedList_02_AddFirst_02_OnOneElement_02_Descending_02_FirstSorted_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3();

            // Act
            l.AddFirst(1);

            // Assert
            Assert.IsNotNull(l.GetFirstSorted());
            Assert.AreEqual(1, l.GetFirstSorted().data);
            Assert.IsNotNull(l.GetFirstSorted().nextSorted);
            Assert.AreEqual(3, l.GetFirstSorted().nextSorted.data);
            Assert.IsNull(l.GetFirstSorted().nextSorted.nextSorted);
        }

        [Test]
        public void SortedLinkedList_02_AddFirst_02_OnOneElement_03_Same_01_First_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3();

            // Act
            l.AddFirst(3);

            // Assert
            Assert.IsNotNull(l.GetFirst());
            Assert.AreEqual(3, l.GetFirst().data);
            Assert.IsNotNull(l.GetFirst().next);
            Assert.AreEqual(3, l.GetFirst().next.data);
            Assert.IsNull(l.GetFirst().next.next);
        }

        [Test]
        public void SortedLinkedList_02_AddFirst_02_OnOneElement_03_Same_02_FirstSorted_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3();

            // Act
            l.AddFirst(3);

            // Assert
            Assert.IsNotNull(l.GetFirstSorted());
            Assert.AreEqual(3, l.GetFirstSorted().data);
            Assert.IsNotNull(l.GetFirstSorted().nextSorted);
            Assert.AreEqual(3, l.GetFirstSorted().nextSorted.data);
            Assert.IsNull(l.GetFirstSorted().nextSorted.nextSorted);
        }

        [Test]
        public void SortedLinkedList_02_AddFirst_03_Adding3714()
        {
            // Arrange
            SortedLinkedList l = new SortedLinkedList();

            // Act
            l.AddFirst(3);
            l.AddFirst(7);
            l.AddFirst(1);
            l.AddFirst(4);

            // Assert
            Assert.AreEqual(l.first, l.firstSorted.nextSorted.nextSorted); // 4
            Assert.AreEqual(l.first.next, l.firstSorted); // 1
            Assert.AreEqual(l.first.next.next, l.firstSorted.nextSorted.nextSorted.nextSorted); // 7
            Assert.AreEqual(l.first.next.next.next, l.firstSorted.nextSorted); // 3
        }

        [Test]
        public void SortedLinkedList_02_AddFirst_04_On3714_01_NewDataIsLower_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();

            // Act
            l.AddFirst(0);

            // Assert
            ISortedLinkedList correct = DSBuilder.CreateSortedLinkedList37140();
            Assert.AreEqual(true, ListsAreEqual(l, correct));//.GetFirst(), correct.GetFirst()));
        }

        [Test]
        public void SortedLinkedList_02_AddFirst_04_On3714_02_NewDataIsHigher_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();

            // Act
            l.AddFirst(9);

            // Assert
            ISortedLinkedList correct = DSBuilder.CreateSortedLinkedList37149();
            Assert.AreEqual(true, ListsAreEqual(l, correct));

            //            Assert.AreEqual(true, ListsAreEqual(l.GetFirst(), correct.GetFirst()));
        }

        [Test]
        public void SortedLinkedList_02_AddFirst_04_On3714_03_NewDataInMid_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();

            // Act
            l.AddFirst(5);

            // Assert
            ISortedLinkedList correct = DSBuilder.CreateSortedLinkedList37145();
            Assert.AreEqual(true, ListsAreEqual(l, correct));
            //           Assert.AreEqual(true, ListsAreEqual(l.GetFirst(), correct.GetFirst()));
        }

        [Test]
        public void SortedLinkedList_02_AddFirst_04_On3714_04_NewDataEqualsLowest_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();

            // Act
            l.AddFirst(1);

            // Assert
            ISortedLinkedList correct = DSBuilder.CreateSortedLinkedList37141();
            Assert.AreEqual(true, ListsAreEqual(l, correct));
            //            Assert.AreEqual(true, ListsAreEqual(l.GetFirst(), correct.GetFirst()));
        }

        [Test]
        public void SortedLinkedList_02_AddFirst_04_On3714_05_NewDataEqualsHighest_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();

            // Act
            l.AddFirst(7);

            // Assert
            ISortedLinkedList correct = DSBuilder.CreateSortedLinkedList37147();
            Assert.AreEqual(true, ListsAreEqual(l, correct));
            //            Assert.AreEqual(true, ListsAreEqual(l.GetFirst(), correct.GetFirst()));
        }

        [Test]
        public void SortedLinkedList_02_AddFirst_04_On3714_06_NewDataEqualsMid_Valid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();

            // Act
            l.AddFirst(3);

            // Assert
            ISortedLinkedList correct = DSBuilder.CreateSortedLinkedList37143();
            Assert.AreEqual(true, ListsAreEqual(l, correct));
            //            Assert.AreEqual(true, ListsAreEqual(l.GetFirst(), correct.GetFirst()));
        }
        #endregion

        #region ToString
        [Test]
        public void SortedLinkedList_03_ToString_01_OnEmptyList()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedListEmpty();
            string expected = "NULL";

            // Act
            string actual = TestUtils.TrimmedStringWithoutSpaces(l.ToString());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortedLinkedList_03_ToString_02_OnOneElement()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3();
            string expected = "3";

            // Act
            string actual = TestUtils.TrimmedStringWithoutSpaces(l.ToString());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortedLinkedList_03_ToString_03_On3714()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();
            string expected = "4->1->7->3";

            // Act
            string actual = TestUtils.TrimmedStringWithoutSpaces(l.ToString());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortedLinkedList_04_ToStringSorted_01_OnEmptyList()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedListEmpty();
            string expected = "[]";

            // Act
            string actual = TestUtils.TrimmedStringWithoutSpaces(l.ToStringSorted());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortedLinkedList_04_ToStringSorted_02_OnOneElement()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3();
            string expected = "[3]";

            // Act
            string actual = TestUtils.TrimmedStringWithoutSpaces(l.ToStringSorted());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortedLinkedList_04_ToStringSorted_03_On3714()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();
            string expected = "[1,3,4,7]";

            // Act
            string actual = TestUtils.TrimmedStringWithoutSpaces(l.ToStringSorted());


            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Find
        [Test]
        public void SortedLinkedList_05_Find_01_OnEmptyList()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedListEmpty();

            // Act
            SortedLinkedListNode actual = l.Find(0);

            // Assert
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void SortedLinkedList_05_Find_02_OnOneElement_01_ElementNotPresent()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3();

            // Act
            SortedLinkedListNode actual = l.Find(0);

            // Assert
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void SortedLinkedList_05_Find_02_OnOneElement_02_ElementPresent()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3();

            // Act
            SortedLinkedListNode actual = l.Find(3);

            // Assert
            Assert.AreEqual(l.GetFirst(), actual);
        }

        [Test]
        public void SortedLinkedList_05_Find_03_On3714_01_ElementNotPresent_01_TooLow()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();

            // Act
            SortedLinkedListNode actual = l.Find(0);

            // Assert
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void SortedLinkedList_05_Find_03_On3714_01_ElementNotPresent_02_TooHigh()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();

            // Act
            SortedLinkedListNode actual = l.Find(9);

            // Assert
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void SortedLinkedList_05_Find_03_On3714_01_ElementNotPresent_03_InMid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();

            // Act
            SortedLinkedListNode actual = l.Find(5);

            // Assert
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void SortedLinkedList_05_Find_03_On3714_02_ElementPresent_01_AtStart()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();

            // Act
            SortedLinkedListNode actual = l.Find(1);

            // Assert
            Assert.AreEqual(l.GetFirstSorted(), actual);
        }

        [Test]
        public void SortedLinkedList_05_Find_03_On3714_02_ElementPresent_02_AtEnd()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();

            // Act
            SortedLinkedListNode actual = l.Find(7);

            // Assert
            Assert.AreEqual(l.GetFirstSorted().nextSorted.nextSorted.nextSorted, actual);
        }

        [Test]
        public void SortedLinkedList_05_Find_03_On3714_02_ElementPresent_03_InMid()
        {
            // Arrange
            ISortedLinkedList l = DSBuilder.CreateSortedLinkedList3714();

            // Act
            SortedLinkedListNode actual = l.Find(4);

            // Assert
            Assert.AreEqual(l.GetFirstSorted().nextSorted.nextSorted, actual);
        }
        #endregion
    }
}

