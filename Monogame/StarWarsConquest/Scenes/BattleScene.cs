using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace StarWarsConquest;

class BattleScene : IScene
{
    ContentManager contentManager;
    GraphicsDeviceManager graphicsDeviceManager;
    SceneManager sceneManager;
    private readonly List<Vector2> attackingFleetPositions = new()
    {
        new Vector2(710,274),
        new Vector2(896,211),
        new Vector2(837,310),
        new Vector2(996,275),
        new Vector2(967,364),
        new Vector2(1125,303),
        new Vector2(1043,441)
    };
    private readonly List<Vector2> defendingFleetPositions = new()
    {
        new Vector2(530,300),
        new Vector2(505,421),
        new Vector2(657,353),
        new Vector2(631,476),
        new Vector2(785,408),
        new Vector2(760,531),
        new Vector2(911,465)
    };
    private readonly List<Vector2> stationPositions = new();
    private List<Ship> defendingShips;
    private List<Ship> attackingShips;
    private List<Platform> stations;


    public BattleScene(Fleet defendingFleet, Fleet attackingFleet, List<Platform> stations, ContentManager contentManager, GraphicsDeviceManager graphicsDeviceManager, SceneManager sceneManager)
    {
        //This sets up our scene to use the information from the base game
        defendingShips = defendingFleet.GetShips();
        attackingShips = attackingFleet.GetShips();
        this.stations = stations;
        this.contentManager = contentManager;
        this.graphicsDeviceManager = graphicsDeviceManager;
        this.sceneManager = sceneManager;
    }
    public void Load()
    {
        int idx = 0;
        //This might not be needed if the texture is already assigned elsewhere, but position will stay
        foreach (Ship ship in defendingShips)
        {
            // ship.texture = TextureManager.GetTexture(ship.GetClassName(),contentManager);
            ship.SetPosition(defendingFleetPositions[idx]);
            idx++;
        }
        idx = 0;

        foreach (Ship ship in attackingShips)
        {
            // ship.texture = TextureManager.GetTexture(ship.GetClassName(),contentManager);
            ship.SetPosition(attackingFleetPositions[idx]);
            idx++;
        }
        idx = 0;

        foreach (Platform station in stations)
        {
            // station.texture = TextureManager.GetTexture(station.GetClassName(),contentManager);
            station.SetPosition(stationPositions[idx]);
            idx++;
        }
    }

    public void Update(GameTime gameTime)
    {
        //Maybe remove ship in here?
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Ship ship in defendingShips)
        {
            ship.Draw(spriteBatch);
        }
        foreach (Ship ship in attackingShips)
        {
            ship.Draw(spriteBatch);
        }
        foreach (Platform station in stations)
        {
            station.Draw(spriteBatch);
        }
    }
}