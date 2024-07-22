namespace StarWarsConquest;

class ResearchStation: Platform
{
    private float researchRate;
    public ResearchStation(int cost, float maxHealth, float maxShields, float researchRate): base("Research Station", "Research Station", cost, maxHealth, maxShields)
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