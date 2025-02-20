using Microsoft.Xna.Framework.Graphics;
namespace StarWarsConquest;

class ResearchStation: Platform
{
    private float researchRate;
    public ResearchStation(Texture2D texture, int width, int cost, float maxHealth, float maxShields, float researchRate): base(texture, width, "Research Station", "Research Station", cost, maxHealth, maxShields)
    {
        this.researchRate = researchRate;
    }

    public void SetResearchRate(float researchRate)
    {
        this.researchRate = researchRate;
    }

    public float GetResearchRate()
    {
        return researchRate;
    }
}