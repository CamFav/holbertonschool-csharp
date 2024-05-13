using NUnit.Framework;
using System.Collections.Generic;
using MyMath;

namespace MyMath.Tests
{
    [TestFixture]
    public class OperationsTests
    {
        [Test]
        public void Max_ListIsEmpty_ReturnsZero()
        {
            // Arrange
            List<int> nums = new List<int>();

            // Act
            int result = Operations.Max(nums);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Max_ListHasOneElement_ReturnsElement()
        {
            // Arrange
            List<int> nums = new List<int> { 5 };

            // Act
            int result = Operations.Max(nums);

            // Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Max_ListHasMultipleElements_ReturnsMax()
        {
            // Arrange
            List<int> nums = new List<int> { 3, 5, 2, 7, 1, 8 };

            // Act
            int result = Operations.Max(nums);

            // Assert
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Max_ListHasAllNegativeElements_ReturnsMax()
        {
            // Arrange
            List<int> nums = new List<int> { -3, -5, -2, -7, -1, -8 };

            // Act
            int result = Operations.Max(nums);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Max_ListHasDuplicates_ReturnsMax()
        {
            // Arrange
            List<int> nums = new List<int> { 3, 5, 2, 7, 7, 1, 8 };

            // Act
            int result = Operations.Max(nums);

            // Assert
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Max_ListHasZero_ReturnsMax()
        {
            // Arrange
            List<int> nums = new List<int> { 3, 5, 0, 7, 1, 8 };

            // Act
            int result = Operations.Max(nums);

            // Assert
            Assert.AreEqual(8, result);
        }
    }
}
