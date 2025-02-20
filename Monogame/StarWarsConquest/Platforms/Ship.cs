// using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarsConquest;

class Ship: WeaponsPlatform
{
    private float evasion;
    public Ship(Texture2D texture, int width, string type, string className, int cost, float maxHealth, float maxShields, List<Weapon> weapons, float evasion): base(texture, width, type, className, cost, maxHealth, maxShields, weapons)
    {
        this.evasion = evasion;
    }

    // public override float GetStrength()
    // {
    //     float strength = 0;
    //     foreach ()
    // }
    
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