using System;

class Array
{
    public static int[] ReplaceElement(int[] array, int index, int n)
    {
        // Get the length of the array
        int length = array.GetLength(0);

        if (index < 0 || index >= length)
        {
            Console.WriteLine("Index out of range");
            return array;
        }
        else
        {
            array[index] = n;
            return array;
        }
    }
}
