using System;
using System.Collections.Generic;

class List
{
    public static int Sum(List<int> myList)
    {
        HashSet<int> uniqueInt = new HashSet<int>(myList);

        int sum = 0;
        foreach (int num in uniqueInt)
        {
            sum += num;
        }
        return sum;
    }
}
