using NUnit.Framework;


namespace AD
{

    [TestFixture]
    public partial class FCNSUitgebreidTests
    {

        /// <summary>
        /// TESTEN VRAAG 2 A EN B
        /// </summary>

        //Practicum tree
        [Test]
        public void FCNSUitgebreid_01_FindParent_01_ParentOfRootIsNull_01_OnPracticumTree()
        {
            // Arrange
            IFirstChildNextSibling<int> tree = DSBuilder.CreateFirstChildNextSibling_Practicum();
            IFCNSNode<int> expected = null;

            // Act
            IFCNSNode<int> actual = tree.FindParent(1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 2)]
        [TestCase(6, 4)]
        [TestCase(7, 4)]
        [TestCase(8, 4)]
        public void FCNSUitgebreid_01_FindParent_02_ExistingParents_01_OnPracticumTree(
            int input,
            int expected)
        {
            // Arrange
            IFirstChildNextSibling<int> tree = DSBuilder.CreateFirstChildNextSibling_Practicum();

            // Act
            int actual = tree.FindParent(input).GetData();

            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// TESTEN VRAAG 2 C
        /// </summary>
        /// 

        [Test]
        [TestCase(1, "Siblings of 1:")]
        [TestCase(2, "Siblings of 2: 3 4")]
        [TestCase(3, "Siblings of 3: 2 4")]
        [TestCase(4, "Siblings of 4: 2 3")]
        [TestCase(5, "Siblings of 5:")]
        [TestCase(6, "Siblings of 6: 7 8")]
        public void FCNSUitgebreid_02_SiblingString_01_OnPracticumTree(
            int input,
            string expected_string
            )
        {
            // Arrange
            IFirstChildNextSibling<int> tree = DSBuilder.CreateFirstChildNextSibling_Practicum();
            string expected = TestUtils.TrimmedStringWithSingleSpaces(expected_string);

            // Act
            string actual = TestUtils.TrimmedStringWithSingleSpaces(tree.SiblingsToString(input));

            Assert.AreEqual(expected, actual);
        }
    }
}
