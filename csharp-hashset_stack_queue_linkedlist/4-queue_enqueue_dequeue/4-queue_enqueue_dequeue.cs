// Print the number of items in aQueue
// Print the item at the top of aQueue without removing it
// Add a new given item newItem to aQueue
// Print if aQueue contains a given item search
// If aQueue contains the given item search, remove all items up to and including search; otherwise, leave aQueue as is
// Return aQueue
using System;
using System.Collections.Generic;

class MyQueue
{
    public static Queue<string> Info(Queue<string> aQueue, string newItem, string search)
    {
        Console.WriteLine("Number of items: {0}", aQueue.Count);

        if (aQueue.Count == 0)
        {
            Console.WriteLine("Queue is empty");
        }
        else
        {
            Console.WriteLine("First item: {0}", aQueue.Peek());
        }

        aQueue.Enqueue(newItem);

        Console.WriteLine("Queue contains \"{0}\": {1}", search, aQueue.Contains(search));

        // Remove all items up to and including search.
        while (aQueue.Contains(search))
            aQueue.Dequeue();

        return aQueue;

    }
}
