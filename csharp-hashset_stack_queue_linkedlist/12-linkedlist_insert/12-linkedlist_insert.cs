// Method that inserts a new node in the correct position in an ordered LinkedList.
using System;
using System.Collections.Generic;

class LList
{
    public static LinkedListNode<int> Insert(LinkedList<int> myLList, int n)
    {
        LinkedListNode<int> newNode = new LinkedListNode<int>(n);

        if (myLList.First == null || myLList.First.Value > n)
        {
            myLList.AddFirst(newNode);
            return newNode;
        }

        LinkedListNode<int> current = myLList.First;
        while (current.Next != null && current.Next.Value < n)
        {
            current = current.Next;
        }

        myLList.AddAfter(current, newNode);

        return newNode;
    }
}
