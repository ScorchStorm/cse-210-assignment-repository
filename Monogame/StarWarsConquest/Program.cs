using System;
using System.Collections.Generic;
namespace StarWarsConquest;

class Program
{
    static void Main()
    {
        using var game = new Game1();
        game.Run();
    }
}
