using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace StarWarsConquest;
class TextureManager
{
    private Dictionary<string,Texture2D> textureDict;
    //place all our texture locations here in the dictionary
    // private static Dictionary<string,string> textureDict;
    public TextureManager(ContentManager contentManager)
    {
        textureDict = new Dictionary<string, Texture2D>
        {
            {"Fury-Class Interceptor", contentManager.Load<Texture2D>("Reconstituted Sith Empire - Fury-Class Interceptor")},
            {"Terminus-Class Destroyer", contentManager.Load<Texture2D>("Reconstituted Sith Empire - Terminus-Class SD")},
            {"Harrower-Class Dreadnought", contentManager.Load<Texture2D>("Reconstituted Sith Empire - Harrower-Class SD")},
            {"Sith Space Station", contentManager.Load<Texture2D>("Reconstituted Sith Empire - Sith Space Station")},
            {"Reconstituted Sith Empire Insignia", contentManager.Load<Texture2D>("Reconstituted Sith Empire - Insignia")},
            {"MC30C Frigate", contentManager.Load<Texture2D>("Mon Calamari - MC30C Frigate")},
            {"MC75 Star Cruiser", contentManager.Load<Texture2D>("Mon Calamari - MC75 Star Cruiser")},
            {"MC80 Star Cruiser", contentManager.Load<Texture2D>("Mon Calamari - MC80 Star Cruiser")},
            {"Shipyards T-Frame", contentManager.Load<Texture2D>("Mon Calamari - Shipyards T-Frame")},
            {"Mon Calamari Insignia", contentManager.Load<Texture2D>("Mon Calamari - Insignia")},
            {"Marauder-Class Corvette", contentManager.Load<Texture2D>("CIS - Marauder-Class Corvette")},
            {"Munificient-Class Star Frigate", contentManager.Load<Texture2D>("CIS - Munificient-Class Star Frigate")},
            {"Providence-Class Fleet Carrier", contentManager.Load<Texture2D>("CIS - Providience-Class Fleet Carrier")},
            {"Lucrehulk-Class Battleship", contentManager.Load<Texture2D>("CIS - Lucrehulk-Class Battleship")},
            {"Separatist Insigna", contentManager.Load<Texture2D>("Confederacy of Independant Systems - Insignia")},
            {"Raider-Class Corvette", contentManager.Load<Texture2D>("Galactic Empire - Raider-Class Corvette")},
            {"Vindicator-Class Heavy Cruiser", contentManager.Load<Texture2D>("Galactic Empire - Vindicator-Class Heavy Cruiser")},
            {"Imperial Star Destroyer", contentManager.Load<Texture2D>("Galactic Empire - Imperial Star Destroyer")},
            {"Empress-Class Space Station", contentManager.Load<Texture2D>("Galactic Empire - Empress-Class Space Station")},
            {"Galactic Empire Insignia", contentManager.Load<Texture2D>("Galactic Empire - Insignia")},
            {"Arquitens-Class Light Cruiser", contentManager.Load<Texture2D>("Galactic Republic - Arquitens-Class Light Cruiser")},
            {"Acclamator-Class Assault Ship", contentManager.Load<Texture2D>("Galactic Republic - Acclamator-Class Assault Ship")},
            {"Venator-Class Star Destroyer", contentManager.Load<Texture2D>("Galactic Republic - Venator-Class Star Destroyer")},
            {"Haven-Class Medical Station", contentManager.Load<Texture2D>("Galactic Republic - Haven-Class Medical Station")},
            {"Galactic Republic Insignia", contentManager.Load<Texture2D>("Galactic Republic - Insignia")},
            {"Advance Scout Ship", contentManager.Load<Texture2D>("Yuuzhan Vong - Advance Scout Ship")},
            {"Matalok", contentManager.Load<Texture2D>("Yuuzhan Vong - Matalok")},
            {"Miid Ro'ik", contentManager.Load<Texture2D>("Yuuzhan Vong - Miid Roik")},
            {"Kor Chokk", contentManager.Load<Texture2D>("Yuuzhan Vong - Kor Chokk")},
            {"Yuuzhan Vong Insignia", contentManager.Load<Texture2D>("Yuuzhan Vong - Insignia")},
            {"Yuuzhan Vong Worldship", contentManager.Load<Texture2D>("Yuuzhan Vong - Worldship")},
            {"Golan III Defense Platform", contentManager.Load<Texture2D>("Star Wars - Golan III Defense Platform")},
            {"XQ1 Platform", contentManager.Load<Texture2D>("Star Wars - XQ1 Platform")},
            {"Mining Station", contentManager.Load<Texture2D>("Mining Station")},
            {"Research Station", contentManager.Load<Texture2D>("Research Station")},
            {"Cargo Freighter", contentManager.Load<Texture2D>("Hylo Visz's Smuggling Contingent - Cargo Freighter.png")},
            {"Mandalorian Cruiser", contentManager.Load<Texture2D>("Mandalorian empire - Mandalorian Cruiser - Landed")},
            {"Interdictor-Class Cruiser", contentManager.Load<Texture2D>("Darth Reven's Sith Empire - Interdictor")},
            {"Darth Reven's Insigina", contentManager.Load<Texture2D>("Darth Reven's Sith Empire - Insignia")},
            {"Hazard", contentManager.Load<Texture2D>("Aperture Science -  every hazard.png")}
        };
    }

