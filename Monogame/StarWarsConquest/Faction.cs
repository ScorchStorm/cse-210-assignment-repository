using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace StarWarsConquest;

class Faction
{
    // public string Name {get; private set;}
    private string name;
    private int credits;
    private StarSystem capital;
    private List<StarSystem> systems;
    private List<Fleet> fleets;
    private List<string> researchOptions;
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
    // static float scoutScale = 0.2f;
    // static float cruiserScale = 0.3f;
    // static float dreadnaughtScale = 0.4f;
    // static float starbaseScale = 0.6f;
    // static float advancedStarbaseScale = 0.7f;
    // static float turretScale = 0.3f;
    // static float miningStationScale = 0.4f;
    // static float researchStationScale = 0.4f;
    static int scoutWidth = 80;
    static int cruiserWidth = 100;
    static int dreadnaughtWidth = 120;
    static int starbaseWidth = 150;
    static int advancedStarbaseWidth = 170;
    static int turretWidth = 55;
    static int miningStationWidth = 160;
    static int researchStationWidth = 210;
    static int starbaseIndex = 0;
    static int industrialStationIndex = 1; // the index of the mining and research stations in the stations array in StarSystems
    Sprite insignia;
    static List<int> turretIndexes = new List<int>{2, 3, 4, 5, 6, 7, 8, 9};
    // public Faction(int credits, StarSystem capital, List<string> researchOptions, List<Admiral> admirals, float researchEfficiency, float miningEfficiency, float industry, float facilities, float maneuvering, float weaponStrength, float shieldStrength, float cost, float repairRate, float shipHealth, float stationHealth)
    // public Faction(string name, int credits, StarSystem capital, List<Admiral> admirals, List<string> researchOptions, float miningEfficiency, float industry, float facilities, float stationHealth, float maneuvering, float weaponStrength, float shieldStrength, float shipHealth, float cost, float researchEfficiency, float repairRate, string scoutClassName, Texture2D scoutTexture, string cruiserClassName, Texture2D cruiserTexture, string dreadnaughtClassName, Texture2D dreadnaughtTexture, string advancedStarbaseName, Texture2D advancedStarbaseTexture, Texture2D starbaseTexture, Texture2D turretTexture, Texture2D miningStationTexture, Texture2D researchStationTexture, Texture2D insigniaTexture)
    public Faction(Dictionary<string, Texture2D> textureDict, string name, int credits, StarSystem capital, List<Admiral> admirals, List<string> researchOptions, float miningEfficiency, float industry, float facilities, float stationHealth, float maneuvering, float weaponStrength, float shieldStrength, float shipHealth, float cost, float researchEfficiency, float repairRate, string scoutClassName, string cruiserClassName, string dreadnaughtClassName, string advancedStarbaseName, string insigniaName)
    {
        fleets = new List<Fleet>();
        researchOptions = new List<string>();
        systems = new List<StarSystem>();

        // Name = name;
        this.name = name;
        this.credits = credits;
        this.capital = capital;
        this.researchOptions = researchOptions;
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
        insignia = new Sprite(textureDict[insigniaName], 50);
        researchProgress = 0;
        rechargeRate = 1.0f;
        systems.Add(capital);

        scout = new Ship(textureDict[scoutClassName], scoutWidth, "Scout", scoutClassName, (int)(10*cost), (int)(100*shipHealth), (int)(100*shieldStrength), GetWeapons(1), 4);
        cruiser = new Ship(textureDict[cruiserClassName], cruiserWidth, "Cruiser", cruiserClassName, (int)(20*cost), (int)(200*shipHealth), (int)(200*shieldStrength), GetWeapons(2), 2);
        dreadnaught = new Ship(textureDict[dreadnaughtClassName], dreadnaughtWidth, "Dreadnaught", dreadnaughtClassName, (int)(50*cost), (int)(400*shipHealth), (int)(400*shieldStrength), GetWeapons(4), 1.5f);
        starbase = new Starbase(textureDict["Golan III Defense Platform"], starbaseWidth, "Starbase", "Golan III Defense Platform", (int)(50*cost), (int)(400*stationHealth), (int)(400*shieldStrength), GetWeapons(4), (float)(repairRate*0.20));
        if (name != "Neutral") // don't add structures for the neutral factions that are at each system
        {
            advancedStarbase = new Starbase(textureDict[advancedStarbaseName], advancedStarbaseWidth, "Advanced Starbase", advancedStarbaseName, (int)(100*cost), (int)(800*stationHealth), (int)(800*shieldStrength), GetWeapons(8), (float)(repairRate*0.40));
            turret = new Turret(textureDict["XQ1 Platform"], turretWidth, (int)(5*cost), (int)(100*shipHealth), (int)(100*shieldStrength), GetWeapons(0.5f));
            miningStation = new MiningStation(textureDict["Mining Station"], miningStationWidth, (int)(20*cost), (int)(200*stationHealth), (int)(200*shieldStrength), miningEfficiency);
            researchStation = new ResearchStation(textureDict["Research Station"], researchStationWidth, (int)(20*cost), (int)(200*stationHealth), (int)(200*shieldStrength), researchEfficiency);
            capital.AddStation(advancedStarbase, starbaseIndex);
            capital.AddStation(miningStation, industrialStationIndex);
            foreach (int i in turretIndexes) // you will need to change this if you change the indexes
                capital.AddStation(CreateNewTurret(), i);
        }
    }

