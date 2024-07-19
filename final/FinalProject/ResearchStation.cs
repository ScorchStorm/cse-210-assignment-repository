class ResearchStation: Platform
{
    private float researchRate;
    public ResearchStation(int cost, float maxHealth, float maxShields, float researchRate): base(cost, maxHealth, maxShields)
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