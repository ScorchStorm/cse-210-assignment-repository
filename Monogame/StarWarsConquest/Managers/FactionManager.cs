using System;
using System.Collections.Generic;
namespace StarWarsConquest;

class FactionManager
{
    List<Faction> factions;
    public FactionManager(Dictionary<string, StarSystem> systemDictionary, Dictionary<string, Texture2D> textureDict)
    {
        // starSystems = new List<StarSystem>{alderaan, alsakan, bespin, bilbringi, bonadan, bothawui, corellia, coruscant, dantooine, denon, dromundKaas, endor, eriadu, felucia, geonosis, helska, honoghr, hoth, kamino, kashyyyk, korriban, kuat, lego, mandalore, monCala, mustafar, muunilinst, mygeeto, naboo, nalHutta, onderon, ordMantell, ryloth, saleucami, serenno, sernpidal, sullust, taris, tatooine, tund, yagDhul, yavin};
        

        int credits  = 2000;
        StarSystem sithCapital = systemDictionary.GetValueOrDefault("dromundKass");
        List<string> sithResearchOptions= new List<string>{"Primary Weapon", "Secondary Weapon", "Hull Strength", "Mining Efficiency"};
        List<Admiral> sithAdmirals = new List<Admiral>{new AttackAdmiral("Darth Malgus", "Malgus is known for his brutal and relentless attacks, focusing on overwhelming his enemies with sheer force and destructive power."), new MovementAdmiral("Harridax Kirill", "Kirill's skill in quickly deploying fleets and executing rapid strikes makes him a key figure in Sith military strategy."), new AttackAdmiral("Saul Karath", "Karath's aggressive tactics and strategies were instrumental in many battles during the Sith Empire's campaigns.")};
        float sithMiningEfficiency = (float)1.4;
        float sithIndustry = (float)1.4;
        float sithFacilities = (float)1.2;
        float sithStationHealth = (float)1.2;
        float sithManeuvering = (float)1.1;
        float sithWeaponStrength = (float)1.4;
        float sithShieldStrength = (float)1.4;
        float sithShipHealth = (float)1.4;
        float sithCost = (float)1.2;
        float sithResearchEfficiency = (float)1.0;
        float sithRepairRate = (float)1.0;
        string sithScoutClassName = "Fury-Class Interceptor";
        string sithCruiserClassName = "Terminus-Class Destroyer";
        string sithDreadnaughtClassName = "Harrower-Class Dreadnought";
        string sithAdvancedStarbaseName = "Sith Space Station";
        Faction sithEmpire = new Faction(textureDict, "Sith Empire", credits, sithCapital, sithAdmirals, sithResearchOptions, sithMiningEfficiency, sithIndustry, sithFacilities, sithStationHealth, sithManeuvering, sithWeaponStrength, sithShieldStrength, sithShipHealth, sithCost, sithResearchEfficiency, sithRepairRate, sithScoutClassName, sithCruiserClassName, sithDreadnaughtClassName, sithAdvancedStarbaseName);
        
        StarSystem calamariCapital = systemDictionary.GetValueOrDefault("monCala");
        List<Admiral> calamariAdmirals = new List<Admiral>{new DefenseAdmiral("Ackbar", "Ackbar is celebrated for his defensive strategies, including his role in protecting the Rebel fleet and key locations like the Battle of Endor."), new AttackAdmiral("Raddus", "Raddus is known for his aggressive tactics and ability to hit enemy fleets hard, playing a key role in the Battle of Scarif."), new MovementAdmiral("Aril Nunb", "Nunb is known for her ability to move fleets swiftly and efficiently, playing a crucial role in several key battles for the Mon Calamari.")};
        List<string> calamariResearchOptions= new List<string>{"Shield Strength", "Manuvering", "Mining Efficiency", "Repair Rate"};
        float calamariMiningEfficiency = (float)1.2;
        float calamariIndustry = (float)1.2;
        float calamariFacilities = (float)1.3;
        float calamariStationHealth = (float)1.3;
        float calamariManeuvering = (float)1.4;
        float calamariWeaponStrength = (float)1.2;
        float calamariShieldStrength = (float)1.5;
        float calamariShipHealth = (float)1.2;
        float calamariCost = (float)1.3;
        float calamariResearchEfficiency = (float)1.3;
        float calamariRepairRate = (float)1.3;
        string calamariScoutClassName = "MC30C Frigate";
        string calamariCruiserClassName = "MC75 Star Cruiser";
        string calamariDreadnaughtClassName = "MC80 Star Cruiser";
        string calamariAdvancedStarbaseName = "Shipyards T-Frame";
        Faction monCalamari = new Faction(textureDict, "Mon Calamari", credits, calamariCapital, calamariAdmirals, calamariResearchOptions, calamariMiningEfficiency, calamariIndustry, calamariFacilities, calamariStationHealth, calamariManeuvering, calamariWeaponStrength, calamariShieldStrength, calamariShipHealth, calamariCost, calamariResearchEfficiency, calamariRepairRate, calamariScoutClassName, calamariCruiserClassName, calamariDreadnaughtClassName, calamariAdvancedStarbaseName);

        StarSystem separatistCapital = systemDictionary.GetValueOrDefault("geonosis");
        List<Admiral> separatistAdmirals = new List<Admiral> {new AttackAdmiral("Grievous", "Grievous is infamous for his aggressive tactics, focusing on inflicting heavy damage on Republic fleets and installations."), new DefenseAdmiral(" Trench", "Trench is adept at defending key Separatist positions and using cunning strategies to maintain control over contested areas."), new MovementAdmiral("Nym", "Nym's ability to move quickly and strike rapidly has been a significant advantage for the Separatist Alliance.")};
        List<string> separatistResearchOptions = new List<string>{"Option 1", "Option 2", "Option 3", "Option 4", "Option 5", "Option 6"};
        float separatistMiningEfficiency = (float)1.5;
        float separatistIndustry = (float)1.5;
        float separatistFacilities = (float)1.2;
        float separatistStationHealth = (float)1.2;
        float separatistManeuvering = (float)1.2;
        float separatistWeaponStrength = (float)1.3;
        float separatistShieldStrength = (float)1.2;
        float separatistShipHealth = (float)1.2;
        float separatistCost = (float)1.5;
        float separatistResearchEfficiency = (float)1.2;
        float separatistRepairRate = (float)1.3;
        string separatistScoutClassName = "Marauder-Class Corvette";
        string separatistCruiserClassName = "Munificient-Class Star Frigate";
        string separatistDreadnaughtClassName = "Providence-Class Fleet Carrier";
        string separatistAdvancedStarbaseName = "Lucrehulk-Class Battleship";
        Faction separatists = new Faction(textureDict, "Confederacy of Independent Systems", credits, separatistCapital, separatistAdmirals, separatistResearchOptions, separatistMiningEfficiency, separatistIndustry, separatistFacilities, separatistStationHealth, separatistManeuvering, separatistWeaponStrength, separatistShieldStrength, separatistShipHealth, separatistCost, separatistResearchEfficiency, separatistRepairRate, separatistScoutClassName, separatistCruiserClassName, separatistDreadnaughtClassName, separatistAdvancedStarbaseName);

        StarSystem imperialCapital = systemDictionary.GetValueOrDefault("endor");
        List<Admiral> imperialAdmirals = new List<Admiral>{new DefenseAdmiral("Piett", "Piett is known for his ability to protect key Imperial assets and maintain control over contested regions, exemplified by his command during the Battle of Endor."), new MovementAdmiral("Daala", "Daala's skills in quickly moving fleets through the galaxy and launching surprise attacks have been crucial in various Imperial campaigns."), new AttackAdmiral("Thrawn", "Thrawn is renowned for his tactical genius and ability to inflict devastating damage on enemy fleets through precise, well-planned attacks.")};
        List<string> imperialResearchOptions = new List<string>{"Option 1", "Option 2", "Option 3", "Option 4", "Option 5", "Option 6"};
        float imperialMiningEfficiency = (float)1.3;
        float imperialIndustry = (float)1.3;
        float imperialFacilities = (float)1.4;
        float imperialStationHealth = (float)1.4;
        float imperialManeuvering = (float)1.1;
        float imperialWeaponStrength = (float)1.5;
        float imperialShieldStrength = (float)1.3;
        float imperialShipHealth = (float)1.4;
        float imperialCost = (float)1.1;
        float imperialResearchEfficiency = (float)1.1;
        float imperialRepairRate = (float)1.1;
        string imperialScoutClassName = "Raider-Class Corvette";
        string imperialCruiserClassName = "Vindicator-Class Heavy Cruiser";
        string imperialDreadnaughtClassName = "Imperial Star Destroyer";
        string imperialAdvancedStarbaseName = "Empress-Class Space Station";
        Faction galacticEmpire = new Faction(textureDict, "Galactic Empire", credits, imperialCapital, imperialAdmirals, imperialResearchOptions, imperialMiningEfficiency, imperialIndustry, imperialFacilities, imperialStationHealth, imperialManeuvering, imperialWeaponStrength, imperialShieldStrength, imperialShipHealth, imperialCost, imperialResearchEfficiency, imperialRepairRate, imperialScoutClassName, imperialCruiserClassName, imperialDreadnaughtClassName, imperialAdvancedStarbaseName);

        StarSystem republicCapital = systemDictionary.GetValueOrDefault("coruscant");
        List<Admiral> republicAdmirals = new List<Admiral> {new DefenseAdmiral("Yularen", "Yularen is known for his defensive strategies during the Clone Wars, particularly in protecting key Republic assets and maintaining control over important regions."), new AttackAdmiral("Tarkin", "Tarkin, before becoming a Grand Moff for the Empire, demonstrated aggressive and effective tactics during the Clone Wars."), new MovementAdmiral("Wullf Yularen", "Yularen's ability to rapidly move fleets and coordinate attacks made him a vital asset in the Republic's war efforts against the Separatists.")};
        List<string> republicResearchOptions = new List<string>{"Option 1", "Option 2", "Option 3", "Option 4", "Option 5", "Option 6"};
        float republicMiningEfficiency = (float)1.4;
        float republicIndustry = (float)1.4;
        float republicFacilities = (float)1.3;
        float republicStationHealth = (float)1.3;
        float republicManeuvering = (float)1.3;
        float republicWeaponStrength = (float)1.2;
        float republicShieldStrength = (float)1.3;
        float republicShipHealth = (float)1.3;
        float republicCost = (float)1.3;
        float republicResearchEfficiency = (float)1.2;
        float republicRepairRate = (float)1.2;
        string republicScoutClassName = "Arquitens-Class Light Cruiser";
        string republicCruiserClassName = "Acclamator-Class Assault Ship";
        string republicDreadnaughtClassName = "Venator-Class Star Destroyer";
        string republicAdvancedStarbaseName = "Haven-Class Medical Station";
        Faction galacticRepublic = new Faction(textureDict, "Galactic Republic", credits, republicCapital, republicAdmirals, republicResearchOptions, republicMiningEfficiency, republicIndustry, republicFacilities, republicStationHealth, republicManeuvering, republicWeaponStrength, republicShieldStrength, republicShipHealth, republicCost, republicResearchEfficiency, republicRepairRate, republicScoutClassName, republicCruiserClassName, republicDreadnaughtClassName, republicAdvancedStarbaseName);

        // Yuuzhan Vong: Warmaster Tsavong Lah - Attack, Commander Czulkang Lah - Defense, Supreme Commander Nas Choka - Movement

        StarSystem vongCapital = systemDictionary.GetValueOrDefault("helska");
        List<Admiral> vongAdmirals = new List<Admiral>{new AttackAdmiral("Tsavong Lah", "Lah is known for his focus on aggressive and brutal attacks, seeking to cause maximum destruction to his enemies."), new DefenseAdmiral("Czulkang Lah", "Czulkang Lah excels in defensive strategies, protecting key Yuuzhan Vong territories and assets."), new MovementAdmiral("Nas Choka", "Choka is skilled in swiftly moving fleets and launching surprise attacks, making him a formidable force in the Yuuzhan Vong's war efforts.")};
        List<string> vongResearchOptions = new List<string>{"Option 1", "Option 2", "Option 3", "Option 4", "Option 5", "Option 6"};
        float vongMiningEfficiency = (float)1.2;
        float vongIndustry = (float)1.2;
        float vongFacilities = (float)1.1;
        float vongStationHealth = (float)1.1;
        float vongManeuvering = (float)1.5;
        float vongWeaponStrength = (float)1.5;
        float vongShieldStrength = (float)1.5;
        float vongShipHealth = (float)1.3;
        float vongCost = (float)1.1;
        float vongResearchEfficiency = (float)1.0;
        float vongRepairRate = (float)1.2;
        string vongScoutClassName = "Advance Scout Ship";
        string vongCruiserClassName = "Matalok";
        string vongDreadnaughtClassName = "Miid Ro'ik";
        string vongAdvancedStarbaseName = "Kor Chokk";
        Faction yuuzhanVong = new Faction(textureDict, "Yuuzhan Vong", credits, vongCapital, vongAdmirals, vongResearchOptions, vongMiningEfficiency, vongIndustry, vongFacilities, vongStationHealth, vongManeuvering, vongWeaponStrength, vongShieldStrength, vongShipHealth, vongCost, vongResearchEfficiency, vongRepairRate, vongScoutClassName, vongCruiserClassName, vongDreadnaughtClassName, vongAdvancedStarbaseName);
    
        factions = new List<Faction>(){sithEmpire, monCalamari, galacticEmpire, galacticRepublic, yuuzhanVong};
    }

    public List<Faction> GetFactions()
    {
        return factions;
    }

    public void BuildTestFleets()
    {
        foreach (Faction faction in factions)
        {
            faction.CreateNewFleet();
            // faction.AddNewShip(faction.getDreadnaught());
        }
    }
}