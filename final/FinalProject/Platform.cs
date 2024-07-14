class Platform
{
    protected float maxHealth;
    protected float health;
    protected float maxShields;
    protected float shields;
    public Platform(float maxHealth, float maxShields)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
        this.maxShields = maxShields;
        shields = maxShields;
    }

    public virtual void Defend(int points, float tracking)
    {
        Random rand = new Random();
        double shieldBlockRoll = shields/maxShields/rand.NextDouble();
        if (shieldBlockRoll < 1)
        {
            health -= points;
        }
        else
        {
            shields -= points;
        }
    }

    public float GetHealth()
    {
        return health;
    }

    public void Repair(float fraction)
    {
        if (fraction >= (maxHealth-health)/maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += (int)(fraction*maxHealth);
        }
    }

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void SetMaxShields(int maxShields)
    {
        this.maxShields = maxShields;
    }
}