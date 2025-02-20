// using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarsConquest;

class Turret: WeaponsPlatform
{
    public Turret(Texture2D texture, int width, int cost, float maxHealth, float maxShields, List<Weapon> weapons): base(texture, width, "Turret", "Turret", cost, maxHealth, maxShields, weapons) {}
}