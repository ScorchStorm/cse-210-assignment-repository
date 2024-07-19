using System;
using System.Collections.Generic;
namespace StarWarsConquest;

class Program
{
    private string planetImageLocation = "C:\\Users\\Matthew\\OneDrive\\Documents\\BYU-I Spring Semester 2024 Files\\Programming with Classes (CSE 210)\\cse-210-assignment-repository\\final\\FinalProject\\images\\Sphere-with-blender.png";
    public void Main()
    {
        using var game = new StarWarsConquest.Game1(200, 200, planetImageLocation);
        game.Run();
        // using var galacticMap = new StarWarsConquest.GalacticMap();
        // galacticMap.Run();
    }
}
