using System.ComponentModel.Design.Serialization;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarsConquest;
class MiningStation: Platform
{
    private float miningEfficiency;
    public MiningStation(Texture2D texture, float scale, int cost, float maxHealth, float maxShields, float miningEfficiency): base(texture, scale, "Mining Station", "Mining Station", cost, maxHealth, maxShields)
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