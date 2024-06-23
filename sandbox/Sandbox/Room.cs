class Room // has devices
{
    private string name;
    List<SmartDevice> smartDevices = new List<SmartDevice>();
    public Room(List<SmartDevice> smartDevices, string name)
    {
        this.smartDevices = smartDevices;
        this.name = name;
    }

    public void PowerAllLights(bool power) // Turn on/off all lights
    {
        foreach (SmartDevice device in smartDevices)
        {
            if (device is SmartLight)
            {
                device.SetStatus(power);
            }
        }
    }

    public void PowerDevice(SmartDevice device, bool power) // Turn on/off device
    {
        device.SetStatus(power);
    }
    
    public void PowerAllDevices(bool power) // Turn on/off all devices in Room
    {
        foreach (SmartDevice device in smartDevices)
        {
            device.SetStatus(power);
        }
    }

    public void ReportAllStatus() // Report All items in the room and their status
    {
        foreach (SmartDevice device in smartDevices)
        {
            Console.WriteLine($"{device.GetName()} is {device.GetStatus()}");
        }
    }

    public void ReportAllOn() // Report All items that are on
    {
        foreach (SmartDevice device in smartDevices)
        {
            if (device.GetIsOn())
            {
                Console.WriteLine($"{device.GetName()} is {device.GetStatus()}");
            }
        }
    }
    
    public void ReportLongestOn() // Report Item that have been on the longest
    {
        SmartDevice longestOn = smartDevices[0];
        foreach (SmartDevice device in smartDevices)
        {
            if (device.GetOnTime() > longestOn.GetOnTime())
            {
                longestOn = device;
            }
        }
        Console.WriteLine($"The device that has been turned on the longest is {longestOn.GetName()} which was on for {longestOn.GetOnTime()} minutes");
    }

    public List<SmartDevice> GetDevices()
    {
        return smartDevices;
    }
}