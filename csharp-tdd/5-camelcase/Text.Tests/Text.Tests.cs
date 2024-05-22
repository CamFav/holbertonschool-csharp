using NUnit.Framework;
using Text;

namespace Text.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCamelCase_SingleWord()
        {
            Assert.AreEqual(1, Str.CamelCase("hello"));
        }

        [Test]
        public void TestCamelCase_MultipleWords()
        {
            Assert.AreEqual(4, Str.CamelCase("helloWorldThisIsCamelCase"));
        }

        [Test]
        public void TestCamelCase_EmptyString()
        {
            Assert.AreEqual(0, Str.CamelCase(""));
        }

        [Test]
        public void TestCamelCase_AllUppercaseLetters()
        {
            Assert.AreEqual(5, Str.CamelCase("HelloWorldThisIsTest"));
        }

        [Test]
        public void TestCamelCase_NoUppercaseLetters()
        {
            Assert.AreEqual(1, Str.CamelCase("hellothisisatest"));
        }

        [Test]
        public void TestCamelCase_NullString()
        {
            Assert.AreEqual(0, Str.CamelCase(null));
        }
    }
}