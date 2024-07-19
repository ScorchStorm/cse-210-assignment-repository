// Attack Admiral:
// +-------------------------------------------------------+
// |Level | Bonus                                          |
// +------+------------------------------------------------+
// |  1   | +10% attacking                                 |
// |  2   | +30% attacking                                 |
// |  3   | +60% attacking, 2 moves per turn               |
// |  4   | +80% attacking, 2 moves per turn               |
// |  5   | +100% attacking, 3 moves per turn              |
// +-------------------------------------------------------+
namespace StarWarsConquest;

class AttackAdmiral: Admiral
{
    public AttackAdmiral(string name, string description): base(name, description)
    {
        SetAttackStrength(1.1);
    }

    public override void LevelUp()
    {
        level += 1;
        if (level == 2)
        {
            SetAttackStrength(1.3);
        }
        if (level == 3)
        {
            SetAttackStrength(1.6);
            SetMovementSpeed(2);
        }
        if (level == 4)
        {
            SetAttackStrength(1.8);
        }
        if (level == 5)
        {
            SetAttackStrength(2);
            SetMovementSpeed(3);
        }
    }
}