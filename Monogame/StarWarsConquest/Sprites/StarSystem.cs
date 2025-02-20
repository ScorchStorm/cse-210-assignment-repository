using System;
using System.Collections.Generic;
using System.Threading;

namespace StarWarsConquest;

// class StarSystem: Sprite
class StarSystem: Sprite
{
    private bool isCapital;
    private string name;
    // private Platform [] stations = {null, null, null, null, null, null, null, null, null, null};
    private Platform [] stations;
    private List<Platform> stationList;
    private List<WeaponsPlatform> armedStations;
    private Fleet fleet;
    private int strategicValue;
    private List<StarSystem> hyperlanes;
    private string description;
    private Faction faction;
    private static Dictionary<string, int> xpDict = new() {{"Scout", 8}, {"Cruiser", 10}, {"Dreadnaught", 14}, {"Turret", 5}, {"Mining Station", 15}, {"Research Station", 15}, {"Starbase", 25}, {"Advanced Starbase", 50}};
    int starbaseIndex = 0;
    
    public StarSystem(bool isCapital, Texture2D texture, Vector2 position, string name, int strategicValue, string description): base(texture, position/5, 50)
    {
        stations = new Platform [] {null, null, null, null, null, null, null, null, null, null};
        armedStations = new List<WeaponsPlatform>();
        hyperlanes = new List<StarSystem>();
        stationList = new List<Platform>();
        this.name = name;
        this.strategicValue = strategicValue;
        this.description = description;
        this.isCapital = isCapital;
    }

    public void RemoveStation(Platform station)
    {
        Console.WriteLine($"{station.GetClassName()} has been destroyed!");
        if  (station is WeaponsPlatform weaponsPlatform)
            armedStations.Remove(weaponsPlatform);
        
        int index = Array.IndexOf(stations, station);
        stationList.Remove(station);
        stations[index] = null;
    }

    public void AddStation(Platform station, int index)
    {
        stations[index] = station;
    }

    public void AddHyperLane(StarSystem starSystem)
    {
        hyperlanes.Add(starSystem);
    }

    // public void PrintArmedStationStats()
    // {
    //     armedStations = GetArmedStations();
    //     foreach (WeaponsPlatform weaponsPlatform in armedStations)
    //         Console.WriteLine(weaponsPlatform.GetStats());
    // }

    public void PrintStationStats()
    {
        foreach (Platform station in stations)
            if (station != null)
                Console.WriteLine(station.GetStats());
    }

    public float GetIncome(float industry, float miningEfficiency)
    {
        float income = 3+4*strategicValue*industry;
        foreach (Platform station in stations)
            if (station is MiningStation miningStation)
                income += (int)0.7*(strategicValue+1)*miningEfficiency;
        
        return income;
    }

    public void GetRepairs()
    {
        Starbase starbase = GetStarbase();
        if (starbase != null)
        {
            float repairRate = starbase.GetRepairRate();
            foreach (Platform station in stationList)
                station.Repair(repairRate);
            if (fleet != null)
            {
                fleet.Repair(starbase);
            }
        }
    }

    public bool GetIsCapital()
    {
        return isCapital;
    }

    // public void CreateNeutralFleet(Faction neutral)
    // {
    //     List<Admiral> admirals = neutral.GetAdmirals();
    //     Random random = new Random();
    //     int index = random.Next(admirals.Count);
    //     Admiral admiral = admirals[index];
    //     neutral.CreateNewFleet(this, admiral);
    // }

    public float GetResearch(float researchEfficiency)
    {
        float research = 0;
        foreach (Platform station in stations)
            if (station is ResearchStation researchStation)
                research = researchEfficiency;

        return research;
    }

    public void DisplayDescription()
    {
        Console.WriteLine(description);
    }

    public List<StarSystem> GetHyperlanes()
    {
        return hyperlanes;
    }

    public void SetFleet(Fleet fleet)
    {
        this.fleet = fleet;
    }
    public Fleet GetFleet()
    {
        return fleet;
    }

    public int GetStationCount()
    {
        int stationCount = 0;
        foreach (Platform station in stations)
        {
            if (station != null)
            {
                stationCount += 1;
            }
        }
        return stationCount;
    }

