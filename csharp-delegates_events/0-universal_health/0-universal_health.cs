using System;

/// <summary>
/// 
/// </summary>
public class Player
{
    private string _name;
    private float _maxHp;
    private float _hp;

    /// <summary>
    /// 
    /// </summary>
    public string Name
    {
        get { return _name; }
    }

    /// <summary>
    /// 
    /// </summary>
    public float MaxHp
    {
        get { return _maxHp; }
    }

    /// <summary>
    /// 
    /// </summary>
    public float Hp
    {
        get { return _hp; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="maxHp"></param>
    public Player(string name = "Player", float maxHp = 100f)
    {
        _name = name;

        if (maxHp > 0)
        {
            _maxHp = maxHp;
        }
        else
        {
            _maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }

        _hp = _maxHp;
    }

    /// <summary>
    /// 
    /// </summary>
    public void PrintHealth()
    {
        Console.WriteLine($"{_name} has {_hp} / {_maxHp} health");
    }
}
