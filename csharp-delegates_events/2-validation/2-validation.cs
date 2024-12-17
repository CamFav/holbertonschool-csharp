using System;

/// <summary>
/// Player with a name, maximum health, and current health
/// </summary>
public class Player
{
    /// <summary>
    /// Name of the Player
    /// </summary>
    private string name { get; set; }

    /// <summary>
    /// Maximum health
    /// </summary>
    private float maxHp { get; set; }

    /// <summary>
    /// Current health
    /// </summary>
    private float hp { get; set; }

    /// <summary>
    /// Delegate to calculate health changes.
    /// </summary>
    public delegate void CalculateHealth(float amount);

    /// <summary>
    /// Initializes new instance of the Player
    /// </summary>
    /// <param name="name">The name of the Player</param>
    /// <param name="maxHp">The maximum health of the player</param>
    public Player(string name = "Player", float maxHp = 100f)
    {
        this.name = name;

        if (maxHp > 0)
        {
            this.maxHp = maxHp;
        }
        else
        {
            this.maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }

        this.hp = this.maxHp;
    }

    /// <summary>
    /// Prints player name with his current health status
    /// </summary>
    public void PrintHealth()
    {
        Console.WriteLine($"{name} has {hp} / {maxHp} health");
    }

    /// <summary>
    /// Reduces the player's health by a specified damage amount.
    /// </summary>
    /// <param name="damage">The amount of damage taken.</param>
    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            Console.WriteLine($"{name} takes 0 damage!");
            ValidateHP(hp);
        }
        else
        {
            Console.WriteLine($"{name} takes {damage} damage!");
            float newHp = hp - damage;
            ValidateHP(newHp);
        }
    }

    /// <summary>
    /// Increases the player's health by a specified healing amount.
    /// </summary>
    /// <param name="heal">The amount of health points to heal.</param>
    public void HealDamage(float heal)
    {
        if (heal < 0)
        {
            Console.WriteLine($"{name} heals 0 HP!");
            ValidateHP(hp);
        }
        else
        {
            Console.WriteLine($"{name} heals {heal} HP!");
            float newHp = hp + heal;
            ValidateHP(newHp);
        }
    }

    /// <summary>
    /// Validates and updates the player's current health
    /// </summary>
    /// <param name="newHp">The new value to set for hp</param>
    public void ValidateHP(float newHp)
    {
        if (newHp < 0)
        {
            hp = 0;
        }
        else if (newHp > maxHp)
        {
            hp = maxHp;
        }
        else
        {
            hp = newHp;
        }
    }
}
