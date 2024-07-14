using System.ComponentModel.Design.Serialization;

class MiningStation: Platform
{
    private float miningEfficiency;
    public MiningStation(int maxHealth, int maxShields, float miningEfficiency): base(maxHealth, maxShields)
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