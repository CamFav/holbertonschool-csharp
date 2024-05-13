using NUnit.Framework;
using Text;

namespace Text.Tests
{
    [TestFixture]
    public class TextTests
    {
        [TestCase("Racecar", true)]
        [TestCase("level", true)]
        [TestCase("A man, a plan, a canal: Panama.", true)]
        [TestCase("", true)]
        [TestCase("hello", false)]
        [TestCase("not a palindrome", false)]
        public void IsPalindrome_ValidInput_ReturnsExpectedResult(string input, bool expected)
        {
            // Act
            bool result = Str.IsPalindrome(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}