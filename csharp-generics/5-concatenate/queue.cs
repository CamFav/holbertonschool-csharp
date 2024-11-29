﻿using System;


/// <summary>
/// Represents a generic queue data structure.
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
class Queue<T>
{
    /// <summary>
    /// Represents a node in the queue
    /// </summary>
    public class Node
    {
        public T value {get; set; }
        public Node next { get; set; }

        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }
    }

    private Node head;
    private Node tail;
    private int count;

    /// <summary>
    /// Returns the number of elements in the queue.
    /// </summary>
    public int Count()
    {
        return count;
    }

    /// <summary>
    /// Adds an element to the end of the queue
    /// </summary>
    /// <param name="item"> Element to add.</param>
    public void Enqueue(T item)
    {
        Node newNode = new Node(item);

        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.next = newNode;
            tail = newNode;
        }

        count++;
    }

    /// <summary>
    /// Removes the first node in the queue
    /// </summary>
    public T Dequeue()
    {
        if (head == null)
        {
            Console.WriteLine("Queue is empty");
            return default(T);
        }

        T value = head.value;
        head = head.next;

        if (head == null)
        {
            tail = null;
        }

        count--;
        return value;
    }

    /// <summary>
    /// Returns the value of the  first node
    /// </summary>
    public T Peek()
    {
        if (head == null)
        {
            Console.WriteLine("Queue is empty");
            return default(T);
        }

        return head.value;
    }

    /// <summary>
    /// Prints the queue
    /// </summary>
    public void Print()
    {
        if (head == null)
        {
            Console.WriteLine("Queue is empty");
            return;
        }

        Node current = head;

        while (current != null)
        {
            Console.WriteLine(current.value);
            current = current.next;
        }
    }

    /// <summary>
    /// Concatenates all values in the queue only if the queue is of type
    /// String or Char.
    /// </summary>
    public string Concatenate()
    {
        if (head == null)
        {
            Console.WriteLine("Queue is empty");
            return null;
        }

        // Check if the queue is of type string or char
        if (typeof(T) != typeof(string) && typeof(T) != typeof(char))
        {
            Console.WriteLine("Concatenate is for a queue of Strings or Chars only.");
            return null;
        }

        string result = ""; // Empty string for concatenation
        Node current = head;

        while (current != null)
        {
            result += current.value.ToString(); // Append the value to the result
            if (current.next != null && typeof(T) == typeof(string)) // Add a space between strings
            {
                result += " ";
            }
            current = current.next;
        }

        return result;
    }

    /// <summary>
    /// Returns the type of elements in the queue.
    /// </summary>
    public Type CheckType()
    {
        return typeof(T);
    }
}
