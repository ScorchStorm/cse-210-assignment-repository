using System;
using System.Collections.Generic;
namespace StarWarsConquest;

class Fleet
{
    private List<Ship> ships = new List<Ship>();
    private Admiral admiral;
    private Ship scout;
    private Ship cruiser;
    private Ship dreadnaught;
    private StarSystem position;
    private Faction faction;
    public Fleet(Admiral admiral, Ship scout, Ship cruiser, Ship dreadnaught, Faction faction)
    {
        this.admiral = admiral;
        this.scout = scout;
        this.cruiser = cruiser;
        this.dreadnaught = dreadnaught;
        ships.Add(cruiser);
        position = faction.GetCapital();
        faction.GetCapital().SetFleet(this);
    }

    public void Repair(Starbase starbase)
    {
        foreach (Ship ship in ships)
        {
            starbase.MakeRepair(ship);
        }
    }

    public void Attack(Fleet enemyFleet, float bonus)
    {
        foreach (Ship ship in ships)
        {
            Ship target = enemyFleet.GetShips()[0];
            ship.Attack(target, bonus);
            if (target.GetHealth() <= 0)
            {
                Console.WriteLine($"{target.GetClassName()} has been destroyed!");
                enemyFleet.RemoveShip(target);
            }
        }
    }

    public void Move(StarSystem system)
    {
        position.SetFleet(null); // I don't know if this is the right way to do this...
        position = system;
        if (system.GetFleet() != null)
        {
            system.Battle(this);
        }
        if (system.GetFleet == null) // the fleet won the battle (or there was no battle) and moves to the new system
        {
            system.SetFleet(this);
        }
    }

    public List<Ship> GetShips()
    {
        return ships;
    }

    public void PrintShipStats()
    {
        foreach (Ship ship in ships)
        {
            ship.PrintStats();
        }
    }

    public void CreateNewShip(Ship ship)
    {
        ships.Add(ship);
    }

    public void ReplaceShip(int oldShipIndex, Ship ship)
    {
        ships[oldShipIndex] = ship;
    }

    public void RemoveShip(Ship ship)
    {
        ships.Remove(ship);
    }

    public void UpdateScout(Ship scout)
    {
        this.scout = scout;
    }

    public void UpdateCruisertShip(Ship cruiser)
    {
        this.cruiser = cruiser;
    }

    public void UpdateDreadnaught(Ship dreadnaught)
    {
        this.dreadnaught = dreadnaught;
    }

    public Vector2 GetPosition()
    {
        return position.GetPosition();
    }

    public Admiral GetAdmiral()
    {
        return admiral;
    }

    public Texture2D GetFleetImage()
    {
        List<string> types = new List<string>();
        foreach (Ship ship in ships)
        {
            types.Add(ship.GetClassType());
        }
        if (types.Contains("dreadnaught"))
        {
            return dreadnaught.GetTexture();
        }
        else if (types.Contains("cruiser"))
        {
            return cruiser.GetTexture();
        }
        else if (types.Contains("scout"))
        {
            return scout.GetTexture();
        }
        else
        {
            return dreadnaught.GetTexture();
        }
    }
}