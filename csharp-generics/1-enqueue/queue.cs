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
    /// Returns the number of elements in the queue.
    /// </summary>
    public int Count()
    {
        return count;
    }
    
    /// <summary>
    /// Returns the type of elements in the queue.
    /// </summary>
    public Type CheckType()
    {
        return typeof(T);
    }
}
