// using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarsConquest;

class Turret: WeaponsPlatform
{
    string imageName = "Star Wars - XQ1 Platform";
    Texture2D texture = Content.Load<Texture2D>(imageName);
    public Turret(int cost, float maxHealth, float maxShields, List<Weapon> weapons): base("Turret", "Turret", cost, maxHealth, maxShields, weapons) {}
}