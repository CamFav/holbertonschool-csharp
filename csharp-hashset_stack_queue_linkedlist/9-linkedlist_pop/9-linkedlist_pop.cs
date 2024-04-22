// method that deletes the head node of a LinkedList and returns that node’s data.
using System;
using System.Collections.Generic;

class LList
{
    public static int Pop(LinkedList<int> myLList)
    {
        int headValue;

        if (myLList.Count == 0)
        {
            return (0);
        }
        headValue = myLList.First.Value;
        myLList.RemoveFirst();
        return headValue;
    }
}
