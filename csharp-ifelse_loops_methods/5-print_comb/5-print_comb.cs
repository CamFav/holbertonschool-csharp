using System;

class Program
{
    static void Main()
    {
        for (int i = 0; i < 100; i++)
        {
            // Print the number with two digits
            Console.Write($"{i:D2}");

            // If it's not the last number, print ", "
            if (i != 99)
            {
                Console.Write(", ");
            }
            // If it's the last number, print a new line
            else
            {
                Console.WriteLine();
            }
        }
    }
}
