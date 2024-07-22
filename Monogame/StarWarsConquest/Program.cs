using System;
using System.Collections.Generic;
namespace StarWarsConquest;

class Program
{
    // private string planetImageLocation = "C:\\Users\\Matthew\\OneDrive\\Documents\\BYU-I Spring Semester 2024 Files\\Programming with Classes (CSE 210)\\cse-210-assignment-repository\\final\\FinalProject\\images\\Sphere-with-blender.png";
    static void Main()
    {
        // using var game = new StarWarsConquest.Game1(200, 200, planetImageLocation);
        Console.WriteLine("we got here 1!");
        // using var game = new Game1Old(100, 100, "Sphere-with-blender");
        using var game = new Game1();
        game.Run();
        // game.DrawGalaxyMap();
        Console.WriteLine("we got here 2!");
        // using var galacticMap = new StarWarsConquest.GalacticMap();
        // galacticMap.Run();
    }
}