    public void CreateInitialFleet(Admiral admiral = null, StarSystem starSystem = null)
    {
        List<int> neutralFleetConfig;
        List<List<int>> neutralFleetConfig1 = new List<List<int>>{new List<int>{3,0,0},new List<int>{4,0,0},new List<int>{4,0,2},new List<int>{4,0,2},new List<int>{3,1,3}};
        List<List<int>> neutralFleetConfig2 = new List<List<int>>{new List<int>{3,0,0},new List<int>{2,2,0},new List<int>{1,3,1},new List<int>{4,0,2},new List<int>{2,3,2}};
        // Console.WriteLine($"name = {name}");
        if (name != "Neutral")
            CreateNewFleet();
            // {
            //     if (admiral == null)
            //     {
            //         List<Admiral> admirals = GetAvailableAdmirals();
            //         int index = new Random().Next(admirals.Count);
            //         admiral = admirals[index];
            //     }
            //     Fleet fleet = new Fleet(admiral, this, starSystem);
            //     fleets.Add(fleet);
            // }
        else
        {
            // Console.WriteLine($"starSystem.GetStrategicValue() = {starSystem.GetStrategicValue()}");
            // Console.WriteLine($"starSystem.GetStrategicValue()-1 = {starSystem.GetStrategicValue()-1}");
            // Console.WriteLine($"neutralFleetConfig1[starSystem.GetStrategicValue()-1] = {neutralFleetConfig1[starSystem.GetStrategicValue()-1]}");
            int index2 = new Random().Next(2); // randomly choose a set of neutral fleet configurations
            if (index2 == 0)
                neutralFleetConfig = neutralFleetConfig1[starSystem.GetStrategicValue()-1];
            else
                neutralFleetConfig = neutralFleetConfig2[starSystem.GetStrategicValue()-1];
            if (admiral == null)
            {
                List<Admiral> admirals = GetAdmirals();
                int index1 = new Random().Next(admirals.Count);
                admiral = admirals[index1];
            }
            // Console.WriteLine($"passing in starSystem.GetName() = {starSystem.GetName()}");
            Fleet fleet = new Fleet(admiral, this, starSystem);
            // Console.WriteLine($"\nBefore:");
            // fleet.PrintShipStats();
            fleets.Add(fleet);
            // Console.WriteLine($"starSystem.GetName() = {starSystem.GetName()}, starSystem.GetStrategicValue() = {starSystem.GetStrategicValue()}, neutralFleetConfig = {neutralFleetConfig} = {neutralFleetConfig[0]}, {neutralFleetConfig[1]}, {neutralFleetConfig[2]}");
            // Console.WriteLine($"Neutral fleets are supposedly being created in {starSystem.GetName()}");
            for (int i = 0; i<neutralFleetConfig[0]; i++)
                fleet.BuildShipInEmptySlot(GetScout());
            for (int i = 0; i<neutralFleetConfig[1]; i++)
                fleet.BuildShipInEmptySlot(GetCruiser());
            for (int i = 0; i<neutralFleetConfig[2]; i++)
                fleet.BuildShipInEmptySlot(GetDreadnaught());
            // fleet.PrintShipStats();
            // Console.WriteLine($"fleet.GetSystem().GetName() = {fleet.GetSystem().GetName()}");
        }
    }

    public void NewTurn()
    {
        GetIncome();
        GetResearch();
        GetRepairs();

        foreach (Fleet fleet in fleets)
        {
            fleet.ResetMovementCounter();
        }
    }

    public List<int> GetTurretIndexes()
    {
        return turretIndexes;
    }

    public string GetName()
    {
        return name;
    }

    public List<Admiral> GetAvailableAdmirals()
    {
        List<Admiral> availableAdmirals = new List<Admiral>();
        List<Admiral> deployedAdmirals = new List<Admiral>();
        foreach (Fleet fleet in fleets)
            if (fleet != null)
                deployedAdmirals.Add(fleet.GetAdmiral());
            
        foreach (Admiral admiral in admirals)
            if (!deployedAdmirals.Contains(admiral))
                availableAdmirals.Add(admiral);
        
        return availableAdmirals;
    }

