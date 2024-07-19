using System;
using System.Collections.Generic;
namespace StarWarsConquest;

class Platform
{
    private int cost;
    protected float maxHealth;
    protected float health;
    protected float maxShields;
    protected float shields;
    public Platform(int cost, float maxHealth, float maxShields)
    {
        this.cost = cost;
        this.maxHealth = maxHealth;
        health = maxHealth;
        this.maxShields = maxShields;
        shields = maxShields;
    }

    public int GetCost()
    {
        return cost;
    }

    public void SetCost(int cost)
    {
        this.cost = cost;
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

    public float GetShields()
    {
        return shields;
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