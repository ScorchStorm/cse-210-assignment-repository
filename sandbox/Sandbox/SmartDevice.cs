abstract class SmartDevice
{
    protected bool isOn = false; // Smart home device can turn on / turn off
    protected DateTime startTime; // When the device was turned on
    protected string name; // Smart home device has a name
    protected double onTime; // Smart home devices keep track of how long they have been on for

    public SmartDevice(string name)
    {
        this.name = name;
        startTime = DateTime.Now;
    }
    public string GetStatus() // Smart home device can tell you if they are on or off
    {
        if (isOn)
        {
            return "on";
        }
        else
        {
            return "off";
        }
    }

    public bool GetIsOn() // Smart home device can tell you if they are on or off
    {
        return isOn;
    }

    public void SetStatus(bool power) // Smart home device can turn on and off
    {
        if (isOn != power) // if the device is being turned on or off
        {
            if (power) // if the device is being turned on
            {
                startTime = DateTime.Now; // record when it was turned on
            }
            else // if the device is being turned off, record how long it was on for
            {
                onTime += (DateTime.Now - startTime).TotalMinutes;
            }
        }
        isOn = power;
    }
    
    public double GetOnTime() // Smart home device can tell you how long they've been on for
    {
        if (isOn)
        {
            return onTime+(DateTime.Now - startTime).TotalMinutes;
        }
        else
        {
            return onTime;
        }
    }
    
    public string GetName()
    {
        return name;
    }
}