using System;

class Array
{
    public static int elementAt(int[] array, int index)
    {
        // Get the length of the array
        int length = array.GetLength(0);

        if (index < 0 || index >= length)
        {
            Console.WriteLine("Index out of range");
            return -1;
        }
        else
        {
            return array[index];
        }
    }
}
