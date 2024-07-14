class ResearchStation: Platform
{
    private float researchRate;
    public ResearchStation(int maxHealth, int maxShields, float researchRate): base(maxHealth, maxShields)
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