    public void AddNewShip(Fleet fleet, Ship newShip)
    {
        bool shipBuilt;
        int shipCost = newShip.GetCost();
        if (shipCost <= credits)
        {
            if (fleet.BuildShipInEmptySlot(newShip) == false)
                shipBuilt = fleet.ReplaceShipMenu(CreateNewShip(newShip));
            
            else
                shipBuilt = true;
            
            if (shipBuilt)
                credits -= shipCost;
        }
    }

    public Ship CreateNewShip(Ship ship)
    {
        return new Ship(ship.GetTexture(), ship.GetWidth(), ship.GetClassType(), ship.GetClassName(), ship.GetCost(), ship.GetHealth(), ship.GetShields(), ship.GetWeapons(), ship.GetEvasion());
    }

    public Ship GetScout()
    {
        return scout;
    }

    public Ship GetCruiser()
    {
        return cruiser;
    }

    public Ship GetDreadnaught()
    {
        return dreadnaught;
    }

    public Starbase GetStarbase()
    {
        return starbase;
    }

    public Starbase GetAdvancedStarbase()
    {
        return advancedStarbase;
    }

    public Turret GetTurret()
    {
        return turret;
    }
    
    public MiningStation GetMiningStation()
    {
        return miningStation;
    }
    
    public ResearchStation GetResearchStation()
    {
        return researchStation;
    }

    public void CreateNewFleet(Admiral admiral = null, StarSystem starSystem = null)
    {
        int newFleetCost = 40; // Change this later
        if (admiral == null)
        {
            List<Admiral> admirals = GetAvailableAdmirals();
            int index = new Random().Next(admirals.Count);
            admiral = admirals[index];
        }
        if (starSystem == null)
            starSystem = capital;
        if (newFleetCost <= credits || name == "Neutral")
        {
            Fleet fleet = new Fleet(admiral, this, starSystem);
            fleets.Add(fleet);
            starSystem.SetFleet(fleet);
            if (name != "Neutral")
                credits -= newFleetCost;
        }
    }

    public void AddNewStarbase(StarSystem starSystem, Starbase starbase)
    {
        int starbaseCost = starbase.GetCost();
        if (starbaseCost < credits)
        {
            credits -= starbaseCost;
            starSystem.AddStation(CreateNewStarbase(starbase), starbaseIndex);
        }
    }

    public Admiral ChooseAdmiral()
    {
        List<Admiral> availableAdmirals = GetAvailableAdmirals();
        List<string> choices = new List<string>();
        foreach (Admiral admiral in availableAdmirals)
            choices.Add($"{admiral.GetName()}\n{admiral.GetAdmiralType()}\n{admiral.GetDescription()}");
        Choice choice = new Choice("Which admiral would you like to command this fleet?", choices);
        int index = choice.MakeChoice();
        return admirals[index];
    }

    private Starbase CreateNewStarbase(Starbase starbase)
    {
        return new Starbase(starbase.GetTexture(), starbase.GetWidth(), starbase.GetClassType(), starbase.GetClassName(), starbase.GetCost(), starbase.GetHealth(), starbase.GetShields(), starbase.GetWeapons(), starbase.GetRepairRate());
    }

