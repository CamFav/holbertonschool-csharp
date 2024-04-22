// Method that returns the sum of all the data of a LinkedList
using System;
using System.Collections.Generic;

class LList
{
    public static int Sum(LinkedList<int> myLList)
    {
        int sum = 0;

        foreach (int num in myLList)
        {
            sum += num;
        }
        return sum;
    }
}
