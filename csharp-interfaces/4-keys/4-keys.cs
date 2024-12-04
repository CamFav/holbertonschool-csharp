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
public class Door : Base, IInteractive
{
    /// <summary>
    /// Constructor to initialize the name property with a default value.
    /// </summary>
    /// <param name="name">The name of the door.</param>
    public Door(string name = "Door")
    {
        this.name = name;
    }

    /// <summary>
    /// Method to interact with the door.
    /// </summary>
    public void Interact()
    {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}

/// <summary>
/// 
/// </summary>
public class Decoration : Base, IInteractive, IBreakable
{
    /// <summary>
    /// Gets or sets the durability of the object.
    /// </summary>
    public int durability { get; set; }

    /// <summary>
    /// Indicates whether the decoration is a quest item.
    /// </summary>
    public bool isQuestItem { get; set; }

    /// <summary>
    /// Constructor to initialize the decoration with specified or default values.
    /// </summary>
    /// <param name="name">The name of the decoration.</param>
    /// <param name="durability">The durability of the decoration.</param>
    /// <param name="isQuestItem">Indicates if the decoration is a quest item.</param>
    public Decoration(string name = "Decoration", int durability = 1, bool isQuestItem = false)
    {
        if (durability <= 0)
            throw new Exception("Durability must be greater than 0");

        this.name = name;
        this.durability = durability;
        this.isQuestItem = isQuestItem;
    }

    /// <summary>
    /// Method to interact with the decoration.
    /// </summary>
    public void Interact()
    {
        if (durability <= 0)
        {
            Console.WriteLine($"The {name} has been broken.");
        }
        else if (isQuestItem)
        {
            Console.WriteLine($"You look at the {name}. There's a key inside.");
        }
        else
        {
            Console.WriteLine($"You look at the {name}. Not much to see here.");
        }
    }

     /// <summary>
    /// Method to break the decoration.
    /// </summary>
    public void Break()
    {
        if (durability > 0)
        {
            durability--;
            if (durability > 0)
            {
                Console.WriteLine($"You hit the {name}. It cracks.");
            }
            else
            {
                Console.WriteLine($"You smash the {name}. What a mess.");
            }
        }
        else
        {
            Console.WriteLine($"The {name} is already broken.");
        }
    }
}

public class Key : Base, ICollectable
{
    /// <summary>
    /// Gets or sets wether the key is collected.
    /// </summary>
    public bool isCollected { get; set; }

    /// <summary>
    /// Constructor to initialize the key with specified or default values.
    /// </summary>
    /// <param name="name">The name of the key.</param>
    /// <param name="isCollected">Indicates if the key is collected.</param>
    public Key(string name = "Key", bool isCollected = false)
    {
        this.name = name;
        this.isCollected = isCollected;
    }

    /// <summary>
    /// Method to collect the key.
    /// </summary>
    public void Collect()
    {
        if (!isCollected)
        {
            isCollected = true;
            Console.WriteLine($"You pick up the {name}.");
        }
        else
        {
            Console.WriteLine($"You have already picked up the {name}.");
        }
    }
}