    public Dictionary<string, Texture2D> GetTextureDict()
    {
        return textureDict;
    }
}

    // private static Dictionary<string,string> textureDict = new Dictionary<string,string>
    // {
    //     {"Fury-Class Interceptor", "Reconstituted Sith Empire - Fury-Class Interceptor"},
    //     {"Terminus-Class Destroyer", "Reconstituted Sith Empire - Terminus-Class SD"},
    //     {"Harrower-Class Dreadnought", "Reconstituted Sith Empire - Harrower-Class SD"},
    //     {"Sith Space Station", "Reconstituted Sith Empire - Sith Space Station"},
    //     {"Reconstituted Sith Empire Insignia", "Reconstituted Sith Empire - Insignia"},
    //     {"MC30C Frigate", "Mon Calamari - MC30C Frigate"},
    //     {"MC75 Star Cruiser", "Mon Calamari - MC75 Star Cruiser"},
    //     {"MC80 Star Cruiser", "Mon Calamari - MC80 Star Cruiser"},
    //     {"Shipyards T-Frame", "Mon Calamari - Shipyards T-Frame"},
    //     {"Mon Calamari Insignia", "Mon Calamari - Insignia"},
    //     {"Marauder-Class Corvette", "CIS - Marauder-Class Corvette"},
    //     {"Munificient-Class Star Frigate", "CIS - Munificient-Class Star Frigate"},
    //     {"Providence-Class Fleet Carrier", "CIS - Providience-Class Fleet Carrier"},
    //     {"Lucrehulk-Class Battleship", "CIS - Lucrehulk-Class Battleship"},
    //     {"Separatist Insigna", "Confederacy of Independant Systems - Insignia"},
    //     {"Raider-Class Corvette", "Galactic Empire - Raider-Class Corvette"},
    //     {"Vindicator-Class Heavy Cruiser", "Galactic Empire - Vindicator-Class Heavy Cruiser"},
    //     {"Imperial Star Destroyer", "Galactic Empire - Imperial Star Destroyer"},
    //     {"Empress-Class Space Station", "Galactic Empire - Empress-Class Space Station"},
    //     {"Galactic Empire Insignia", "Galactic Empire - Insignia"},
    //     {"Arquitens-Class Light Cruiser", "Galactic Republic - Arquitens-Class Light Cruiser"},
    //     {"Acclamator-Class Assault Ship", "Galactic Republic - Acclamator-Class Assault Ship"},
    //     {"Venator-Class Star Destroyer", "Galactic Republic - Venator-Class Star Destroyer"},
    //     {"Haven-Class Medical Station", "Galactic Republic - Haven-Class Medical Station"},
    //     {"Galactic Republic Insignia", "Galactic Republic - Insignia"},
    //     {"Advance Scout Ship", "Yuuzhan Vong - Advance Scout Ship"},
    //     {"Matalok", "Yuuzhan Vong - Matalok"},
    //     {"Miid Ro'ik", "Yuuzhan Vong - Miid Roik"},
    //     {"Kor Chokk", "Yuuzhan Vong - Kor Chokk"},
    //     {"Yuuzhan Vong Insignia", "Yuuzhan Vong - Insignia"},
    //     {"Yuuzhan Vong Worldship", "Yuuzhan Vong - Worldship"},
    //     {"Golan III Defense Platform", "Star Wars - Golan III Defense Platform"},
    //     {"XQ1 Platform", "Star Wars - XQ1 Platform"},
    //     {"Mining Station", "Mining Station"},
    //     {"Research Station", "Research Station"},
    //     {"Cargo Freighter", "Hylo Visz's Smuggling Contingent - Cargo Freighter.png"},
    //     {"Mandalorian Cruiser", "Mandalorian empire - Mandalorian Cruiser - Landed"},
    //     {"Interdictor-Class Cruiser", "Darth Reven's Sith Empire - Interdictor"},
    //     {"Darth Reven's Insigina", "Darth Reven's Sith Empire - Insignia"},
    //     {"Hazard", "Aperture Science -  every hazard.png"}
    // };
// }