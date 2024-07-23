global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using Microsoft.Xna.Framework.Input;
global using Microsoft.Xna.Framework.Content;
global using System.Collections.Generic;


namespace StarWarsConquest;

class Game1 : Game
{
    private SpriteBatch spriteBatch;
    private List<Sprite> sprites = new List<Sprite>();
    private GraphicsDeviceManager graphics;
    private GameManager gameManager;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        gameManager = new GameManager(graphics);
    }

    // protected override void Initialize()
    // {
    //     base.Initialize();
    // }
    
    protected override void Initialize()
    {
        //Here we can load our initial scene
        // Point WindowSize = new Point(1366,768);
        Point WindowSize = new Point(1250,700);
        graphics.PreferredBackBufferWidth = WindowSize.X;
        graphics.PreferredBackBufferHeight = WindowSize.Y;
        graphics.ApplyChanges();
        gameManager.Initialize();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        gameManager.Load(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        gameManager.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) // from Nick's Code
    {
        GraphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        gameManager.Draw(spriteBatch);
        spriteBatch.End();
        base.Draw(gameTime);
    }

    // public void DrawGalaxyMap()
    // {
    //     GalacticMapScene galaxyMap = new GalacticMapScene();
    //     // List<List<StarSystem>> hyperlanes = galaxyMap.GetHyperLanes();
    //     List<StarSystem> starSystems = galaxyMap.GetStarSystems();
    //     foreach (StarSystem system in starSystems)
    //     {
    //         int xPosition = system.GetXPosition();
    //         int yPosition = system.GetYPosition();
    //         string textureName = system.GetTextureName();
    //         float scale = 1;
    //         AddContent(xPosition, yPosition, textureName, scale, Color.White);
    //         // AddSprite(textureName, xPosition, yPosition, scale);
    //     }
    // }
}
