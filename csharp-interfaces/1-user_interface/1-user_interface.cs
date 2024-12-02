using System;

/// <summary>
/// Abstract base class with a name property and ToString to override.
/// </summary>
public abstract class Base
{
    /// <summary>
    /// Public name property of type string.
    /// </summary>
    public string name { get; set; }

    /// <summary>
    /// Retrieves the type of the derived class and
    /// formats the string.
    /// </summary>
    /// <returns>A string in the format: "name is a type".</returns>
    public override string ToString()
    {
        return $"{name} is a {this.GetType().Name}";
    }
}

/// <summary>
/// Interface for interactive objects.
/// </summary>
public interface IInteractive
{
    /// <summary>
    /// Method to interact with the object.
    /// </summary>
    void Interact();
}

/// <summary>
/// Interface for breakable objects.
/// </summary>
public interface IBreakable
{
    /// <summary>
    /// Gets or sets the durability of the object.
    /// </summary>
    int durability { get; set; }

    /// <summary>
    /// Method to break the object.
    /// </summary>
    void Break();
}

/// <summary>
/// Interface for collectable objects.
/// </summary>
public interface ICollectable
{
    /// <summary>
    /// Gets or sets whether the object is collected.
    /// </summary>
    bool isCollected { get; set; }

    /// <summary>
    /// Method to collect the object.
    /// </summary>
    void Collect();
}

/// <summary>
/// TestObject class inheriting from Base and implementing IInteractive, IBreakable, and ICollectable.
/// </summary>
public class TestObject : Base, IInteractive, IBreakable, ICollectable
{
    /// <summary>
    /// Gets or sets the durability of the object.
    /// </summary>
    public int durability { get; set; }

    /// <summary>
    /// Gets or sets whether the object is collected.
    /// </summary>
    public bool isCollected { get; set; }

    /// <summary>
    /// Method to interact with the object.
    /// </summary>
    public void Interact()
    {
        // Minimal implementation
    }

    /// <summary>
    /// Method to break the object.
    /// </summary>
    public void Break()
    {
        // Minimal implementation
    }

    /// <summary>
    /// Method to collect the object.
    /// </summary>
    public void Collect()
    {
        // Minimal implementation
    }
}
