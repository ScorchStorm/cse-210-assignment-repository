using System.Collections.Generic;
using System.Data;

//May want to only load needed ships from library?

namespace StarWarsConquest;

public class GameManager
{
    private SceneManager sceneManager;
    private GraphicsDeviceManager graphics;
    
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
        //for the moment, we load an initial list of opposing ships
        List<Ship> playerFleet = new();
        List<Ship> enemyFleet = new();
        List<Station> stations = new();

        //For now we load a battlescene to just test out if it works
        sceneManager.AddScene(new BattleScene(playerFleet,enemyFleet,stations,contentManager,graphics,sceneManager)); //not sure if we need this since everything is global
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