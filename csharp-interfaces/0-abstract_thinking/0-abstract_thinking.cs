using System;

/// <summary>
/// Abstract base class with a name property and ToString to override
/// </summary>
public abstract class Base
{
    /// <summary>
    /// Public name property of type string
    /// </summary>
    public string name { get; set; }

    /// <summary>
    /// Retrieves the type of the derived class and
    /// formats the string
    /// </summary>
    /// <returns> A string in the format: "name is a type". </returns>
    public override string ToString()
    {
        return $"{name} is a {this.GetType().Name}";
    }
}
