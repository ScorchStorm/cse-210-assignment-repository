using System;
using System.Collections.Generic;
using System.Data;

//May want to only load needed ships from library?

namespace StarWarsConquest;

public class GameManager
{
    private SceneManager sceneManager;
    private GraphicsDeviceManager graphics;
    private FactionManager factionManager;
    private List<Faction> factions;
    private List<StarSystem> systems;
    private Dictionary<string, StarSystem> systemDictionary;
    // private ContentManager contentManager = new ContentManager(Game1.Services);
    private ContentManager contentManager;
    private GalacticMapScene galacticMapScene;
    private Dictionary<string,Texture2D> textureDict;
    private Faction playerFaction;
    
    // public GameManager(GraphicsDeviceManager graphics)
    // {
    //     this.graphics = graphics;
    //     sceneManager = new();
    //     TextureManager textureManager = new TextureManager(contentManager, graphics);
    //     textureDict = textureManager.GetTextureDict();
    //     GalacticMapScene galacticMapScene = new GalacticMapScene(contentManager, graphics, sceneManager, textureDict);
    //     FactionManager factionManager = new FactionManager(systemDictionary, textureDict);
    //     factions = factionManager.GetFactions();
    //     factionManager.BuildTestFleets();
    //     galacticMapScene.SetFactions(factions);
    //     Initialize();
    // }
    // public void Initialize()
    // {
    //     Console.WriteLine("Welcome to Star Wars Conquest!");
    //     Console.WriteLine("Please select the faction you would like to play as");
    //     List<string> factionNames = new List<string>();
    //     foreach(Faction faction in factions)
    //     {
    //         factionNames.Add(faction.GetFactionName());
    //     }
    //     choice

    // }

    public GameManager(GraphicsDeviceManager graphics)
    {
        this.graphics = graphics;
        sceneManager = new();
    }

    public void Initialize()
    {

    }

    public void Load(ContentManager contentManager)
    {
        TextureManager textureManager = new TextureManager(contentManager, graphics);
        textureDict = textureManager.GetTextureDict();
        GalacticMapScene galacticMapScene = new GalacticMapScene(contentManager, graphics, sceneManager, textureDict);
        systemDictionary = galacticMapScene.GetSystemDictionary();
        systems = galacticMapScene.GetStarSystems();
        FactionManager factionManager = new FactionManager(systemDictionary, textureDict);
        factions = factionManager.GetFactions();
        galacticMapScene.SetFactions(factions);
        sceneManager.AddScene(galacticMapScene);
        sceneManager.GetCurrentScene().Load();
        ChooseFaction();
    }

    public void ChooseFaction()
    {
        Console.WriteLine("Welcome to Star Wars Conquest!");
        Console.WriteLine();
        List<string> factionNames = new List<string>();
        foreach(Faction faction in factions)
            if (faction.GetName() != "Neutral")
                factionNames.Add(faction.GetName());
        Choice choice = new Choice("Please select the faction you would like to play as", factionNames);
        int index = choice.MakeChoice();
        playerFaction = factions[index];
        Admiral admiral = playerFaction.ChooseAdmiral();
        playerFaction.CreateNewFleet(admiral, playerFaction.GetCapital());
        foreach (Faction faction in factions)
            if (faction != playerFaction && faction.GetName() != "Neutral")
            {
                faction.CreateInitialFleet(null, faction.GetCapital());
                faction.GetCapital().SetFaction(faction);
            }
        
        Faction neutral = factions[factions.Count-1];
        foreach (StarSystem system in systems)
            if (!system.GetIsCapital())
            {
                // Console.WriteLine($"Fleets are supposedly about to be created in {system.GetName()}");
                neutral.CreateInitialFleet(null, system);
                system.SetFaction(neutral);
            }
        // Choice choice2 = new Choice("Choose your first admiral", playerFaction.GetAvailableAdmirals());
        TakeTurn();
    }

