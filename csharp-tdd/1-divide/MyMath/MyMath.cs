using System;

namespace MyMath
{
    /// <summary>
    /// Represents a matrix
    /// </summary>
    public static class Matrix
    {
        /// <summary>
        /// Divide all elements of a Matrix
        /// </summary>
        /// <param name="matrix">The matrix to divide</param>
        /// <param name="num"> The number to divide each element of the matrix</param>
        /// <returns>Divided new matrix</returns>
        public static int[,] Divide(int[,] matrix, int num)
        {
            if (matrix == null)
                return (null);

            try
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);
                int[,] result = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        result[i, j] = matrix[i, j] / num;
                    }
                }

                return result;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Num cannot be 0");
                return null;
            }
        }
    }
}
