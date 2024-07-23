// using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarsConquest;

class Ship: WeaponsPlatform
{
    private float evasion;
    public Ship(Texture2D texture, float scale, string type, string className, int cost, float maxHealth, float maxShields, List<Weapon> weapons, float evasion): base(texture, scale, type, className, cost, maxHealth, maxShields, weapons)
    {
        this.evasion = evasion;
    }

    // public override float GetStrength()
    // {
    //     float strength = 0;
    //     foreach ()
    // }

    public void PrintStats()
    {
        Console.WriteLine($"name: {className}, shields: {shields}/{maxShields}, health: {health}/{maxHealth}");
    }

    // public float getHealth()
    // {
    //     return health;
    // }

    // public float getShields()
    // {
    //     return shields;
    // }

    // public float getMaxHealth()
    // {
    //     return maxHealth;
    // }

    // public float getMaxShields()
    // {
    //     return maxShields;
    // }

    public float GetEvasion()
    {
        return evasion;
    }

    public override void Defend(int points, float tracking)
    {
        Random rand = new Random();
        double shieldBlockRoll = (double)(shields/maxShields)/rand.NextDouble();
        double evasionRoll = (double)(evasion*health/maxHealth)*rand.NextDouble();
        // Console.WriteLine("");
        // Console.WriteLine($"shields = {shields}, maxShields = {maxShields}, (double)shields = {(double)shields}, (double)maxShields = {(double)maxShields}, ((double)shields) = {((double)shields)}, ((double)maxShields) = {((double)maxShields)}");
        // Console.WriteLine($"((float)shields) = {((float)shields)}, (double)(float)shields = {(double)(float)shields}");
        // Console.WriteLine($"Test: shields/maxShields = {shields/maxShields}, (double)(shields/maxShields) = {(double)(shields/maxShields)}, (double)shields/(double)maxShields = {(double)shields/(double)maxShields}, ((double)shields)/((double)maxShields) = {((double)shields)/((double)maxShields)}, rand.NextDouble() = {rand.NextDouble()}");
        // Console.WriteLine($"Test: shields/maxShields = {shields/maxShields}, (float)(shields/maxShields) = {(float)(shields/maxShields)}, (double)shields/(double)maxShields = {(float)shields/(float)maxShields}, ((double)shields)/((double)maxShields) = {((float)shields)/((float)maxShields)}, rand.NextDouble() = {rand.NextDouble()}");
        // Console.WriteLine($"className = {className}, evasion = {evasion}");
        // Console.WriteLine($"shields/maxShields = {shields/maxShields}, health/maxHealth = {health/maxHealth}");
        // Console.WriteLine($"evasionRoll = {evasionRoll}, tracking = {tracking}");
        // Console.WriteLine($"shieldBlockRoll = {shieldBlockRoll}");
        // Console.WriteLine($"damage = {points}");
        if (evasionRoll < tracking)
        {
            if (shieldBlockRoll < 1)
            {
                Console.WriteLine($"Direct Hit to ship hull of {className}");
                health -= points;
            }
            else
            {
                Console.WriteLine($"Weapons Fire Absorbed by shield of {className}");
                shields -= points;
            }
        }
        else
        {
            Console.WriteLine($"Weapon Evaded by {className}");
        }
    }
}