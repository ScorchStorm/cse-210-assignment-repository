namespace StarWarsConquest;

class Admiral
{
    protected string name;
    protected string description;
    protected int level;
    protected int movementSpeed;
    protected double attackStrength;
    protected double defenseStrength;
    protected int experience;

    public Admiral(string name, string description)
    {
        this.name = name;
        this.description = description;
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

    public void SetMovementSpeed(int movementSpeed)
    {
        this.movementSpeed = movementSpeed;
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

    public float GetMovementSpeed()
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
}