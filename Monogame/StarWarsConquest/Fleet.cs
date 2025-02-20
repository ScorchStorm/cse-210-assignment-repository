using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarsConquest;

class Fleet
{
    private Ship[] ships;
    private List<Ship> shipList;
    private int shipCount;
    private Admiral admiral;
    private Ship scout;
    private Ship cruiser;
    private Ship dreadnaught;
    private StarSystem starSystem;
    private Vector2 position;
    private Faction faction;
    private int movementsRemaining;
    public Fleet(Admiral admiral, Faction faction, StarSystem starSystem)
    {
        shipList = new List<Ship>();
        // Console.WriteLine($"Just passed in starSystem.GetName() = {starSystem.GetName()}");
        ships = new Ship [] {null, null, null, null, null, null, null};
        // UpdateShipList();
        // Console.WriteLine("Printing ships information");
        // PrintShipStats();
        this.admiral = admiral;
        this.faction = faction;
        this.starSystem = starSystem;
        scout = faction.GetScout();
        cruiser = faction.GetCruiser();
        dreadnaught = faction.GetDreadnaught();
        // Console.WriteLine($"After ReplaceShip() command: ships[0].GetClassName() = {ships[0].GetClassName()}");
        // Console.WriteLine($"GetShipCount() = {GetShipCount()}");
        if (faction.GetName() != "Neutral")
        {
            // Console.WriteLine($"Creating fleet -> faction.GetName() = {faction.GetName()} != Neutral, ");
            // starSystem = faction.GetCapital();
            ReplaceShip(cruiser, 0);
        }
        position = starSystem.GetPosition();
        movementsRemaining = admiral.GetMovementSpeed();
        shipCount = 0;
        UpdateShipList();
        starSystem.SetFleet(this);
        // Console.WriteLine("Printing Ship info again at the end of the constructor");
        // PrintShipStats();
        // Console.WriteLine("The constructor is now finished");
    }

    public void Repair(Starbase starbase)
    {
        foreach (Ship ship in shipList)
            starbase.MakeRepair(ship);
    }

    public void Attack(WeaponsPlatform target, float bonus)
    {
        foreach (Ship ship in shipList)
            ship.Attack(target, bonus);
    }

    public void ResetMovementCounter()
    {
        movementsRemaining = admiral.GetMovementSpeed();
    }

    public int GetMovementsRemaining()
    {
        return movementsRemaining;
    }

    public int GetShipCount()
    {
        return shipList.Count;
    }

    public void Move(StarSystem system)
    {
        movementsRemaining -= 1;
        // string oldSystemName = system.GetName();
        if (system.GetFleet() != null && system.GetFaction() != faction)
        {
            system.GetFleet().PrintShipStats();
            Choice choice = new Choice("An enemy fleet is in this system! Would you like to battle them for control of the system or retreat?", new List<string>{"Initiate Battle", "Retreat"});
            int index = choice.MakeChoice();
            if (index == 0)
                system.Battle(this);
                if (system.GetFleet().GetShipCount() == 0) // the fleet won the battle (or there was no battle) and moves to the new system
                {
                    system.SetFleet(this);
                    position = system.GetPosition();
                    faction.AddNewSystem(system);
                    starSystem = system;
                    Console.WriteLine($"The fleet has been moved to {system.GetName()}");
                }
                else // the fleet lost the battle and has been destroyed
                {
                    // Console.WriteLine($"system.GetFleet().GetShipCount() != 0, printing all its stats now");
                    Console.WriteLine("It looks like the invading fleet has been destroyed. Setting it's system to null");
                    starSystem = null;
                    // oldSystem.SetFleet(null);
                    // system.GetFleet().PrintAllShipStats();
                }
        }
        else
        {
            faction.AddNewSystem(system);
            system.SetFleet(this);
            position = system.GetPosition();
            starSystem = system;
            Console.WriteLine($"The fleet has been moved to {system.GetName()}");
        }
    }

    public Ship[] GetShips()
    {
        return ships;
    }

