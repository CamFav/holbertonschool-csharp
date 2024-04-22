// method that returns the value of the nth node of a LinkedList.
using System;
using System.Collections.Generic;

class LList
{
    public static int GetNode(LinkedList<int> myLList, int n)
    {
        if (n < 0 || n >= myLList.Count)
            return 0;

        LinkedListNode<int> current = myLList.First;
        for (int i = 0; i < n; i++)
        {
            current = current.Next;
        }

        return current.Value;
    }
}
