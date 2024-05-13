using NUnit.Framework;
using MyMath;

namespace MyMath.Tests
{
    [TestFixture]
    public class OperationsTests
    {
        [Test]
        public void Add_WhenCalled_ReturnsSumOfTwoNumbers()
        {
            // Arrange
            int a = 3;
            int b = 5;

            // Act
            int result = Operations.Add(a, b);

            // Assert
            Assert.AreEqual(8, result);
        }
    }
}