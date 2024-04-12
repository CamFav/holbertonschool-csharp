using System;

class Program
{
    static void Main(string[] args)
    {
        Random rndm = new Random();
        int number = rndm.Next(-10000, 10000);
        string str = "The last digit of";
        if (number % 10 > 5)
            Console.WriteLine("{0} {1} is" + " " + number % 10 + " and is greater than 5", str, number);
        else if (number % 10 < 6)
            Console.WriteLine("{0} {1} is" + " " + number % 10 + " and is less than 6 and not 0", str, number);
        else if (number % 10 == 0)
            Console.WriteLine("{0} {1} is" + " " + number % 10 + " and is 0", str, number);
    }
}
