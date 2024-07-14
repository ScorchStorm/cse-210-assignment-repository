class WeaponsPlatform: Platform
{
    protected List<Weapon> weapons = new List<Weapon>();
    // protected float RechargeRate;
    public WeaponsPlatform(float maxHealth, float maxShields, List<Weapon> weapons): base(maxHealth, maxShields)
    {
        this.weapons = weapons;
    }
    public WeaponsPlatform(float maxHealth, float maxShields, Weapon weapon): base(maxHealth, maxShields)
    {
        weapons = new List<Weapon>{weapon};
    }

    public float GetStrength()
    {
        float TotalDPS = 0;
        foreach (Weapon weapon in weapons)
        {
            TotalDPS += weapon.GetAverageDPS();
        }
        return TotalDPS*(health + shields/2);
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