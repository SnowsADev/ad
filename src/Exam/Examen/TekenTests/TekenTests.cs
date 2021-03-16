using NUnit.Framework;


namespace AD
{
    [TestFixture]
    public partial class PracticumTekenTests
    {
        [TestCase(0, "0")]
        [TestCase(5, "010201030102010401020103010201050102010301020104010201030102010")]
        [TestCase(9, "010201030102010401020103010201050102010301020104010201030102010601020103010201040102010301020105010201030102010401020103010201070102010301020104010201030102010501020103010201040102010301020106010201030102010401020103010201050102010301020104010201030102010801020103010201040102010301020105010201030102010401020103010201060102010301020104010201030102010501020103010201040102010301020107010201030102010401020103010201050102010301020104010201030102010601020103010201040102010301020105010201030102010401020103010201090102010301020104010201030102010501020103010201040102010301020106010201030102010401020103010201050102010301020104010201030102010701020103010201040102010301020105010201030102010401020103010201060102010301020104010201030102010501020103010201040102010301020108010201030102010401020103010201050102010301020104010201030102010601020103010201040102010301020105010201030102010401020103010201070102010301020104010201030102010501020103010201040102010301020106010201030102010401020103010201050102010301020104010201030102010")]
        public void TekenTest(int num, string expected)
        {
            // Act
            string actual = PracticumTeken.Teken(num);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}