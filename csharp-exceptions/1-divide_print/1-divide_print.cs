using System;
using System.Collections.Generic;

class Int
{
    public static void divide(int a, int b)
    {
        int c = 0;
        try
        {
            c = a / b;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Cannot divide by zero");
        }
        finally
        {
            Console.WriteLine("{0} / {1} = {2}", a, b, c);
        }
    }
}
