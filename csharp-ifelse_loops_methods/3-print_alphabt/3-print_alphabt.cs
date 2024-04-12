using System;
class Program
{
    static void Main(string[] args)
    {
        for (char c = 'a'; c <= 'z'; c++) 
        {
            if (c != 'q' && c != 'e')
                Console.Write(c);
        }
    }
}
