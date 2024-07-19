// Movement Admiral:
// +-------------------------------------------------------+
// |Level | Bonus                                          |
// +------+------------------------------------------------+
// |  1   | 2 moves per turn                               |
// |  2   | 3 moves per turn                               |
// |  3   | 4 moves per turn, +30% attacking, +30% defense |
// |  4   | 5 moves per turn, +30% attacking, +30% defense |
// |  5   | 6 moves per turn, +60% attacking, +60% defense |
// +-------------------------------------------------------+
namespace StarWarsConquest;

class MovementAdmiral: Admiral
{
    public MovementAdmiral(string name, string description): base(name, description)
    {
        SetMovementSpeed(2);
    }

    public override void LevelUp()
    {
        level += 1;
        if (level == 2)
        {
            SetMovementSpeed(3);
        }
        if (level == 3)
        {
            SetMovementSpeed(4);
            SetAttackStrength(1.30);
            SetDefenseStrength(1.3);
        }
        if (level == 4)
        {
            SetMovementSpeed(5);
        }
        if (level == 5)
        {
            SetMovementSpeed(6);
            SetAttackStrength(1.6);
            SetDefenseStrength(1.6);
        }
    }
}