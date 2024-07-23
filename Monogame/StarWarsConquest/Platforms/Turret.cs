// using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarsConquest;

class Turret: WeaponsPlatform
{
    public Turret(Texture2D texture, float scale, int cost, float maxHealth, float maxShields, List<Weapon> weapons): base(texture, scale, "Turret", "Turret", cost, maxHealth, maxShields, weapons) {}
}