    public void PrintFleets()
    {
        foreach (Faction faction in factions)
        {
            foreach (Fleet fleet in faction.GetFleets())
            {
                Console.WriteLine($"Fleet = {fleet}, admiral = {fleet.GetAdmiral().GetName()}");
            }
        }
    }

    public void TakeTurn() // This is made for the text-based version of the game
    {
        Console.WriteLine("You turn has has just started. It is now your turn");
        playerFaction.NewTurn();
        while (true)
        {
            int credits = playerFaction.GetCredits();
            List<string> choices = new List<string>{"Check number of Credits", "Build a New Fleet", "Move a Fleet", "View a System", "End Turn"};
            Choice choice = new Choice("What would you like to do next?", choices);
            int index = choice.MakeChoice();
            Console.WriteLine($"index = {index}");
            if (index == 0)
                Console.WriteLine($"You have {credits} credits");
            
            else if (index == 1)
                if (playerFaction.GetCapital().GetFleet() == null)
                    playerFaction.CreateNewFleet();
                else
                    Console.WriteLine($"Sorry, you cannot build a new fleet while a fleet is in your capital. You must move your fleet in the {playerFaction.GetCapital()} system before you can create a new fleet");
            
            else if (index == 2)
            {
                List<string> fleetPositions = new List<string>();
                List<Fleet> playerFleets = playerFaction.GetFleets();
                foreach (Fleet fleet in playerFleets)
                {
                    Console.WriteLine($"fleet = {fleet}");
                    Console.WriteLine($"fleet.GetAdmiral().GetName() = {fleet.GetAdmiral().GetName()}");
                    Console.WriteLine($"fleet.GetSystem() = {fleet.GetSystem()}");
                    fleetPositions.Add(fleet.GetSystem().GetName());
                }
                Choice choice2 = new Choice("You have fleets in the following systems. Which would you like to move?", fleetPositions);
                int index2 = choice2.MakeChoice();
                Fleet chosenFleet = playerFleets[index2];
                if (chosenFleet.GetMovementsRemaining() >= 1)
                {
                    List<string> destinations = new List<string>();
                    foreach (StarSystem system in chosenFleet.GetSystem().GetHyperlanes())
                        destinations.Add($"{system.GetName()}: {system.GetStrategicValue()}/5");
                    
                    Choice choice3 = new Choice("Where would you like to move this fleet?", destinations);
                    int index3 = choice3.MakeChoice();
                    StarSystem destination = chosenFleet.GetSystem().GetHyperlanes()[index3];
                    chosenFleet.Move(destination);
                    // Console.WriteLine($"The fleet has been moved to {chosenFleet.GetSystem().GetName()}");
                }
                else
                    Console.WriteLine("Sorry, the fleet has no movement left for this turn");
            }
            
            else if (index == 3)
            {
                List<string> systemNames = new List<string>();
                foreach (StarSystem system in playerFaction.GetSystems())
                    systemNames.Add($"{system.GetName()}: {system.GetStrategicValue()}/5");
                
                Choice choice4 = new Choice("Which system would you like to view?", systemNames);
                int index4 = choice4.MakeChoice();
                StarSystem systemChoice = playerFaction.GetSystems()[index4];
                systemChoice.DisplayDescription();
                if (systemChoice.GetPlatformNames() == null)
                    Console.WriteLine("systemChoice.GetPlatformNames() = null");
                
                Console.WriteLine($"The structures in {systemChoice.GetName()} are:");
                List<string> stationNames = systemChoice.GetStationNames();
                foreach (string name in stationNames)
                    Console.WriteLine(name);

                Console.WriteLine($"The ships in {systemChoice.GetName()} are:");
                // Console.WriteLine($"systemChoice.GetFleet().GetShipCount() = {systemChoice.GetFleet().GetShipCount()}");
                foreach (Ship ship in systemChoice.GetFleet().GetShipList())
                    Console.WriteLine(ship.GetClassName());
                
                List<string> choices5;
                if (systemChoice.GetFleet() != null && systemChoice.GetStarbase() != null)
                    choices5 = new List<string>{"Leave system view", "Create Or Replace Structure", "Create Or Replace Ship"};
                
                else
                    choices5 = new List<string>{"Leave system view", "Create Or Replace Structure"};
                
                Choice choice5 = new Choice("What would you like to do?", choices5);
                int index5 = choice5.MakeChoice();
                if (index5 == 1)
                {
                    Choice choice6 = new Choice("What would you like to build or replace?", new List<string>{"Advanced Starbase", "Starbase", "Turret", "Mining Station", "Research Station"});
                    int index6 = choice6.MakeChoice();
                    if (index6 == 0)
                        if (EnoughCredits(playerFaction.GetAdvancedStarbase()))
                            playerFaction.AddNewStarbase(systemChoice, playerFaction.GetAdvancedStarbase());
                    
                    if (index6 == 1)
                        if (EnoughCredits(playerFaction.GetStarbase()))
                            playerFaction.AddNewStarbase(systemChoice, playerFaction.GetStarbase());
                    
                    if (index6 == 2)
                        if (EnoughCredits(playerFaction.GetTurret(), 4))
                            // AddNewTurrets(systemChoice);
                            playerFaction.AddNewTurrets(systemChoice);
                    
                    if (index6 == 3)
                        if (EnoughCredits(playerFaction.GetMiningStation()))
                            playerFaction.AddNewMiningStation(systemChoice);
                    
                    if (index6 == 4)
                        if (EnoughCredits(playerFaction.GetResearchStation()))
                            playerFaction.AddNewResearchStation(systemChoice);
                }
                if (index5 == 2)
                {
                    Ship newShip;
                    Fleet fleet = systemChoice.GetFleet();
                    Choice choice6 = new Choice("Which type of ship would you like to build?", new List<string>{"scout", "cruiser", "dreadnaught"});
                    int index6 = choice6.MakeChoice();
                    if (index6 == 0)
                        newShip = playerFaction.GetScout();
                    
                    if (index6 == 1)
                        newShip = playerFaction.GetCruiser();
                    
                    else
                        newShip = playerFaction.GetDreadnaught();
                    
                    if (EnoughCredits(newShip))
                        playerFaction.AddNewShip(fleet, newShip);
                }
            }
            else if (index == 4)
            {
                Choice choice1 = new Choice("Are you sure you want to end your turn?", new List<string>{"Yes", "No"});
                int index1 = choice1.MakeChoice();
                if (index1 == 0)
                {
                    Console.WriteLine("Breaking from turn loop");
                    break;
                }
            }
        }
    }

