using System;
class Program
{
    static void Main(string[] args)
    {
        List<Room> rooms = new List<Room>();
        List<SmartDevice> smartDevices = new List<SmartDevice>();
        SmartLight lightOne = new SmartLight("light one");
        smartDevices.Add(lightOne);
        SmartLight lightTwo = new SmartLight("light two");
        smartDevices.Add(lightTwo);
        SmartLight lightThree = new SmartLight("light three");
        smartDevices.Add(lightThree);
        Room roomOne = new Room(smartDevices, "Room One");
        rooms.Add(roomOne);
        smartDevices.Clear();
        SmartLight lightFour = new SmartLight("light four");
        smartDevices.Add(lightFour);
        SmartTV tvOne = new SmartTV("SmartTV one");
        smartDevices.Add(tvOne);
        SmartHeater heaterOne = new SmartHeater("SmartHeater one");
        smartDevices.Add(heaterOne);
        Room roomTwo = new Room(smartDevices, "Room Two");
        rooms.Add(roomTwo);
        House house = new House(rooms);

        Choice choice = new Choice("Select a Room", new List<string>{"Room One", "Room Two"});
        int roomIndex = choice.MakeChoice();
        Room room = rooms[roomIndex];
        List<SmartDevice> roomSmartDevices = room.GetDevices();
        Console.WriteLine("Welcome to the room control menu.");
        while (true)
        {
            Console.WriteLine();
            Choice choiceOne = new Choice("Please select one of the following options:", new List<string>{"Turn on all lights", "Turn off all lights", "select a device", "Turn on all devices", "Turn off all devices", "Report All items in the room and their status", "Report All items that are on", "Report Item that have been on the longest", "quit the program"});
            int index = choiceOne.MakeChoice();
            Console.WriteLine();
            if (index == 0)
            {
                room.PowerAllLights(true); // Turn on all lights
            }
            else if (index == 1)
            {
                room.PowerAllLights(false); // Turn off all lights
            }
            else if (index == 2)
            {
                List<string> names = new List<string>{};
                foreach (SmartDevice device in roomSmartDevices)
                {
                    names.Add(device.GetName());
                }
                Choice choiceTwo = new Choice("Select a device", names);
                index = choiceTwo.MakeChoice();
                SmartDevice chosenDevice = roomSmartDevices[index];
                Choice choiceThree = new Choice("What would you like to do to the device", new List<string>{"Turn on device","Turn off device"});
                index = choiceThree.MakeChoice();
                if (index == 0)
                {
                    room.PowerDevice(chosenDevice, true); // Turn on device
                }
                if (index == 1)
                {
                    room.PowerDevice(chosenDevice, false); // Turn off device
                }
            }
            else if (index == 3)
            {
                room.PowerAllDevices(true); // Turn on All devices in Room
            }
            else if (index == 4)
            {
                room.PowerAllDevices(false); // Turn off All devices in Room
            }
            else if (index == 5)
            {
                room.ReportAllStatus(); // Report All items in the room and their status
            }
            else if (index == 6)
            {
                room.ReportAllOn(); // Report All items that are on
            }
            else if (index == 7)
            {
                room.ReportLongestOn(); // Report Item that have been on the longest
            }
            else if (index == 8)
            {
                Environment.Exit(1); // Quits the program
            }
        }
    }
}