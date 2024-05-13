using NUnit.Framework;
using System;
using MyMath;

namespace MyMath.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Divide_MatrixIsNull_ReturnsNull()
        {
            // Arrange
            int[,] matrix = null;
            int num = 2;

            // Act
            int[,] result = MyMath.Matrix.Divide(matrix, num);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Divide_DivideByZero_ReturnsNull()
        {
            // Arrange
            int[,] matrix = new int[,] { { 1, 2 }, { 3, 4 } };
            int num = 0;

            // Act
            int[,] result = MyMath.Matrix.Divide(matrix, num);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Divide_DivideByPositiveNumber_ReturnsCorrectResult()
        {
            // Arrange
            int[,] matrix = new int[,] { { 2, 4 }, { 6, 8 } };
            int num = 2;
            int[,] expectedResult = new int[,] { { 1, 2 }, { 3, 4 } };

            // Act
            int[,] result = MyMath.Matrix.Divide(matrix, num);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Divide_DivideByNegativeNumber_ReturnsCorrectResult()
        {
            // Arrange
            int[,] matrix = new int[,] { { 2, 4 }, { 6, 8 } };
            int num = -2;
            int[,] expectedResult = new int[,] { { -1, -2 }, { -3, -4 } };

            // Act
            int[,] result = MyMath.Matrix.Divide(matrix, num);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
