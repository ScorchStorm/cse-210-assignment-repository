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
        FactionManager factionManager = new FactionManager(systemDictionary, textureDict);
        factions = factionManager.GetFactions();
        galacticMapScene.SetFactions(factions);
        factionManager.BuildTestFleets();
        PrintFleets();
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
        {
            factionNames.Add(faction.GetFactionName());
        }
        Choice choice = new Choice("Please select the faction you would like to play as", factionNames);
        int index = choice.MakeChoice();
        playerFaction = factions[index];
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
    public void TakeTurn()
    {
        List<string> choices = new List<string>{"Check number of Credits", "Build a New Fleet", "Move a Fleet", "View a System"};
        Choice choice = new Choice("It is your turn. What would you like to do?", choices);
        int index = choice.MakeChoice();
        if (index == 0)
        {
            Console.WriteLine($"You have {playerFaction.GetCredits()} credits");
        }
        else if (index == 1)
        {
            playerFaction.CreateNewFleet();
        }
        else if (index == 2)
        {
            List<string> fleetPositions = new List<string>();
            List<Fleet> playerFleets = playerFaction.GetFleets();
            foreach (Fleet fleet in playerFleets)
            {
                fleetPositions.Add(fleet.GetSystem().GetName());
            }
            Choice choice2 = new Choice("You have fleets in the following systems. Which would you like to move?", fleetPositions);
            int index2 = choice2.MakeChoice();
            Fleet chosenFleet = playerFleets[index2];
            List<string> destinations = new List<string>();
            foreach (StarSystem system in chosenFleet.GetSystem().GetHyperlanes())
            {
                destinations.Add(system.GetName());
            }
            Choice choice3 = new Choice("Where would you like to move this fleet?", destinations);
            int index3 = choice3.MakeChoice();
            StarSystem destination = chosenFleet.GetSystem().GetHyperlanes()[index3];
            chosenFleet.Move(destination);
            Console.WriteLine($"The fleet has been moved to {chosenFleet.GetSystem().GetName()}");
        }
        else if (index == 3)
        {
            List<string> systemNames = new List<string>();
            foreach (StarSystem system in playerFaction.GetSystems())
            {
                systemNames.Add(system.GetName());
            }
            Choice choice4 = new Choice("Which system would you like to view?", systemNames);
            int index4 = choice4.MakeChoice();
            StarSystem systemChoice = playerFaction.GetSystems()[index4];
            systemChoice.DisplayDescription();
            Console.WriteLine($"The structures in {systemChoice.GetName()} are:");
            List<string> platformNames = systemChoice.GetPlatformNames();
            foreach (string name in platformNames)
            {
                Console.WriteLine(name);
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