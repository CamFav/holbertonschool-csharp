using System;

public class Queue<T>
{
    /// <summary>
    /// Returns the type of the generic parameter T.
    /// </summary>
    /// <returns>String representing the type of T.</returns>
    public string CheckType()
    {
        return typeof(T).ToString(); // Gets the runtime type of T
    }
}
