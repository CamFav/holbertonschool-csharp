using System;

class Program
{
    static void Main(string[] args)
    {
        Random rndm = new Random();
        int number = rndm.Next(-10000, 10000);
        string str = "The last digit of";
        int last_digit = number % 10;
        if (last_digit > 5)
            Console.WriteLine("{0} {1} is {3} and is greater than 5", str, number, last_digit);
        else if (last_digit == 0)
            Console.WriteLine("{0} {1} is {3} and is 0", str, number, last_digit);
        else (last_digit < 6)
            Console.WriteLine("{0} {1} is {3} and is less than 6 and not 0", str, number, last_digit);
    }
}
