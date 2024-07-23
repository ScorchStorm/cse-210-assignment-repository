// using System.Collections.Generic;
// using Microsoft.Xna.Framework;
// using Microsoft.Xna.Framework.Graphics;
// using Microsoft.Xna.Framework.Input;

// namespace StarWarsConquest;

// class Game1Old : Game
// {
//     private GraphicsDeviceManager _graphics;
//     private SpriteBatch _spriteBatch;
//     private Texture2D ship;
//     private Vector2 position;
//     string pictureName;

//     public Game1Old(int positionX, int positionY, string pictureName)
//     {
//         position = new Vector2(positionX, positionY); // Example
//         this.pictureName = pictureName;
//         _graphics = new GraphicsDeviceManager(this);
//         Content.RootDirectory = "Content";
//         IsMouseVisible = true;
//     }

//     protected override void Initialize()
//     {
//         // TODO: Add your initialization logic here

//         base.Initialize();
//     }

//     protected override void LoadContent()
//     {
//         _spriteBatch = new SpriteBatch(GraphicsDevice);
//         ship = Content.Load<Texture2D>(pictureName);
//         // TODO: use this.Content to load your game content here
//     }

//     protected override void Update(GameTime gameTime)
//     {
//         if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
//             Exit();

//         // TODO: Add your update logic here

//         base.Update(gameTime);
//     }

//     protected override void Draw(GameTime gameTime)
//     {
//         GraphicsDevice.Clear(Color.CornflowerBlue); // Background color can be changed here

//         // TODO: Add your drawing code here
//         _spriteBatch.Begin(samplerState:SamplerState.PointClamp);
//         // _spriteBatch.Draw(ship,position,Color.White);
//         ship.Draw(_spriteBatch);
//         _spriteBatch.End();

//         base.Draw(gameTime);
//     }

//     // protected void DrawGalaxyMap()
//     // {
//     //     GalacticMap galaxyMap = new StarWarsConquest.GalacticMap();
//     //     // List<List<StarSystem>> hyperlanes = galaxyMap.GetHyperLanes();
//     //     List<StarSystem> starSystems = galaxyMap.GetStarSystems();
//     //     foreach (StarSystem system in starSystems)
//     //     {
            
//     //     }

//     // }
// }
