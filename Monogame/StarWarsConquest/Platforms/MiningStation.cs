using System.ComponentModel.Design.Serialization;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarsConquest;
class MiningStation: Platform
{
    private float miningEfficiency;
    public MiningStation(Texture2D texture, int width, int cost, float maxHealth, float maxShields, float miningEfficiency): base(texture, width, "Mining Station", "Mining Station", cost, maxHealth, maxShields)
    {
        this.miningEfficiency = miningEfficiency;
    }

    public void SetMiningRate(float miningEfficiency)
    {
        this.miningEfficiency = miningEfficiency;
    }

    public float GetMiningRate()
    {
        return miningEfficiency;
    }
}