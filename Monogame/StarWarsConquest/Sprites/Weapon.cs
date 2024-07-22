using System;
// using System.Collections.Generic;
namespace StarWarsConquest;

class Weapon
{
    private float rechargeRate; // How quickly the weapon can recharge and fire again
    private float maxDamage;
    private float tracking;
    private float speed; // will only be used in the animation
    private float rechargeTime; // How long it has been since the last time the weapon fired
    public Weapon(float rechargeRate, float maxDamage, float tracking, float speed)
    {
        this.rechargeRate = rechargeRate;
        this.maxDamage = maxDamage;
        this.tracking = tracking;
        this.speed = speed;
        this.rechargeTime = 0;
    }

    public float GetAverageDPS()
    {
        return (float)maxDamage/2*rechargeRate;
    }

    public void AttemptToFire(Platform target, float bonus)
    {
        rechargeTime += (float)0.5;
        if (rechargeTime > 1/rechargeRate)
        {
            Fire(target, bonus);
            rechargeTime = 0;
        }
        else
        {
            // Console.WriteLine($"1/rechargeRate = {1/rechargeRate}");
            Console.WriteLine($"Weapon Not Reloaded Yet");
        }
    }

    public void Fire(Platform target, float bonus)
    {
        Random rand = new Random();
        int damage = (int)(maxDamage*bonus*rand.NextDouble());
        target.Defend(damage, tracking);
    }

    public void SetTracking(float tracking)
    {
        this.tracking = tracking;
    }

    public void SetMaxDamage(float maxDamage)
    {
        this.maxDamage = maxDamage;
    }

    public void SetRechargeRate(float rechargeRate)
    {
        this.rechargeRate = rechargeRate;
    }
}