    public void AddNewTurrets(StarSystem starSystem)
    {
        Platform [] stations = starSystem.GetStations();
        int turretsCost = 4*turret.GetCost();
        if (turretsCost < credits)
        {
            credits -= turretsCost;
            int nTurrets1 = 0;
            int nTurrets2 = 0;
            int turrets1Health = 0;
            int turrets2Health = 0;
            for (int i = 0; i<4; i++)
            {
                if (stations[turretIndexes[i]] != null)
                {
                    nTurrets1 += 1;
                    turrets1Health += (int)stations[turretIndexes[i]].GetHealth();
                }
            }
            for (int i = 4; i<8; i++)
            {
                if (stations[turretIndexes[i]] != null)
                {
                    nTurrets2 += 1;
                    turrets2Health += (int)stations[turretIndexes[i]].GetHealth();
                }
            }
            // Console.WriteLine($"nTurrets1 = {nTurrets1}");
            // Console.WriteLine($"nTurrets2 = {nTurrets2}");
            if (nTurrets1 == 0) // if there are no turrets around the starbase, build the turrets there
            {
                starSystem.AddStation(CreateNewTurret(), turretIndexes[0]);
                starSystem.AddStation(CreateNewTurret(), turretIndexes[1]);
                starSystem.AddStation(CreateNewTurret(), turretIndexes[2]);
                starSystem.AddStation(CreateNewTurret(), turretIndexes[3]);
            }
            else if (nTurrets2 == 0) // if there are no turrets around the industrialStation, build the turrets there
            {
                starSystem.AddStation(CreateNewTurret(), turretIndexes[4]);
                starSystem.AddStation(CreateNewTurret(), turretIndexes[5]);
                starSystem.AddStation(CreateNewTurret(), turretIndexes[6]);
                starSystem.AddStation(CreateNewTurret(), turretIndexes[7]);
            }
            else // if there is at least 1 turret around each structure
            {
                // Choice choice1 = new Choice("there are no openings for new sets of turrets. Are you sure you want to replce existing turrets?", new List<string>{"Yes", "No"});
                // int index1 = choice1.MakeChoice(); // Ask if they really want to replce turrets
                // if (index1 == 0)
                // {
                if (nTurrets1 < nTurrets2) // if there are less turrets around the starbase, replace those turrets
                {
                    starSystem.AddStation(CreateNewTurret(), turretIndexes[0]);
                    starSystem.AddStation(CreateNewTurret(), turretIndexes[1]);
                    starSystem.AddStation(CreateNewTurret(), turretIndexes[2]);
                    starSystem.AddStation(CreateNewTurret(), turretIndexes[3]);
                }
                else if (nTurrets1 > nTurrets2) // if there are less turrets around the industrial station, replace those turrets
                {
                starSystem.AddStation(CreateNewTurret(), turretIndexes[4]);
                starSystem.AddStation(CreateNewTurret(), turretIndexes[5]);
                starSystem.AddStation(CreateNewTurret(), turretIndexes[6]);
                starSystem.AddStation(CreateNewTurret(), turretIndexes[7]);
                }
                else // if the same number of turrets are around both stations
                {
                    if (turrets1Health < turrets2Health) // if the turrets around the starbase have less health than the turrets around the industrial station, replace the turrets around the starbase
                    {
                        starSystem.AddStation(CreateNewTurret(), turretIndexes[0]);
                        starSystem.AddStation(CreateNewTurret(), turretIndexes[1]);
                        starSystem.AddStation(CreateNewTurret(), turretIndexes[2]);
                        starSystem.AddStation(CreateNewTurret(), turretIndexes[3]);
                    }
                    else // if not, just replace the turrets around the industrial station
                    {
                        starSystem.AddStation(CreateNewTurret(), turretIndexes[4]);
                        starSystem.AddStation(CreateNewTurret(), turretIndexes[5]);
                        starSystem.AddStation(CreateNewTurret(), turretIndexes[6]);
                        starSystem.AddStation(CreateNewTurret(), turretIndexes[7]);
                    }
                }
                // }
            }
        }
    }

    private Turret CreateNewTurret()
    {
        return new Turret(turret.GetTexture(), turret.GetWidth(), turret.GetCost(), turret.GetHealth(), turret.GetShields(), turret.GetWeapons());
    }

    public void AddNewMiningStation(StarSystem starSystem)
    {
        int miningStationCost = miningStation.GetCost();
        if (miningStationCost <= credits)
        {
            starSystem.AddStation(CreateNewMiningStation(), industrialStationIndex);
        }
    }

    private MiningStation CreateNewMiningStation()
    {
        return new MiningStation(miningStation.GetTexture(), miningStation.GetWidth(), miningStation.GetCost(), miningStation.GetHealth(), miningStation.GetShields(), miningStation.GetMiningRate());
    }

    public void AddNewResearchStation(StarSystem starSystem)
    {
        int researchStationCost = researchStation.GetCost();
        if (researchStationCost <= credits)
        {
            starSystem.AddStation(CreateNewResearchStation(), industrialStationIndex);
        }
    }

    private ResearchStation CreateNewResearchStation()
    {
        return new ResearchStation(researchStation.GetTexture(), researchStation.GetWidth(), researchStation.GetCost(), researchStation.GetHealth(), researchStation.GetShields(), researchStation.GetResearchRate());
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

    public void GetRepairs()
    {
        foreach (StarSystem system in systems)
            system.GetRepairs();
    }

    public List<Admiral> GetAdmirals()
    {
        return admirals;
    }

    // public string GetFactionName()
    // {
    //     return name;
    // }

    public void GetResearch()
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

    public void RemoveFleet(Fleet fleet)
    {
        int index = fleets.IndexOf(fleet);
        fleets[index] = null;
    }


    public StarSystem GetCapital()
    {
        return capital;
    }

    public int GetCredits()
    {
        return credits;
    }

    public List<StarSystem> GetSystems()
    {
        return systems;
    }

    public void MoveFleet(Fleet fleet, StarSystem newSystem)
    {
        fleet.Move(newSystem);
    }

    public void AddNewSystem(StarSystem system)
    {
        systems.Add(system);
        Console.WriteLine($"{system.GetName()} has been added to the systems list of {name}");
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