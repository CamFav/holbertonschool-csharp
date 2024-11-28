using System;

public class Queue<T>
{
    /// <summary>
    /// Returns the type of the generic parameter T.
    /// </summary>
    /// <returns>String representing the type of T.</returns>
    public Type CheckType()
    {
        return typeof(T); // Gets the runtime type of T
    }
}
