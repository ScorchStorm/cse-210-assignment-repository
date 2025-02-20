// using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarsConquest;

class Starbase: WeaponsPlatform
{
    private float repairRate;
    public Starbase(Texture2D texture, int width, string type, string className, int cost, float maxHealth, float maxShields, List<Weapon> weapons, float repairRate): base(texture, width, type, className, cost, maxHealth, maxShields, weapons)
    {
        this.repairRate = repairRate;
        this.className = className;
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