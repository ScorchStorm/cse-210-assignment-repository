using System;
namespace StarWarsConquest;

class Admiral
{
    protected string name;
    protected string description;
    protected string type;
    protected int level;
    protected int movementSpeed;
    protected double attackStrength;
    protected double defenseStrength;
    protected int experience;

    public Admiral(string name, string description, string type)
    {
        this.name = name;
        this.description = description;
        this.type = type;
        level = 1;
        movementSpeed = 1;
        attackStrength = 1;
        defenseStrength = 1;
        experience = 0;
    }

    public virtual void LevelUp(){}

    // +------------+
    // |Level | Exp.|
    // |------+-----|
    // |  1   |   0 |
    // |  2   | 100 |
    // |  3   | 400 |
    // |  4   | 750 |
    // |  5   | 999 |
    // +------------+
    public void GainExperience(int experienceGain)
    {
        experience += experienceGain;
        if (experience >= 100)
        {
            if (level < 2)
            {
                LevelUp();
            }
            if (experience >= 400)
            {
                if (level < 3)
                {
                    LevelUp();
                }
                if (experience >= 750)
                {
                    if (level < 4)
                    {
                        LevelUp();
                    }
                    if (experience >= 999)
                    {
                        if (level < 5)
                        {
                            LevelUp();
                        }
                    }
                }
            }
        }
    }

    public void PrintStats()
    {
        Console.WriteLine($"Admiral {name}");
        Console.WriteLine($"Level {level}");
        Console.WriteLine($"{movementSpeed} movement speed");
        Console.WriteLine($"{100*attackStrength}% attack strength");
        Console.WriteLine($"{100*defenseStrength}% defense strength");
        Console.WriteLine($"{experience} experience points");
    }

    public string GetName()
    {
        return name;
    }

    public void SetMovementSpeed(int movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }

    public int GetExperience()
    {
        return experience;
    }

    public void SetAttackStrength(double attackStrength)
    {
        this.attackStrength = attackStrength;
    }

    public void SetDefenseStrength(double defenseStrength)
    {
        this.defenseStrength = defenseStrength;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public int GetMovementSpeed()
    {
        return movementSpeed;
    }

    public float GetAttackStrength()
    {
        return (float)attackStrength;
    }

    public float GetDefenseStrength()
    {
        return (float)defenseStrength;
    }

    public string GetDescription()
    {
        return description;
    }

    public string GetAdmiralType()
    {
        return type;
    }
}