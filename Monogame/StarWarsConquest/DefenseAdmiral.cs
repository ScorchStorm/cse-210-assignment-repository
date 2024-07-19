// Defense Admiral:
// +-------------------------------------------------------+
// |Level | Bonus                                          |
// +------+------------------------------------------------+
// |  1   | +10% defense                                   |
// |  2   | +20% defense                                   |
// |  3   | +60% defense, 2 moves per turn                 |
// |  4   | +80% defense, 2 moves per turn                 |
// |  5   | +100% defense, 3 moves per turn                |
// +-------------------------------------------------------+
namespace StarWarsConquest;

class DefenseAdmiral: Admiral
{
    public DefenseAdmiral(string name, string description): base(name, description)
    {
        SetDefenseStrength(1.1);
    }

    public override void LevelUp()
    {
        level += 1;
        if (level == 2)
        {
            SetDefenseStrength(1.2);
        }
        if (level == 3)
        {
            SetDefenseStrength(1.6);
            SetMovementSpeed(2);
        }
        if (level == 4)
        {
            SetDefenseStrength(1.8);
        }
        if (level == 5)
        {
            SetDefenseStrength(2);
            SetMovementSpeed(3);
        }
    }
}