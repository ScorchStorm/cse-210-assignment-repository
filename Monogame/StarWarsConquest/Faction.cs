using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace StarWarsConquest;

class Faction
{
    private string name;
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
    private float scoutScale = 0.02f;
    private float cruiserScale = 0.03f;
    private float dreadnaughtScale = 0.04f;
    private float starbaseScale = 0.06f;
    private float advancedStarbaseScale = 0.07f;
    private float turretScale = 0.03f;
    private float miningStationScale = 0.04f;
    private float researchStationScale = 0.04f;

    // public Faction(int credits, StarSystem capital, List<string> researchOptions, List<Admiral> admirals, float researchEfficiency, float miningEfficiency, float industry, float facilities, float maneuvering, float weaponStrength, float shieldStrength, float cost, float repairRate, float shipHealth, float stationHealth)
    // public Faction(string name, int credits, StarSystem capital, List<Admiral> admirals, List<string> researchOptions, float miningEfficiency, float industry, float facilities, float stationHealth, float maneuvering, float weaponStrength, float shieldStrength, float shipHealth, float cost, float researchEfficiency, float repairRate, string scoutClassName, Texture2D scoutTexture, string cruiserClassName, Texture2D cruiserTexture, string dreadnaughtClassName, Texture2D dreadnaughtTexture, string advancedStarbaseName, Texture2D advancedStarbaseTexture, Texture2D starbaseTexture, Texture2D turretTexture, Texture2D miningStationTexture, Texture2D researchStationTexture, Texture2D insigniaTexture)
    public Faction(Dictionary<string, Texture2D> textureDict, string name, int credits, StarSystem capital, List<Admiral> admirals, List<string> researchOptions, float miningEfficiency, float industry, float facilities, float stationHealth, float maneuvering, float weaponStrength, float shieldStrength, float shipHealth, float cost, float researchEfficiency, float repairRate, string scoutClassName, string cruiserClassName, string dreadnaughtClassName, string advancedStarbaseName)
    {
        this.name = name;
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
        rechargeRate = 1.0f;
        
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

        scout = new Ship(textureDict[scoutClassName], scoutScale, "Scout", scoutClassName, (int)(10*cost), (int)(100*shipHealth), (int)(100*shieldStrength), GetWeapons(1), 4);
        cruiser = new Ship(textureDict[cruiserClassName], cruiserScale, "Cruser", cruiserClassName, (int)(20*cost), (int)(200*shipHealth), (int)(200*shieldStrength), GetWeapons(2), 2);
        dreadnaught = new Ship(textureDict[dreadnaughtClassName], dreadnaughtScale, "Dreadnaught", dreadnaughtClassName, (int)(50*cost), (int)(400*shipHealth), (int)(400*shieldStrength), GetWeapons(4), 1.5f);
        starbase = new Starbase(textureDict["Starbase"], starbaseScale, "Starbase", "Golan III Defense Platform", (int)(50*cost), (int)(400*stationHealth), (int)(400*shieldStrength), GetWeapons(4), (float)(repairRate*0.40));
        advancedStarbase = new Starbase(textureDict[advancedStarbaseName], advancedStarbaseScale, "Advanced Starbase", advancedStarbaseName, (int)(100*cost), (int)(800*stationHealth), (int)(800*shieldStrength), GetWeapons(8), (float)(repairRate*0.60));
        turret = new Turret(textureDict["XQ1 Platform"], turretScale, (int)(5*cost), (int)(100*shipHealth), (int)(100*shieldStrength), GetWeapons(0.5f));
        miningStation = new MiningStation(textureDict["Mining Station"], miningStationScale, (int)(20*cost), (int)(200*stationHealth), (int)(200*shieldStrength), miningEfficiency);
        researchStation = new ResearchStation(textureDict["Research Station"], researchStationScale, (int)(20*cost), (int)(200*stationHealth), (int)(200*shieldStrength), researchEfficiency);

        // Weapon sithPrimaryWeapon = new Weapon(basePrimaryWeaponRechargeRate, sithWeaponStrength*basePrimaryWeaponDamage, basePrimaryWeaponTracking, basePrimaryWeaponSpeed);
        // Weapon sithSecondaryWeapon = new Weapon(baseSecondaryWeaponRechargeRate, sithWeaponStrength*baseSecondaryWeaponDamage, baseSecondaryWeaponTracking, baseSecondaryWeaponSpeed);
        // List<Weapon> sithWeapons = new List<Weapon>{sithPrimaryWeapon, sithSecondaryWeapon};
        // Starbase starbase = new Starbase(baseStarbaseHealth, baseStarbaseShields, sithWeapons, sithRepairRate);
        // Starbase advancedStarbase = Starbase(baseAdvancedStarbaseHealth, baseAdvancedStarbaseShields, sithWeapons, 2*sithRepairRate);
        // MiningStation miningStation = MiningStation();
        // ResearchStation researchStation = ResearchStation();
        // Turret turret = Turret();
        
        // Fleet fleetOne = new Fleet(admirals[0], scout, cruiser, dreadnaught, this);
        // fleets.Add(fleetOne);
        // AddNewShip(fleetOne, dreadnaught);
        // AddNewShip(fleetOne, dreadnaught);
        // AddNewShip(fleetOne, dreadnaught);
        // AddNewShip(fleetOne, dreadnaught);
        // Console.WriteLine("{name} fleet:");
        // fleetOne.PrintShipStats();
    }

