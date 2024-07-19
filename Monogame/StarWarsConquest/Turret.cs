using System;
using System.Collections.Generic;
namespace StarWarsConquest;

class Turret: WeaponsPlatform
{
    public Turret(int cost, float maxHealth, float maxShields, List<Weapon> weapons): base(cost, maxHealth, maxShields, weapons) {}
}