    public void Battle(Fleet invadingFleet)
    {
        // Console.WriteLine($"invadingFleet.GetShipCount() = {invadingFleet.GetShipCount()}");
        // Console.WriteLine($"fleet.GetShipCount() = {fleet.GetShipCount()}");
        invadingFleet.PrintAllShipStats();
        fleet.PrintAllShipStats();
        List<string> initialInvadingPlatformTypes = invadingFleet.GetShipTypes();
        List<string> initialDefendingPlatformTypes = GetPlatformTypes();
        // Console.WriteLine("Updating Ship Stats Now");
        // invadingFleet.UpdateShipList();
        // fleet.UpdateShipList();
        // Console.WriteLine($"fleet.GetAdmiral().GetName() = {fleet.GetAdmiral().GetName()}");
        // Console.WriteLine("Printing fleet ship stats now");
        // fleet.PrintShipStats();
        // Console.WriteLine($"invadingFleet = {invadingFleet}");
        // Console.WriteLine($"invadingFleet.GetAdmiral().GetName() = {invadingFleet.GetAdmiral().GetName()}");
        // Console.WriteLine("Printing invadingFleet's Ship Stats now");
        // invadingFleet.PrintShipStats();
        float attackBonus = invadingFleet.GetAdmiral().GetAttackStrength();
        float defendBonus = 0;
        if (fleet != null)
            defendBonus = fleet.GetAdmiral().GetDefenseStrength();
        Console.WriteLine($"invadingFleet.GetShipCount() = {invadingFleet.GetShipCount()}");
        Console.WriteLine($"fleet.GetShipCount() = {fleet.GetShipCount()}");
        Console.WriteLine($"GetStationCount() = {GetStationCount()}");
        while (invadingFleet.GetShipCount() != 0 && fleet.GetShipCount()+GetStationCount() != 0)
        {
            Console.WriteLine($"GetStationCount() = {GetStationCount()}");
            Console.WriteLine("The battle loop has begun");
            foreach (Ship ship in invadingFleet.GetShipList())
            {
                Platform invadingTarget = GetTargetPriority();
                if (invadingTarget == null)
                    break;
                ship.Attack(invadingTarget, attackBonus);
                // if (invadingTarget.GetHealth() <= 0)
                    // if (invadingTarget is Ship ship1)
                    //     fleet.RemoveShip(ship1);
                    // else
                    //     RemoveStation(invadingTarget);
                UpdateStationList();
                fleet.UpdateShipList();
            }
            foreach (Ship ship in fleet.GetShipList())
            {
                Ship target = invadingFleet.GetTargetPriority();
                if (target == null)
                    break;
                ship.Attack(target, defendBonus);
                // invadingFleet.RemoveShip(target);
                // if (target == null)
                //     invadingFleet.RemoveShip(target);
                // if (target.GetHealth() <= 0)
                //     invadingFleet.RemoveShip(target);
                invadingFleet.UpdateShipList();
            }
            armedStations = GetArmedStations();
            foreach (WeaponsPlatform weaponsPlatform in armedStations)
            {
                WeaponsPlatform target = invadingFleet.GetTargetPriority();
                weaponsPlatform.Attack(target, defendBonus);
                invadingFleet.UpdateShipList();
            }
            PrintBattleInfo(invadingFleet);
            Thread.Sleep(1000);
        }
        // invadingFleet.UpdateShipList();
        // fleet.UpdateShipList();
        // if (invadingFleet == null)
        // {
        //     Console.WriteLine("The invading fleet has been destroyed");
        // }
        // if (fleet == null)
        // {
        //     Console.WriteLine("The defending fleet has been destroyed");
        // }
        if (invadingFleet.GetShipCount() == 0)
        {
            Console.WriteLine("The invading fleet has been destroyed");
            // invadingFleet.SetSystem(null);
            invadingFleet.GetSystem().SetFleet(null);
            invadingFleet.GetFaction().RemoveFleet(invadingFleet);
        }
        else // only keep track of the experience gained by a fleet that has not been destroyed
        {
            Console.WriteLine($"{invadingFleet.GetAdmiral().GetName()} has earned some xp");
            Console.WriteLine($"initial xp: {invadingFleet.GetAdmiral().GetExperience()}");
            List<string> finalDefendingPlatformTypes = GetPlatformTypes();
            int xp = GetEarnedXP(initialDefendingPlatformTypes, finalDefendingPlatformTypes);
            invadingFleet.GetAdmiral().GainExperience(xp);
            Console.WriteLine($"final xp: {invadingFleet.GetAdmiral().GetExperience()}");
        }
        if (fleet.GetShipCount() == 0)
        {
            Console.WriteLine("The defending fleet has been destroyed");
            fleet.GetFaction().RemoveFleet(fleet);
        }
        else // only keep track of the experience gained by a fleet that has not been destroyed
        {
            List<string> finalInvadingPlatformTypes = invadingFleet.GetShipTypes();
            int xp = GetEarnedXP(initialInvadingPlatformTypes, finalInvadingPlatformTypes);
            fleet.GetAdmiral().GainExperience(xp);
        }
    }

