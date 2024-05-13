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

        [Test]
        public void negativeInt()
        {
            int result = Operations.Add(2, -12);

            Assert.AreEqual(-10, result);
        }
        
        [Test]
        public void bothNegativeInt()
        {
            int result = Operations.Add(-10, -10);

            Assert.AreEqual(-20, result);
        }

        [Test]
        public void ZeroInt()
        {
            int result = Operations.Add(0, -30);

            Assert.AreEqual(-30, result);
        }

         [Test]
        
        public void BothZeroInt()
        {
            int result = Operations.Add(0, 0);

            Assert.AreEqual(0, result);
        }
    }
}