    public List<Ship> GetShipList()
    {
        return shipList;
    }

    public List<string> GetShipTypes()
    {
        List<string> shipTypes = new List<string>();
        foreach (Ship ship in shipList)
        {
            shipTypes.Add(ship.GetClassType());
        }
        return shipTypes;
    }

    public void UpdateShipList()
    {
        shipList.Clear();
        foreach (Ship ship in ships)
            if (ship != null)
                if (ship.GetHealth() <= 0)
                    RemoveShip(ship);
                else
                    shipList.Add(ship);
        GetShipCount();
    }

    public bool BuildShipInEmptySlot(Ship ship) // attempt to build a ship in a slot that used to be null
    {
        for (int i = 0; i<7; i++)
            if (ships[i] == null)
            {
                ReplaceShip(ship, i);
                UpdateShipList();
                return true;
            }
        return false; // return false if there are no empty slots
    }

    public bool ReplaceShipMenu(Ship ship)
    {
        List<string> choices = new List<string>();
        foreach (Ship ship1 in ships)
            choices.Add(ship1.GetStats());
        
        choices.Add("None of them.");
        Choice choice = new Choice($"Which ship would you like to replace with a new {ship.GetType()}?", choices);
        int index = choice.MakeChoice();
        if (index == 7)
            return false;
        
        ReplaceShip(ship, index);
        UpdateShipList();
        return true;
    }

    public Ship GetTargetPriority()
    {
        int targetIndex = 0;
        float maxPriority = 0;
        for (int i = 0; i<7; i++)
            if (ships[i] != null)
            {
                float shipPriority = ships[i].GetTargetPriority();
                if (shipPriority > maxPriority)
                {
                    maxPriority = shipPriority;
                    targetIndex = i;
                }
            }
        return ships[targetIndex];
    }

    public void PrintShipStats()
    {
        foreach (Ship ship in shipList)
            Console.WriteLine(ship.GetStats());
    }

    public void PrintAllShipStats() // this is temporary. please delete this
    {
        Console.WriteLine($"\n Priting All Ship Stats");
        foreach (Ship ship in ships)
        {
            if (ship == null)
                Console.WriteLine("ship == null");
            else
                Console.WriteLine($"ship != null. Ship Stats: {ship.GetStats()}");
        }
        Console.WriteLine($"GetShipCount() = {GetShipCount()}");
    }

    public Ship ReturnNewShip(Ship ship)
    {
        return ship;
    }

    public void ReplaceShip(Ship ship, int oldShipIndex)
    {
        ships[oldShipIndex] = faction.CreateNewShip(ship);
        UpdateShipList();
    }

    public void RemoveShip(Ship ship)
    {
        Console.WriteLine($"{ship.GetClassName()} has been destroyed!");
        int index = Array.IndexOf(ships, ship);
        ships[index] = null;
        UpdateShipList();
    }

    public void UpdateScout(Ship scout)
    {
        this.scout = scout;
        UpdateShipList();
    }

    public void UpdateCruisertShip(Ship cruiser)
    {
        this.cruiser = cruiser;
        UpdateShipList();
    }

    public void UpdateDreadnaught(Ship dreadnaught)
    {
        this.dreadnaught = dreadnaught;
        UpdateShipList();
    }

    public Vector2 GetPosition()
    {
        return position;
    }

    public StarSystem GetSystem()
    {
        return starSystem;
    }

    public Admiral GetAdmiral()
    {
        return admiral;
    }

    public Faction GetFaction()
    {
        return faction;
    }

    public Texture2D GetFleetImage()
    {
        List<string> types = new List<string>();
        foreach (Ship ship in ships)
            types.Add(ship.GetClassType());
        
        if (types.Contains("dreadnaught"))
            return dreadnaught.GetTexture();
        
        else if (types.Contains("cruiser"))
            return cruiser.GetTexture();
        
        else if (types.Contains("scout"))
            return scout.GetTexture();
        
        else
            return dreadnaught.GetTexture();
    }
}