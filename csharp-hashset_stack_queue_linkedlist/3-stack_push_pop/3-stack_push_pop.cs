// Print the number of items in aStack
// Print the item at the top of aStack without removing it
// Print if aStack contains a given item search
// If aStack contains the given item search, remove all items up to and including search; otherwise, leave aStack as is
// Add a new given item newItem to aStack and
using System;
using System.Collections.Generic;

class MyStack
{
    public static Stack<string> Info(Stack<string> aStack, string newItem, string search)
    {
        Console.WriteLine("Number of items: {0}", aStack.Count);

        if (aStack.Count == 0)
        {
            Console.WriteLine("Stack is empty");
        }
        else
        {
            Console.WriteLine("Top item: {0}", aStack.Peek());
        }

        Console.WriteLine("Stack contains \"{0}\": {1}", search, aStack.Contains(search));

        // Remove all items up to and including search.
        while (aStack.Contains(search))
            aStack.Pop();

        aStack.Push(newItem);

        return aStack;

    }
}
