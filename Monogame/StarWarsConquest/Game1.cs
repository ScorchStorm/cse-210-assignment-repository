global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using Microsoft.Xna.Framework.Input;
global using Microsoft.Xna.Framework.Content;
global using System.Collections.Generic;


namespace StarWarsConquest;

class Game1 : Game
{
    SpriteBatch spriteBatch;
    List<Sprite> sprites = new List<Sprite>();
    private GraphicsDeviceManager graphics;
    // private SceneManager sceneManager;
    GameManager gameManager;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        gameManager = new GameManager(graphics);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
        // LoadContent(); // will this fix the error "The GraphicsDevice must not be null when creating new resources.'"? // No it did not... =(
    }

    // protected void AddContent(int xPosition, int yPosition, string imageName, float scale, Color color)
    // {
    //     // LoadContent();
    //     _spriteBatch = new SpriteBatch(GraphicsDevice);
    //     Texture2D texture = Content.Load<Texture2D>(imageName);
    //     int width = (int)(texture.Width*scale);
    //     int height = (int)(texture.Height*scale);
    //     int x = xPosition - width/2; // the x-position of the left side of the image
    //     int y = yPosition - height/2; // the y-position of the top side of the image
    //     Rectangle rect = new Rectangle(x, y, width, height);
    //     // _spriteBatch.Draw(texture, rect, color);
    //     Sprite sprite = new Sprite(content, imageName, xPosition, yPosition, scale);
    // }

    // protected void AddSprite(string imageName, int xPosition, int yPosition, float scale)
    // {
    //     Sprite sprite = new Sprite(content, imageName, xPosition, yPosition, scale);
    //     sprites.Add(sprite);
    // }

    // protected override void LoadContent(int positionX, int positionY, string pictureName)
    protected override void LoadContent()
    {
        // private SpriteBatch _spriteBatch;
        // private Texture2D ship;
        // private Vector2 position;
        // string pictureName;
        spriteBatch = new SpriteBatch(GraphicsDevice);
        // Texture2D ship = Content.Load<Texture2D>(imageName);
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    // protected override void Draw(GameTime gameTime)
    // {
    //     GraphicsDevice.Clear(Color.CornflowerBlue); // Background color can be changed here

    //     // TODO: Add your drawing code here
    //     _spriteBatch.Begin(samplerState:SamplerState.PointClamp);
    //     _spriteBatch.Draw(ship, position, Color.White);
    //     _spriteBatch.End();

    //     base.Draw(gameTime);
    // }

    protected override void Draw(GameTime gameTime) // from Nick's Code
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        foreach (Sprite sprite in sprites)
        {
            sprite.Draw(spriteBatch);
        }
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
