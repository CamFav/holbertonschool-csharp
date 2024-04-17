using System;

class List
{
    public static List<int> CreatePrint(int size)
    {
        if (size < 0)
        {
            Console.WriteLine("Size cannot be negative");
            return null;
        }

        List<int> newList = new List<int>();

        int i = 0;
        while (i < size)
        {
            newList.Add(i);
            Console.Write(i + " ");
            i++;
        }
        Console.WriteLine();

        return newList;
    }
}
