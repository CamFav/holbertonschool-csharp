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

    // Retrieves the type of the derived class and formats the string
    public override string ToString()
    {
        return $"{name} is a {this.GetType().Name}";
    }
}
