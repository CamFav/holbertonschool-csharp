using System;

class Array
{
    public static void Reverse(int[] array)
    {
        if (array == null)
        {
            return;
        }

        for (int i = array.Length - 1; i >= 0; i--)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}