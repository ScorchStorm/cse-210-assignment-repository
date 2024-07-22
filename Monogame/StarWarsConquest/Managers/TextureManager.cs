using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace StarWarsConquest;
public static class TextureManager
{
    //place all our texture locations here in the dictionary
    // private static Dictionary<string,string> textureDict;

    public static Texture2D GetTexture(string name, ContentManager contentManager)
    {
        var textureLocation = textureDict[name];
        return contentManager.Load<Texture2D>(textureLocation);
    }

    private static Dictionary<string,string> textureDict = new Dictionary<string,string>
    {
        {"Fury-Class Interceptor", "Reconstituted Sith Empire - Fury-Class Interceptor"},
        {"Terminus-Class Destroyer", "Reconstituted Sith Empire - Terminus-Class SD"},
        {"Harrower-Class Dreadnought", "Reconstituted Sith Empire - Harrower-Class SD"},
        {"Sith Space Station", "Reconstituted Sith Empire - Sith Space Station"},
        {"Reconstituted Sith Empire Insignia", "Reconstituted Sith Empire - Insignia"},
        {"MC30C Frigate", "Mon Calamari - MC30C Frigate"},
        {"MC75 Star Cruiser", "Mon Calamari - MC75 Star Cruiser"},
        {"MC80 Star Cruiser", "Mon Calamari - MC80 Star Cruiser"},
        {"Shipyards T-Frame", "Mon Calamari - Shipyards T-Frame"},
        {"Mon Calamari Insignia", "Mon Calamari - Insignia"},
        {"Marauder-Class Corvette", "CIS - Marauder-Class Corvette"},
        {"Munificient-Class Star Frigate", "CIS - Munificient-Class Star Frigate"},
        {"Providence-Class Fleet Carrier", "CIS - Providience-Class Fleet Carrier"},
        {"Lucrehulk-Class Battleship", "CIS - Lucrehulk-Class Battleship"},
        {"Separatist Insigna", "Confederacy of Independant Systems - Insignia"},
        {"Raider-Class Corvette", "Galactic Empire - Raider-Class Corvette"},
        {"Vindicator-Class Heavy Cruiser", "Galactic Empire - Vindicator-Class Heavy Cruiser"},
        {"Imperial Star Destroyer", "Galactic Empire - Imperial Star Destroyer"},
        {"Empress-Class Space Station", "Galactic Empire - Empress-Class Space Station"},
        {"Galactic Empire Insignia", "Galactic Empire - Insignia"},
        {"Arquitens-Class Light Cruiser", "Galactic Republic - Arquitens-Class Light Cruiser"},
        {"Acclamator-Class Assault Ship", "Galactic Republic - Acclamator-Class Assault Ship"},
        {"Venator-Class Star Destroyer", "Galactic Republic - Venator-Class Star Destroyer"},
        {"Haven-Class Medical Station", "Galactic Republic - Haven-Class Medical Station"},
        {"Galactic Republic Insignia", "Galactic Republic - Insignia"},
        {"Advance Scout Ship", "Yuuzhan Vong - Advance Scout Ship"},
        {"Matalok", "Yuuzhan Vong - Matalok"},
        {"Miid Ro'ik", "Yuuzhan Vong - Miid Roik"},
        {"Kor Chokk", "Yuuzhan Vong - Kor Chokk"},
        {"Yuuzhan Vong Insignia", "Yuuzhan Vong - Insignia"},
        {"Yuuzhan Vong Worldship", "Yuuzhan Vong - Worldship"},
        {"Golan III Defense Platform", "Star Wars - Golan III Defense Platform"},
        {"XQ1 Platform", "Star Wars - XQ1 Platform"},
        {"Mining Station", "Mining Station"},
        {"Research Station", "Research Station"},
        {"Cargo Freighter", "Hylo Visz's Smuggling Contingent - Cargo Freighter.png"},
        {"Mandalorian Cruiser", "Mandalorian empire - Mandalorian Cruiser - Landed"},
        {"Interdictor-Class Cruiser", "Darth Reven's Sith Empire - Interdictor"},
        {"Darth Reven's Insigina", "Darth Reven's Sith Empire - Insignia"}
    };
}