    public void AddNewShip(Fleet fleet, Ship newShip)
    {
        int shipCost = newShip.GetCost();
        if (shipCost <= credits)
        {
            fleet.CreateNewShip(CreateNewShip(newShip));
            credits -= shipCost;
            Console.WriteLine($"{newShip.GetClassName()} has been built for {shipCost} credits. You now have {credits} credits");
        }
    }

    // private Ship CreateNewShip(Ship ship)
    // {
    //     return new Ship(ship.GetTexture(), ship.GetScale(), ship.GetClassType(), ship.GetClassName(), ship.GetCost(), ship.GetHealth(), ship.GetShields(), ship.GetWeapons(), ship.GetEvasion());
    // }

    public Ship CreateNewShip(Ship ship)
    {
        return new Ship(ship.GetTexture(), ship.GetScale(), ship.GetClassType(), ship.GetClassName(), ship.GetCost(), ship.GetHealth(), ship.GetShields(), ship.GetWeapons(), ship.GetEvasion());
    }

    public Ship getDreadnaught()
    {
        return dreadnaught;
    }

    public void CreateNewFleet()
    {
        int newFleetCost = 40; // Change this later
        if (newFleetCost <= credits)
        {
            Fleet fleet = new Fleet(admirals[0], scout, cruiser, dreadnaught, this);
            fleets.Add(fleet);
        }
    }

    private void AddNewStarbase(StarSystem starSystem, Starbase starbase)
    {
        int starbaseCost = starbase.GetCost();
        if (starbaseCost <= credits)
        {
            credits -= starbaseCost;
            starSystem.AddStation(CreateNewStarbase(starbase));
        }
    }

    private Starbase CreateNewStarbase(Starbase starbase)
    {
        return new Starbase(starbase.GetTexture(), starbase.GetScale(), starbase.GetClassType(), starbase.GetClassName(), starbase.GetCost(), starbase.GetHealth(), starbase.GetShields(), starbase.GetWeapons(), starbase.GetRepairRate());
    }

    private void AddNewTurrets(StarSystem starSystem)
    {
        int turretsCost = 4*turret.GetCost();
        if (turretsCost <= credits)
        {
            starSystem.AddStation(turret);
            starSystem.AddStation(turret);
            starSystem.AddStation(turret);
            starSystem.AddStation(turret);
        }
    }

    private Turret CreateNewTurret()
    {
        return new Turret(turret.GetTexture(), turret.GetScale(), turret.GetCost(), turret.GetHealth(), turret.GetShields(), turret.GetWeapons());
    }

    private void AddNewMiningStation(StarSystem starSystem)
    {
        int miningStationCost = miningStation.GetCost();
        if (miningStationCost <= credits)
        {
            starSystem.AddStation(miningStation);
        }
    }

    private MiningStation CreateNewMiningStation()
    {
        return new MiningStation(miningStation.GetTexture(), miningStation.GetScale(), miningStation.GetCost(), miningStation.GetHealth(), miningStation.GetShields(), miningStation.GetMiningRate());
    }

    private void AddNewResearchStation(StarSystem starSystem)
    {
        int researchStationCost = researchStation.GetCost();
        if (researchStationCost <= credits)
        {
            starSystem.AddStation(researchStation);
        }
    }

    private ResearchStation CreateNewResearchStation()
    {
        return new ResearchStation(researchStation.GetTexture(), researchStation.GetScale(), researchStation.GetCost(), researchStation.GetHealth(), researchStation.GetShields(), researchStation.GetResearchRate());
    }

    public List<Weapon> GetWeapons(float rechargeModifier)
    {
        float basePrimaryWeaponDamage = 50;
        float basePrimaryWeaponRechargeRate = 0.2f;
        float basePrimaryWeaponSpeed = 4.0f;
        float basePrimaryWeaponTracking = 1.0f;
        float baseSecondaryWeaponDamage = 50;
        float baseSecondaryWeaponRechargeRate = 0.4f;
        float baseSecondaryWeaponSpeed = 1.0f;
        float baseSecondaryWeaponTracking = 3.0f;
        Weapon primaryWeapon = new Weapon(rechargeModifier*basePrimaryWeaponRechargeRate*rechargeRate, basePrimaryWeaponDamage*weaponStrength, basePrimaryWeaponTracking, basePrimaryWeaponSpeed);
        Weapon secondaryWeapon = new Weapon(rechargeModifier*baseSecondaryWeaponRechargeRate*rechargeRate, baseSecondaryWeaponDamage*weaponStrength, baseSecondaryWeaponTracking, baseSecondaryWeaponSpeed);
        List<Weapon> weapons = new List<Weapon>{primaryWeapon, secondaryWeapon};
        return weapons;
    }

    public void GetIncome()
    {
        float income = 0;
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

    public List<Fleet> GetFleets()
    {
        return fleets;
    }


    public StarSystem GetCapital()
    {
        return capital;
    }

    public void MoveFleet(Fleet fleet, StarSystem newSystem)
    {
        fleet.Move(newSystem);
    }

    public void UpgardeFleetHealth(float increase, Ship shipType)
    {
        foreach (Fleet fleet in fleets)
        {
            foreach (Ship ship in fleet.GetShips())
            {
                if (shipType.GetClassName() == ship.GetClassName())
                {
                    ship.SetMaxHealth((int)(increase*shipType.GetHealth()));
                }
            }
        }
    }
    
    public void UpgardeStationHealth(float increase, Platform stationType)
    {
        foreach (StarSystem system in systems)
        {
            foreach (Platform station in system.GetStations())
            {
                if (station.GetClassName() == station.GetClassName())
                {
                    station.SetMaxHealth((int)(increase*stationType.GetHealth()));
                }
            }
        }
    }
}