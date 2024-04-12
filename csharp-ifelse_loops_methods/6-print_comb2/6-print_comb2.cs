using System;

class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            for (i = 0; i < 8; i++) {
                for (j = 1; j <= 9; j++) {
                    if (i < j) {
                        Console.Write("{0}{1}, ", i, j);
                    }
                }
            }
            Console.WriteLine("89");
        }
    }
