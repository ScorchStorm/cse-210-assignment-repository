// using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarsConquest;

class WeaponsPlatform: Platform
{
    protected List<Weapon> weapons = new List<Weapon>();
    
    // protected float RechargeRate;
    public WeaponsPlatform(Texture2D texture, int width, string type, string className, int cost, float maxHealth, float maxShields, List<Weapon> weapons): base(texture, width, type, className, cost, maxHealth, maxShields)
    {
        this.weapons = weapons;
    }

    public List<Weapon> GetWeapons()
    {
        return weapons;
    }

    public float GetTotalDPS()
    {
        float TotalDPS = 0;
        foreach (Weapon weapon in weapons)
        {
            TotalDPS += weapon.GetAverageDPS();
        }
        return TotalDPS;
    }

    public float GetStrength()
    {
        float TotalDPS = GetTotalDPS();
        return TotalDPS*(health + shields/2);
    }

    public float GetTargetPriority()
    {
        float TotalDPS = GetTotalDPS();
        if (shields >= 0)
            return TotalDPS/(health + shields/2);
        else
            return TotalDPS/health;
    }

    public void Attack(Platform target, float bonus)
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.AttemptToFire(target, bonus);
        }
    }

    public void SetTracking(float tracking)
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.SetTracking(tracking);
        }
    }

    public void SetMaxDamage(float maxDamage)
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.SetMaxDamage(maxDamage);
        }
    }

    public void SetRechargeRate(float rechargeRate)
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.SetRechargeRate(rechargeRate);
        }
    }
}