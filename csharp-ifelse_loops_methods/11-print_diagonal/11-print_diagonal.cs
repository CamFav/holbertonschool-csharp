using System;

public class Line
{
    public static void PrintDiagonal(int length)
    {
        if (length <= 0)
        {
            Console.WriteLine();
            return;
        }

        for (int i = 0; i < length; i++)
        {
            // Print spaces before the \
            for (int j = 0; j < i; j++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("\\");
        }
        Console.WriteLine();
    }
}
