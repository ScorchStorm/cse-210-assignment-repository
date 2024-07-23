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
    private ContentManager contentManager;
    private GalacticMapScene galacticMapScene;
    private Dictionary<string,Texture2D> textureDict;
    
    public GameManager(GraphicsDeviceManager graphics)
    {
        this.graphics = graphics;
        sceneManager = new();
        TextureManager textureManager = new TextureManager(contentManager);
        textureDict = textureManager.GetTextureDict();
        GalacticMapScene galacticMapScene = new GalacticMapScene(contentManager, graphics, sceneManager, textureDict);
        FactionManager factionManager = new FactionManager(systemDictionary, textureDict);
        factions = factionManager.GetFactions();
        factionManager.BuildTestFleets();
        galacticMapScene.SetFactions(factions);
    }
    public void Initialize()
    {

    }

    public void Load(ContentManager contentManager)
    {
        // //for the moment, we load an initial list of opposing ships
        // List<Ship> playerFleet = new();
        // List<Ship> enemyFleet = new();
        // List<Platform> stations = new();

        // //For now we load a battlescene to just test out if it works
        // sceneManager.AddScene(new BattleScene(playerFleet, enemyFleet, stations, contentManager, graphics, sceneManager)); //not sure if we need this since everything is global
        sceneManager.AddScene(new GalacticMapScene(contentManager, graphics, sceneManager, textureDict));
        sceneManager.GetCurrentScene().Load();
    }

    public void Update(GameTime gameTime)
    {
        sceneManager.GetCurrentScene().Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        sceneManager.GetCurrentScene().Draw(spriteBatch);
    }
}