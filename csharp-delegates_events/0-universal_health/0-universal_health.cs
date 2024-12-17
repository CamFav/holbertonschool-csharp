using System;

/// <summary>
/// 
/// </summary>
public class Player
{
    /// <summary>
    /// 
    /// </summary>
    private string name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    private float maxHp { get; set; }

    /// <summary>
    /// 
    /// </summary>
    private float hp { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="maxHp"></param>
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
    /// 
    /// </summary>
    public void PrintHealth()
    {
        Console.WriteLine($"{name} has {hp} / {maxHp} health");
    }
}
