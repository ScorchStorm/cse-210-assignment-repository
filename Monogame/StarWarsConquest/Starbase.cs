using System;
using System.Collections.Generic;
namespace StarWarsConquest;

class Starbase: WeaponsPlatform
{
    private float repairRate;
    public Starbase(int cost, float maxHealth, float maxShields, List<Weapon> weapons, float repairRate): base(cost, maxHealth, maxShields, weapons)
    {
        this.repairRate = repairRate;
    }

    public float GetRepairRate()
    {
        return repairRate;
    }

    public void UpgradeRepairRate(float increase)
    {
        repairRate *= increase;
    }

    public void MakeRepair(Platform target)
    {
        target.Repair(repairRate);
    }
}