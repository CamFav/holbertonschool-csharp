using System;

class Program
{
    static void Main()
    {
        for (int i = 0; i < 100; i++)
        {
            // Print the number with two digits
            if(i != 99)
                Console.Write("{0:D2}, ", i);
            else
            // If it's the last number, print a new line
                Console.Write("{0:D2}\n", i);
        }
    }
}
