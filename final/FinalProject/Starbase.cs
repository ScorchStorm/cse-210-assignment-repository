class Starbase: WeaponsPlatform
{
    private float repairRate;
    public Starbase(int maxHealth, int maxShields, List<Weapon> weapons, float repairRate): base(maxHealth, maxShields, weapons)
    {
        this.repairRate = repairRate;
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