    bool EnoughCredits(Platform platform, int platformNumber = 1) // check whether or not the player has enough credits to purchase the thing
    {
        int credits = playerFaction.GetCredits();
        int platformCost = platformNumber*platform.GetCost();
        if (credits < platformCost)
        {
            Console.WriteLine($"You do not have enough credits to purchase a {platform.GetType()}");
            Console.WriteLine($"{platform.GetType()} cost {platformCost}, and you only have {credits} credits");
            return false;
        }
        else
            return true;
    }

    void AddNewTurrets(StarSystem starSystem)
    {
        List<int> turretIndexes = playerFaction.GetTurretIndexes();
        int credits = playerFaction.GetCredits();
        Turret turret = playerFaction.GetTurret();
        Platform [] stations = starSystem.GetStations();
        int turretsCost = 4*turret.GetCost();
        if (turretsCost > credits)
        {
            int nTurrets1 = 0;
            int nTurrets2 = 0;
            int turrets1Health = 0;
            int turrets2Health = 0;
            for (int i = 0; i<3; i++)
                if (stations[turretIndexes[i]] != null)
                {
                    nTurrets1 += 1;
                    turrets1Health += (int)stations[turretIndexes[i]].GetHealth();
                }
            
            for (int i = 4; i<7; i++)
                if (stations[turretIndexes[i]] != null)
                {
                    nTurrets2 += 1;
                    turrets2Health += (int)stations[turretIndexes[i]].GetHealth();
                }
            
            if (nTurrets1 == 0) // if there are no turrets around the starbase, build the turrets there
            {
                starSystem.AddStation(turret, turretIndexes[0]);
                starSystem.AddStation(turret, turretIndexes[1]);
                starSystem.AddStation(turret, turretIndexes[2]);
                starSystem.AddStation(turret, turretIndexes[3]);
            }
            else if (nTurrets2 == 0) // if there are no turrets around the industrialStation, build the turrets there
            {
                starSystem.AddStation(turret, turretIndexes[4]);
                starSystem.AddStation(turret, turretIndexes[5]);
                starSystem.AddStation(turret, turretIndexes[6]);
                starSystem.AddStation(turret, turretIndexes[7]);
            }
            else // if there is at least 1 turret around each structure
            {
                Choice choice1 = new Choice("there are no openings for new sets of turrets. Are you sure you want to replce existing turrets?", new List<string>{"Yes", "No"});
                int index1 = choice1.MakeChoice(); // Ask if they really want to replce turrets
                if (index1 == 0)
                {
                    if (nTurrets1 < nTurrets2) // if there are less turrets around the starbase, replace those turrets
                    {
                        starSystem.AddStation(turret, turretIndexes[0]);
                        starSystem.AddStation(turret, turretIndexes[1]);
                        starSystem.AddStation(turret, turretIndexes[2]);
                        starSystem.AddStation(turret, turretIndexes[3]);
                    }
                    else if (nTurrets1 > nTurrets2) // if there are less turrets around the industrial station, replace those turrets
                    {
                    starSystem.AddStation(turret, turretIndexes[4]);
                    starSystem.AddStation(turret, turretIndexes[5]);
                    starSystem.AddStation(turret, turretIndexes[6]);
                    starSystem.AddStation(turret, turretIndexes[7]);
                    }
                    else // if the same number of turrets are around both stations
                    {
                        if (turrets1Health < turrets2Health) // if the turrets around the starbase have less health than the turrets around the industrial station, replace the turrets around the starbase
                        {
                            starSystem.AddStation(turret, turretIndexes[0]);
                            starSystem.AddStation(turret, turretIndexes[1]);
                            starSystem.AddStation(turret, turretIndexes[2]);
                            starSystem.AddStation(turret, turretIndexes[3]);
                        }
                        else // if not, just replace the turrets around the industrial station
                        {
                            starSystem.AddStation(turret, turretIndexes[4]);
                            starSystem.AddStation(turret, turretIndexes[5]);
                            starSystem.AddStation(turret, turretIndexes[6]);
                            starSystem.AddStation(turret, turretIndexes[7]);
                        }
                    }
                }
            }
        }
    }

    // public void Load(ContentManager contentManager)
    // {
    //     // //for the moment, we load an initial list of opposing ships
    //     // List<Ship> playerFleet = new();
    //     // List<Ship> enemyFleet = new();
    //     // List<Platform> stations = new();

    //     // //For now we load a battlescene to just test out if it works
    //     // sceneManager.AddScene(new BattleScene(playerFleet, enemyFleet, stations, contentManager, graphics, sceneManager)); //not sure if we need this since everything is global
    //     sceneManager.AddScene(new GalacticMapScene(contentManager, graphics, sceneManager, textureDict));
    //     sceneManager.GetCurrentScene().Load();
    // }

    public void Update(GameTime gameTime)
    {
        sceneManager.GetCurrentScene().Update(gameTime);
        TakeTurn();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        sceneManager.GetCurrentScene().Draw(spriteBatch);
    }
}