using System;
class Program
{
    static void Main(string[] args)
    {
        // GalacticMap galacticMap = new GalacticMap();
        // galacticMap.DisplayGalacticMap();
        // SimpleGame.GameForm simplegame = new SimpleGame.GameForm();
        Animation.GameForm animation = new Animation.GameForm();
        
        int xDis = 140;
        int yDis = 70;
        int size = 150;
        int xOffset1 = 50;
        int yOffset1 = 100;
        int xOffset2 = xDis+50+xOffset1;
        int yOffset2 = -yDis-25+yOffset1;
        string calamariDreadnaughtImage = "C:\\Users\\Matthew\\OneDrive\\Documents\\BYU-I Spring Semester 2024 Files\\Programming with Classes (CSE 210)\\cse-210-assignment-repository\\final\\FinalProject\\images\\Rebel Alliance - Home One.png";
        animation.AddPicture(calamariDreadnaughtImage, 3*xDis+xOffset2, 3*yDis+yOffset2, size);
        animation.AddPicture(calamariDreadnaughtImage, 4*xDis+xOffset2, 4*yDis+yOffset2, size);
        animation.AddPicture(calamariDreadnaughtImage, 5*xDis+xOffset2, 5*yDis+yOffset2, size);
        animation.AddPicture(calamariDreadnaughtImage, 6*xDis+xOffset2, 6*yDis+yOffset2, size);
        animation.AddPicture(calamariDreadnaughtImage, 4*xDis+xOffset2, 2*yDis+yOffset2, size);
        animation.AddPicture(calamariDreadnaughtImage, 5*xDis+xOffset2, 3*yDis+yOffset2, size);
        animation.AddPicture(calamariDreadnaughtImage, 6*xDis+xOffset2, 4*yDis+yOffset2, size);

        string sithDreadnaughtImage = "C:\\Users\\Matthew\\OneDrive\\Documents\\BYU-I Spring Semester 2024 Files\\Programming with Classes (CSE 210)\\cse-210-assignment-repository\\final\\FinalProject\\images\\Reconstituted Sith Empire - Harrower Class SD.png";
        animation.AddPicture(sithDreadnaughtImage, 3*xDis+xOffset1, 2*yDis+yOffset1, size);
        animation.AddPicture(sithDreadnaughtImage, 4*xDis+xOffset1, 3*yDis+yOffset1, size);
        animation.AddPicture(sithDreadnaughtImage, 5*xDis+xOffset1, 4*yDis+yOffset1, size);
        animation.AddPicture(sithDreadnaughtImage, 6*xDis+xOffset1, 5*yDis+yOffset1, size);
        animation.AddPicture(sithDreadnaughtImage, 3*xDis+xOffset1, 4*yDis+yOffset1, size);
        animation.AddPicture(sithDreadnaughtImage, 4*xDis+xOffset1, 5*yDis+yOffset1, size);
        animation.AddPicture(sithDreadnaughtImage, 5*xDis+xOffset1, 6*yDis+yOffset1, size);

        // animation.AddPicture(sithDreadnaughtImage, 100, 100, 200);
        // animation.AddPicture(sithDreadnaughtImage, 100, 150, 200);
        // animation.AddPicture(sithDreadnaughtImage, 100, 200, 200);
        // animation.AddPicture(sithDreadnaughtImage, 100, 250, 200);
        animation.ShowDialog();
        // Console.WriteLine("We got here");

        // // animation.AddMovingPicture(sithDreadnaughtImage, 0, 0, 100);
        // // int credits  = 2000;
        // // StarSystem sithCapital = new StarSystem("Dromund Kaas", 5, "Capital of the Reconstituted Sith Empire, where the Sith Emperor resided and planned the war against the Republic.");
        // // List<string> sithResearchOptions= new List<string>{"Primary Weapon", "Secondary Weapon", "Hull Strength", "Mining Efficiency"};
        // // // AttackAdmiral sithAdmiralOne = new AttackAdmiral("Darth Malgus", "Malgus is known for his brutal and relentless attacks, focusing on overwhelming his enemies with sheer force and destructive power.");
        // // // MovementAdmiral sithAdmiralTwo = new MovementAdmiral("Harridax Kirill", "Kirill's skill in quickly deploying fleets and executing rapid strikes makes him a key figure in Sith military strategy.");
        // // // AttackAdmiral sithAdmiralThree = new AttackAdmiral("Saul Karath", "Karath's aggressive tactics and strategies were instrumental in many battles during the Sith Empire's campaigns.");
        // // // List<Admiral> sithAdmirals = List<Admiral>{sithAdmiralOne, sithAdmiralTwo, sithAdmiralThree};
        // // List<Admiral> sithAdmirals = new List<Admiral>{new AttackAdmiral("Darth Malgus", "Malgus is known for his brutal and relentless attacks, focusing on overwhelming his enemies with sheer force and destructive power."), new MovementAdmiral("Harridax Kirill", "Kirill's skill in quickly deploying fleets and executing rapid strikes makes him a key figure in Sith military strategy."), new AttackAdmiral("Saul Karath", "Karath's aggressive tactics and strategies were instrumental in many battles during the Sith Empire's campaigns.")};
        // // float sithMiningEfficiency = (float)1.3;
        // // float sithIndustry = (float)1.3;
        // // float sithFacilities = (float)1.2;
        // // float sithStationHealth = (float)1.2;
        // // float sithManeuvering = (float)1.1;
        // // float sithWeaponStrength = (float)1.5;
        // // float sithShieldStrength = (float)1.4;
        // // float sithShipHealth = (float)1.4;
        // // float sithCost = (float)1.2;
        // // float sithResearchEfficiency = (float)1.0;
        // // float sithRepairRate = (float)1.0;
        // // string sithScoutClassName = "Fury-Class Interceptor";
        // // string sithCruiserClassName = "Terminus-Class Destroyer";
        // // string sithDreadnaughtClassName = "Harrower-Class Dreadnought";
        // // Faction sithEmpire = new Faction("Sith Empire", credits, sithCapital, sithAdmirals, sithResearchOptions, sithMiningEfficiency, sithIndustry, sithFacilities, sithStationHealth, sithManeuvering, sithWeaponStrength, sithShieldStrength, sithShipHealth, sithCost, sithResearchEfficiency, sithRepairRate, sithScoutClassName, sithCruiserClassName, sithDreadnaughtClassName);
        
        // // // DefenseAdmiral calimariAdmiralOne = new DefenseAdmiral("Ackbar", "Ackbar is celebrated for his defensive strategies, including his role in protecting the Rebel fleet and key locations like the Battle of Endor.");
        // // // AttackAdmiral calimariAdmiralTwo = new AttackAdmiral("Raddus", "Raddus is known for his aggressive tactics and ability to hit enemy fleets hard, playing a key role in the Battle of Scarif.");
        // // // MovementAdmiral calimariAdmiralThree = new MovementAdmiral("Aril Nunb", "Nunb is known for her ability to move fleets swiftly and efficiently, playing a crucial role in several key battles for the Mon Calamari.");
        // // StarSystem calamariCapital = new StarSystem("Mon Cala", 5, "Mon Cala, home to the Mon Calamari and Quarren, is crucial for its shipyards that produced advanced warships for the Rebel Alliance and later the New Republic. During the Clone Wars, the planet was a contested site between the Republic and the Separatists. Under the Empire, Mon Cala faced brutal oppression, leading to its strong support for the Rebellion. Its shipbuilding capabilities were pivotal in numerous galactic conflicts.");
        // // List<Admiral> calamariAdmirals = new List<Admiral>{new DefenseAdmiral("Ackbar", "Ackbar is celebrated for his defensive strategies, including his role in protecting the Rebel fleet and key locations like the Battle of Endor."), new AttackAdmiral("Raddus", "Raddus is known for his aggressive tactics and ability to hit enemy fleets hard, playing a key role in the Battle of Scarif."), new MovementAdmiral("Aril Nunb", "Nunb is known for her ability to move fleets swiftly and efficiently, playing a crucial role in several key battles for the Mon Calamari.")};
        // // List<string> calamariResearchOptions= new List<string>{"Shield Strength", "Manuvering", "Mining Efficiency", "Repair Rate"};
        // // float calamariMiningEfficiency = (float)1.2;
        // // float calamariIndustry = (float)1.2;
        // // float calamariFacilities = (float)1.3;
        // // float calamariStationHealth = (float)1.3;
        // // float calamariManeuvering = (float)1.4;
        // // float calamariWeaponStrength = (float)1.2;
        // // float calamariShieldStrength = (float)1.5;
        // // float calamariShipHealth = (float)1.2;
        // // float calamariCost = (float)1.3;
        // // float calamariResearchEfficiency = (float)1.1;
        // // float calamariRepairRate = (float)1.2;
        // // string calamariScoutClassName = "CR90 Corvette (Blockade Runner)";
        // // string calamariCruiserClassName = "MC75 Star Cruiser";
        // // string calamariDreadnaughtClassName = "MC80 Star Cruiser";
        // // Faction monCalamari = new Faction("Mon Calamari", credits, calamariCapital, calamariAdmirals, calamariResearchOptions, calamariMiningEfficiency, calamariIndustry, calamariFacilities, calamariStationHealth, calamariManeuvering, calamariWeaponStrength, calamariShieldStrength, calamariShipHealth, calamariCost, calamariResearchEfficiency, calamariRepairRate, calamariScoutClassName, calamariCruiserClassName, calamariDreadnaughtClassName);
        
        // // Fleet sithFleet = sithEmpire.GetFleet(0);
        // // sithFleet.Move(calamariCapital);
        }
}