using NUnit.Framework;
using Text;

namespace Text.Tests
{
    [TestFixture]
    public class StrTests
    {
        [Test]
        public void UniqueChar_WithEmptyString_ReturnsNegativeOne()
        {
            // Arrange
            string s = "";

            // Act
            int result = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void UniqueChar_WithNoUniqueCharacter_ReturnsNegativeOne()
        {
            // Arrange
            string s = "hello";

            // Act
            int result = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void UniqueChar_WithUniqueCharacter_ReturnsIndex()
        {
            // Arrange
            string s = "leetcode";

            // Act
            int result = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void UniqueChar_WithMultipleCharacters_ReturnsIndex()
        {
            // Arrange
            string s = "loveleetcode";

            // Act
            int result = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void UniqueChar_WithAllCharactersRepeated_ReturnsNegativeOne()
        {
            // Arrange
            string s = "aaabbbccc";

            // Act
            int result = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void UniqueChar_WithFirstCharacterUnique_ReturnsIndex()
        {
            // Arrange
            string s = "abcdabcd";

            // Act
            int result = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}