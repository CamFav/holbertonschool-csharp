using System;

public class VectorMath
{
    /// <summary>
    /// Calcul the magnitude of a 2D or 3D Vector
    /// </summary>
    /// <param name="vector">Vector</param>
    /// <returns>Returns the length of a given vector.</returns>
    public static double Magnitude(double[] vector)
    {
        if (vector.Length == 2)
            return Math.Round(Math.Sqrt(Math.Pow(vector[0], 2) + Math.Pow(vector[1], 2)), 2);
        else if (vector.Length == 3)
            return Math.Round(Math.Sqrt(Math.Pow(vector[0], 2) + Math.Pow(vector[1], 2) + Math.Pow(vector[2], 2)), 2);
        else
            return -1;
    }
}
