using System;
using System.Collections.Generic;
using System.Threading;

namespace StarWarsConquest;

// class StarSystem: Sprite
class StarSystem: Sprite
{
    private string name;
    private List<Platform> stations = new List<Platform>();
    private List<WeaponsPlatform> armedStations = new List<WeaponsPlatform>();

    private Fleet fleet;
    private int strategicValue;
    private List<StarSystem> hyperlanes = new List<StarSystem>();
    private string description;
    // private float scale = 1f;
    // // private string textureName = "C:\\Users\\Matthew\\OneDrive\\Documents\\BYU-I Spring Semester 2024 Files\\Programming with Classes (CSE 210)\\cse-210-assignment-repository\\final\\FinalProject\\images\\Sphere-with-blender.png";
    // // private Vector2 position;
    // // private int scale = 40;
    
    // public StarSystem(string name, int strategicValue, int positionX, int positionY, string textureName, string description): base(textureName, positionX, positionY, 40)
    // public StarSystem(string name, int strategicValue, int xPosition, int yPosition, string textureName, string description)
    public StarSystem(Texture2D texture, Vector2 position, string name, int strategicValue, string description): base(texture, position, 1f)
    {
        this.name = name;
        this.strategicValue = strategicValue;
        // this.xPosition = xPosition;
        // this.yPosition = yPosition;
        this.description = description;
        // this.textureName = textureName;
    }

    public void RemoveStation(Platform station)
    {
        stations.Remove(station);
        if  (station is WeaponsPlatform weaponsPlatform)
        {
            armedStations.Remove(weaponsPlatform);
        }
    }

    public void AddStation(Platform station)
    {
        stations.Add(station);
        if  (station is WeaponsPlatform weaponsPlatform)
        {
            armedStations.Add(weaponsPlatform);
        }

    }

    public void AddHyperLane(StarSystem starSystem)
    {
        hyperlanes.Add(starSystem);
    }

    public float GetIncome(float industry, float miningEfficiency)
    {
        float income = 100*strategicValue*industry;
        foreach (Platform station in stations)
        {
            // Type type = station.GetType();
            // if (type == typeof(MiningStation))
            if (station is MiningStation miningStation)
            {
                income += 100*strategicValue*miningEfficiency;
            }
        }
        return income;
    }

    public float GetResearch(float researchEfficiency)
    {
        float research = 0;
        foreach (Platform station in stations)
        {
            // Type type = station.GetType();
            // if (type == typeof(ResearchStation))
            if (station is ResearchStation researchStation)
            {
                research = researchEfficiency;
            }
        }
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

    public void Battle(Fleet invadingFleet)
    {
        float attackBonus = invadingFleet.GetAdmiral().GetAttackStrength();
        float defendBonus = fleet.GetAdmiral().GetDefenseStrength();
        while (invadingFleet.GetShips().Count != 0 && fleet.GetShips().Count != 0)
        {
            invadingFleet.Attack(fleet, attackBonus);
            fleet.Attack(invadingFleet, defendBonus);
            armedStations = GetArmedStations();
            foreach (WeaponsPlatform station in armedStations)
            {
                Ship target = invadingFleet.GetShips()[0];
                station.Attack(target, 1);
            }
            PrintBattleInfo(invadingFleet);
            Thread.Sleep(1000);
        }
    }

    public void PrintBattleInfo(Fleet invadingFleet)
    {
        Console.WriteLine("");
        Console.WriteLine("Invading Fleet");
        invadingFleet.PrintShipStats();
        Console.WriteLine("");
        Console.WriteLine("Defending Fleet");
        fleet.PrintShipStats();
        Console.WriteLine("");
    }

    public float GetStrength()
    {
        float strength = 0;
        foreach (var station in stations)
        {
            if (station is WeaponsPlatform weaponsPlatform)
            {
                strength += weaponsPlatform.GetStrength();
            }
        }
        return strength;
    }

    public List<Platform> GetStations()
    {
        return stations;
    }

    public List<WeaponsPlatform> GetArmedStations()
    {
        List<WeaponsPlatform> armedStations = new List<WeaponsPlatform>();
        foreach (var station in stations)
        {
            if (station is WeaponsPlatform weaponsPlatform)
            {
                armedStations.Add(weaponsPlatform);
            }
        }
        return armedStations;
    }

    // public int GetXPosition()
    // {
    //     return xPosition;
    // }
    
    // public int GetYPosition()
    // {
    //     return yPosition;
    // }
    
    // public string GetTextureName()
    // {
    //     return textureName;
    // }

    public string GetName()
    {
        return name;
    }
}