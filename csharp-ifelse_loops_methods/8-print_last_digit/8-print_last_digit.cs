using System;

class Number
{
    public static int PrintLastDigit(int number)
    {
        int lastDigit = Math.Abs(number) % 10; // Get the last digit using modulo operator
        Console.Write(lastDigit);
        return lastDigit;
    }
}