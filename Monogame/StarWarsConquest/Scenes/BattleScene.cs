using System;
using System.Collections.Generic;

namespace StarWarsConquest;

public class BattleScene : IScene
{
    ContentManager contentManager;
    GraphicsDeviceManager graphicsDeviceManager;
    SceneManager sceneManager;
    private readonly List<Vector2> enemyFleetPositions = new()
    {
        new Vector2(710,274),
        new Vector2(896,211),
        new Vector2(837,310),
        new Vector2(996,275),
        new Vector2(967,364),
        new Vector2(1125,303),
        new Vector2(1043,441)
    };
    private readonly List<Vector2> playerFleetPositions = new()
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
    private readonly List<Vector2> turretPositions = new();
    public List<Ship> playerFleet;
    public List<Ship> enemyFleet;
    public List<Station> stations;


    public BattleScene(List<Ship> friendlyShips, List<Ship> enemyShips,List<Station> stations, ContentManager contentManager, GraphicsDeviceManager graphicsDeviceManager, SceneManager sceneManager)
    {
        //This sets up our scene to use the information from the base game
        this.playerFleet = friendlyShips;
        this.enemyFleet = enemyShips;
        this.stations = stations;
        this.contentManager = contentManager;
        this.graphicsDeviceManager = graphicsDeviceManager;
        this.sceneManager = sceneManager;
    }
    public void Load()
    {
        int idx = 0;
        //This might not be needed if the texture is already assigned elsewhere, but position will stay
        foreach (Ship ship in playerFleet)
        {
            ship.texture = TextureManager.GetTexture(ship.GetShipName(),contentManager);
            ship.position = playerFleetPositions[idx];
            idx++;
        }
        idx = 0;

        foreach (Ship ship in enemyFleet)
        {
            ship.texture = TextureManager.GetTexture(ship.GetShipName(),contentManager);
            ship.position = enemyFleetPositions[idx];
            idx++;
        }
        idx = 0;

        foreach (Station station in stations)
        {
            station.texture = TextureManager.GetTexture(station.GetName(),contentManager);
            station.position = stationPositions[idx];
            idx++;
        }
    }

    public void Update(GameTime gameTime)
    {
        //Maybe remove ship in here?
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Ship ship in playerFleet)
        {
            ship.Draw(spriteBatch);
        }
        foreach (Ship ship in enemyFleet)
        {
            ship.Draw(spriteBatch);
        }
        foreach (Station station in stations)
        {
            station.Draw(spriteBatch);
        }
    }
}