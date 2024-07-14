class Faction
{
    private int credits;
    private StarSystem capital;
    private List<StarSystem> systems = new List<StarSystem>();
    private List<Fleet> fleets = new List<Fleet>();
    private List<string> researchOptions = new List<string>();
    private float researchProgress;
    private Ship scout;
    private Ship cruiser;
    private Ship dreadnaught;
    private Starbase starbase;
    private Starbase advancedStarbase;
    private MiningStation miningStation;
    private ResearchStation researchStation;
    private Turret turret;
    private List<Admiral> admirals;
    private float researchEfficiency;
    private float miningEfficiency;
    private float industry;
    private float facilities;
    private float maneuvering;
    private float weaponStrength;
    private float shieldStrength;
    private float cost;
    private float repairRate;
    private float rechargeRate;

    // public Faction(int credits, StarSystem capital, List<string> researchOptions, List<Admiral> admirals, float researchEfficiency, float miningEfficiency, float industry, float facilities, float maneuvering, float weaponStrength, float shieldStrength, float cost, float repairRate, float shipHealth, float stationHealth)
    public Faction(int credits, StarSystem capital, List<Admiral> admirals, List<string> researchOptions, float miningEfficiency, float industry, float facilities, float stationHealth, float maneuvering, float weaponStrength, float shieldStrength, float shipHealth, float cost, float researchEfficiency, float repairRate, string scoutClassName, string cruiserClassName, string dreadnaughtClassName)
    {
        this.credits = credits;
        this.capital = capital;
        this.researchOptions = researchOptions;
        researchProgress = 0;
        systems.Add(capital);
        this.admirals = admirals;
        this.researchEfficiency = researchEfficiency;
        this.miningEfficiency = miningEfficiency;
        this.industry = industry;
        this.facilities = facilities;
        this.maneuvering = maneuvering;
        this.weaponStrength = weaponStrength;
        this.shieldStrength = shieldStrength;
        this.cost = cost;
        this.repairRate = repairRate;
        rechargeRate = (float)1.0;
        
        // int baseScoutHealth = 100;
        // int baseScoutShields = 100;
        // int baseScoutCost = 10;
        // float baseScoutWeapons = (float)1.0;
        // float baseScoutEvasion = (float)2.0;
        // int baseCruiserHealth = 200;
        // int baseCruiserShields = 200;
        // int baseCruiserCost = 20;
        // float baseCruiserWeapons = (float)2.0;
        // float baseCruiserEvasion = (float)1.0;
        // int baseDreadnaughtHealth = 400;
        // int baseDreadnaughtShields = 400;
        // int baseDreadnaughtCost = 50;
        // float baseDreadnaughtWeapons = (float)4.0;
        // float baseDreadnaughtEvasion = (float)0.5;
        // int baseStarbaseHealth = 400;
        // int baseStarbaseShields = 400;
        // float baseStarbaseWeapons = (float)4.0;
        // int baseAdvancedStarbaseHealth = 800;
        // int baseAdvancedStarbaseShields = 800;
        // float baseAdvancedStarbaseWeapons = (float)8.0;

        this.scout = new Ship((int)(100*shipHealth), (int)(100*shieldStrength), GetWeapons(1), 4, (int)(10*cost), scoutClassName);
        this.cruiser = new Ship((int)(200*shipHealth), (int)(200*shieldStrength), GetWeapons(2), 2, (int)(20*cost), cruiserClassName);
        this.dreadnaught = new Ship((int)(400*shipHealth), (int)(400*shieldStrength), GetWeapons(4), (float)1.5, (int)(50*cost), dreadnaughtClassName);
        this.starbase = new Starbase((int)(400*stationHealth), (int)(400*shieldStrength), GetWeapons(4), (float)(repairRate*0.40));
        this.advancedStarbase = new Starbase((int)(800*stationHealth), (int)(800*shieldStrength), GetWeapons(8), (float)(repairRate*0.60));
        this.turret = new Turret((int)(100*shipHealth), (int)(100*shieldStrength), GetWeapons((float)0.5));
        this.miningStation = new MiningStation((int)(200*stationHealth), (int)(200*shieldStrength), miningEfficiency);
        this.researchStation = new ResearchStation((int)(200*stationHealth), (int)(200*shieldStrength), researchEfficiency);

        // Weapon sithPrimaryWeapon = new Weapon(basePrimaryWeaponRechargeRate, sithWeaponStrength*basePrimaryWeaponDamage, basePrimaryWeaponTracking, basePrimaryWeaponSpeed);
        // Weapon sithSecondaryWeapon = new Weapon(baseSecondaryWeaponRechargeRate, sithWeaponStrength*baseSecondaryWeaponDamage, baseSecondaryWeaponTracking, baseSecondaryWeaponSpeed);
        // List<Weapon> sithWeapons = new List<Weapon>{sithPrimaryWeapon, sithSecondaryWeapon};
        // Starbase starbase = new Starbase(baseStarbaseHealth, baseStarbaseShields, sithWeapons, sithRepairRate);
        // Starbase advancedStarbase = Starbase(baseAdvancedStarbaseHealth, baseAdvancedStarbaseShields, sithWeapons, 2*sithRepairRate);
        // MiningStation miningStation = MiningStation();
        // ResearchStation researchStation = ResearchStation();
        // Turret turret = Turret();
        
        Fleet fleetOne = new Fleet(admirals[0], scout, cruiser, dreadnaught, this);
        CreateNewShip(fleetOne, dreadnaught);
        CreateNewShip(fleetOne, dreadnaught);
        CreateNewShip(fleetOne, dreadnaught);
        CreateNewShip(fleetOne, dreadnaught);
        fleets.Add(fleetOne);
    }

    public List<Weapon> GetWeapons(float rechargeModifier)
    {
        int basePrimaryWeaponDamage = 20;
        float basePrimaryWeaponRechargeRate = (float)0.2;
        float basePrimaryWeaponSpeed = (float)4.0;
        float basePrimaryWeaponTracking = (float)1.0;
        int baseSecondaryWeaponDamage = 20;
        float baseSecondaryWeaponRechargeRate = (float)0.4;
        float baseSecondaryWeaponSpeed = (float)1.0;
        float baseSecondaryWeaponTracking = (float)3.0;
        Weapon primaryWeapon = new Weapon(rechargeModifier*basePrimaryWeaponRechargeRate*rechargeRate, basePrimaryWeaponDamage*weaponStrength, basePrimaryWeaponTracking, basePrimaryWeaponSpeed);
        Weapon secondaryWeapon = new Weapon(rechargeModifier*baseSecondaryWeaponRechargeRate*rechargeRate, baseSecondaryWeaponDamage*weaponStrength, baseSecondaryWeaponTracking, baseSecondaryWeaponSpeed);
        List<Weapon> weapons = new List<Weapon>{primaryWeapon, secondaryWeapon};
        return weapons;
    }

    public void GetIncome()
    {
        float income = (float)(0);
        foreach (StarSystem system in systems)
        {
            income += system.GetIncome(industry, miningEfficiency);
        }
        credits += (int)income;
    }

    public void Research()
    {
        foreach (StarSystem system in systems)
        {
            researchProgress += system.GetResearch(researchEfficiency);
        }

    }

    public void ChooseResearch()
    {

    }

    public void TakeTurn()
    {

    }

    public Fleet GetFleet(int index)
    {
        return fleets[index];
    }


    public StarSystem GetCapital()
    {
        return capital;
    }

    public void MoveFleet(Fleet fleet, StarSystem newSystem)
    {
        fleet.Move(newSystem);
    }

    public void CreateNewShip(Fleet fleet, Ship newShip)
    {
        if (newShip.GetCost() >= credits)
        {
            fleet.CreateNewShip(newShip);
            credits -= newShip.GetCost();
        }
    }
}