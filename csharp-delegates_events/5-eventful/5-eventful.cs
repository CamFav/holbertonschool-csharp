using System;

/// <summary>
/// Modifiers for base values
/// </summary>
public enum Modifier
{
    /// <summary>
    /// Represents a weak modifier, which reduces the base value by half.
    /// </summary>
    Weak,

    /// <summary>
    /// Represents the base modifier, which keeps the base value unchanged.
    /// </summary>
    Base,

    /// <summary>
    /// Represents a strong modifier, which increases the base value by 1.5 times.
    /// </summary>
    Strong
}

/// <summary>
/// Delegate to calculate a modified value based on a base value and a modifier
/// </summary>
/// <param name="baseValue">The base value to modify</param>
/// <param name="modifier">The modifier to apply</param>
/// <returns>The modified value</returns>
public delegate float CalculateModifier(float baseValue, Modifier modifier);

/// <summary>
/// Delegate to calculate health changes.
/// </summary>
public delegate void CalculateHealth(float amount);

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
    /// Current status of the player
    /// </summary>
    private string status { get; set; }

    /// <summary>
    /// Event triggered when the player's HP is validated.
    /// </summary>
    public event EventHandler<CurrentHPArgs> HPCheck;

    /// <summary>
    /// Initializes new instance of the Player
    /// </summary>
    /// <param name="name">The name of the Player</param>
    /// <param name="maxHp">The maximum health of the player</param>
    public Player(string name = "Player", float maxHp = 100f, string status = "Undefined")
    {
        this.name = name;

        if (maxHp <= 0)
        {
            this.maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }
        else
        {
            this.maxHp = maxHp;
        }

        this.hp = this.maxHp;

        if (status == "Undefined")
        {
            this.status = $"{name} is ready to go!";
        }

        HPCheck += CheckStatus;
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
            float newHp = Math.Max(hp - damage, 0);
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
        }
        else
        {
            Console.WriteLine($"{name} heals {heal} HP!");
            float newHp = Math.Min(hp + heal, maxHp);
            ValidateHP(newHp);
        }
    }

    /// <summary>
    /// Validates and updates the player's current health
    /// </summary>
    /// <param name="newHp">The new value to set for hp</param>
    public void ValidateHP(float newHp)
    {
        if (newHp <= 0)
        {
            this.hp = 0;
        }
        else if (newHp >= maxHp)
        {
            this.hp = maxHp;
        }
        else
        {
            this.hp = newHp;
        }
        OnCheckStatus(new CurrentHPArgs(this.hp));
    }

    /// <summary>
    /// Applies a modifier to a base value and returns the result
    /// </summary>
    /// <param name="baseValue">The base value to modify</param>
    /// <param name="modifier">The modifier to apply</param>
    /// <returns>The modified value</returns>
    public float ApplyModifier(float baseValue, Modifier modifier)
    {
        switch (modifier)
        {
            case Modifier.Weak:
                return baseValue * 0.5f;
            case Modifier.Base:
                return baseValue;
            case Modifier.Strong:
                return baseValue * 1.5f;
            default:
                throw new ArgumentOutOfRangeException(nameof(modifier), modifier, null);
        }
    }

    /// <summary>
    /// Handles the HPCheck event: prints the current status.
    /// </summary>
    /// <param name="sender">Event source</param>
    /// <param name="e">Event data</param>
    private void CheckStatus(object sender, CurrentHPArgs e)
    {
        if (e.currentHp == maxHp)
            status = $"{name} is in perfect health!";
        else if (e.currentHp >= maxHp / 2 && e.currentHp < maxHp)
            status = $"{name} is doing well!";
        else if (e.currentHp >= maxHp / 4 && e.currentHp < maxHp / 2)
            status = $"{name} isn't doing too great...";
        else if (e.currentHp > 0 && e.currentHp < maxHp / 4)
            status = $"{name} needs help!";
        else if (e.currentHp == 0)
            status = $"{name} is knocked out!";

        Console.WriteLine(status);
    }

    /// <summary>
    /// Handles warnings when the player's health value is low or reaches zero
    /// </summary>
    /// <param name="sender">The source of the event</param>
    /// <param name="e">An instance of <see cref="CurrentHPArgs"/> containing the player's current health.</param>
    private void HPValueWarning(object sender, CurrentHPArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        if (e.currentHp == 0)
        {
            Console.WriteLine("Health has reached zero!");
        }
        else
        {
            Console.WriteLine("Health is low!");
        }
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Checks the player's health and triggers a warning if it falls below 25%
    /// </summary>
    /// <param name="e">An instance of <see cref="CurrentHPArgs"/> containing the player's current health.</param>
    private void OnCheckStatus(CurrentHPArgs e)
    {
        CheckStatus(HPCheck, e);

        if (e.currentHp <= (this.maxHp * 0.25))
        {
            HPValueWarning(this, e);
        }
    }
}

/// <summary>
/// Event arguments class to hold the current HP value
/// </summary>
public class CurrentHPArgs : EventArgs
{
    /// <summary>
    /// Gets the current HP value
    /// </summary>
    public readonly float currentHp;

    /// <summary>
    /// Initializes a new instance of the CurrentHPArgs class
    /// </summary>
    /// <param name="newHp">The new HP value</param>
    public CurrentHPArgs(float newHp)
    {
        this.currentHp = newHp;
    }
}