    public int GetEarnedXP(List<string> initialPlatforms, List<string> finalPlatforms)
    {
        int xp = 0;
        int n = 0;
        if (initialPlatforms.Count != finalPlatforms.Count) // if the number of platforms hasn't changed, then no platforms were destroyed, and no xp was earned
        {
            for (int i = 0; i<initialPlatforms.Count-1; i++)
            {
                if (n+1 > finalPlatforms.Count)
                    xp += xpDict[initialPlatforms[i]];
                else if (initialPlatforms[i] != finalPlatforms[n])
                    xp += xpDict[initialPlatforms[i]];
                else
                    n += 1;
            }
        }
        return xp;
    }

    public void PrintBattleInfo(Fleet invadingFleet)
    {
        if (invadingFleet.GetShipCount() > 0)
        {
            Console.WriteLine("");
            Console.WriteLine("Invading Fleet");
            invadingFleet.PrintShipStats();
            Console.WriteLine("");
        }
        if (fleet.GetShipCount() > 0)
        {
            Console.WriteLine("Defending Fleet");
            fleet.PrintShipStats();
            Console.WriteLine("");
        }
        if (GetStationCount() > 0)
        {
            Console.WriteLine("Stations");
            PrintStationStats();
            Console.WriteLine("");
        }
    }

    public float GetStrength()
    {
        float strength = 0;
        foreach (var station in stations)
            if (station is WeaponsPlatform weaponsPlatform)
                strength += weaponsPlatform.GetStrength();
        
        return strength;
    }

    public Platform GetTargetPriority()
    {
        float maxPriority = 0; // if target is null, the maxPriority should be 0
        WeaponsPlatform target = fleet.GetTargetPriority();
        if (target != null)
            maxPriority = target.GetTargetPriority();
        foreach (WeaponsPlatform station in GetArmedStations())
        {
            float priority = station.GetTargetPriority();
            if (priority > maxPriority)
            {
                maxPriority = priority;
                target = station;
            }
        }
        if (target == null)
            foreach (Platform station in stations)
                if (station != null)
                    return station;
        return target;
    }

    public Platform[] GetStations()
    {
        return stations;
    }

    public List<StarSystem> HyperLanes()
    {
        return hyperlanes;
    }

    public List<string> GetPlatformNames()
    {
        List<string> platformNames = new List<string>();
        foreach (Platform station in stations)
            if (station != null)
                platformNames.Add(station.GetClassName());
        
        if (fleet != null)
            foreach (Ship ship in fleet.GetShipList())
                platformNames.Add(ship.GetClassName());
        return platformNames;
    }

    public List<string> GetPlatformTypes()
    {
        List<string> platformTypes = new List<string>();
        foreach (Platform station in stations)
            if (station != null)
                platformTypes.Add(station.GetClassType());
        
        if (fleet != null)
            foreach (Ship ship in fleet.GetShipList())
                platformTypes.Add(ship.GetClassType());
        return platformTypes;
    }

    public List<string> GetStationNames()
    {
        List<string> stationNames = new List<string>();
        foreach (Platform station in stations)
            if (station != null)
                stationNames.Add(station.GetClassName());

        return stationNames;
    }

    public List<WeaponsPlatform> GetArmedStations()
    {
        List<WeaponsPlatform> armedStations = new List<WeaponsPlatform>();
        foreach (var station in stations)
            if (station is WeaponsPlatform weaponsPlatform)
                armedStations.Add(weaponsPlatform);
        return armedStations;
    }

    public void UpdateStationList()
    {
        stationList.Clear();
        foreach (Platform station in stations)
            if (station != null)
                if (station.GetHealth() <= 0)
                    RemoveStation(station);
                else
                    stationList.Add(station);
    }

    public string GetName()
    {
        return name;
    }

    public void SetFaction(Faction faction)
    {
        this.faction = faction;
    }

    public Faction GetFaction()
    {
        return faction;
    }

    public Starbase GetStarbase()
    {
        if (stations[starbaseIndex] is Starbase starbase)
            return starbase;
        else
            return null;
    }

    public int GetStrategicValue()
    {
        return strategicValue;
    }
}