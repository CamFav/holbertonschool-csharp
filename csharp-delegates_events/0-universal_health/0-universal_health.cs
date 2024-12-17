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
}
