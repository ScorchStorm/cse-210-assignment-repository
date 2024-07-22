using System;
using System.Collections.Generic;
namespace StarWarsConquest;

class GalacticMapScene : IScene
{
    // private List<List<StarSystem>> hyperlanes;
    private List<StarSystem> starSystems;
    // private string planetImageLocation = "C:\\Users\\Matthew\\OneDrive\\Documents\\BYU-I Spring Semester 2024 Files\\Programming with Classes (CSE 210)\\cse-210-assignment-repository\\final\\FinalProject\\images\\Sphere-with-blender.png";
    private string imageName = "Sphere-with-blender";
    public static Dictionary<string, StarSystem> systemDictionary;
    public GalacticMap()
    {
        // 1200, 1510, 
        StarSystem alderaan = new StarSystem("Alderaan", 3, 1200, 1510, imageName,"Alderaan, once a beacon of beauty, culture, and peace, now stands as a somber testament to the Empire's ruthlessness. Its destruction by the Death Star did more than erase a world; it ignited a fire of rebellion across the galaxy. This tragedy fueled the resolve of countless systems to oppose the tyranny of the Galactic Empire. Though it no longer exists, the spirit of Alderaan lives on, inspiring the Rebellion. Its legacy remains one of defiance and hope, a symbol for those who resist oppression.");
        // 1060, 1520, 
        StarSystem alsakan = new StarSystem("Alsakan", 4, 1060, 1520, imageName,"Alsakan, a world of rich history and frequent rival to Coruscant, boasts a legacy of conflict and culture. Throughout the millennia, Alsakan has vied for dominance with the Core World superpower. Its well-developed infrastructure and strategic position in the Core have influenced galactic politics and power struggles. Alsakan continues to be a symbol of enduring rivalry and ambition.");
        // 750, 2430, 
        StarSystem bespin = new StarSystem("Bespin", 3, 750, 2430, imageName,"The gas giant Bespin, home to Cloud City, is renowned for its tibanna gas mines. This rare and valuable resource is critical for starship weaponry, making Bespin a strategic asset. The city's neutrality was shattered when the Empire occupied it, leading to the infamous duel between Darth Vader and Luke Skywalker, where Luke lost his hand. Bespin's significance lies in its economic contributions and the dramatic events that unfolded in its skies.");
        // 780, 1260, 
        StarSystem bilbringi = new StarSystem("Bilbringi", 4, 780, 1260, imageName,"Bilbringi is synonymous with shipbuilding and logistics, its shipyards a vital cog in the Galactic Empire's war machine. The system has seen many battles, notably during the Yuuzhan Vong War, where control of its shipyards was fiercely contested. Today, Bilbringi remains a key hub of industrial might and strategic relevance. Its legacy continues to be one of pivotal importance in galactic conflicts.");
        // 1750, 510, 
        StarSystem bonadan = new StarSystem("Bonadan", 3, 1750, 510, imageName,"Bonadan, an industrial world in the Corporate Sector, is marked by its sprawling factories and polluted atmosphere. While it lacks significant military history, its economic contributions have been noteworthy. The planet's factories produce a wide array of goods, supporting various factions indirectly through commerce and trade. Bonadan's industrial output has long made it a valuable asset in the galaxy.");
        // 1910, 2160, 
        StarSystem bothawui = new StarSystem("Bothawui", 2, 1910, 2160, imageName,"Bothawui, the Bothan homeworld, is a hub of intelligence and intrigue. The Bothans' extensive spy network played a pivotal role in the Rebellion, famously acquiring the Death Star II plans. The planet's strategic value extends beyond espionage, with its central location and developed infrastructure. Bothawui's legacy of subterfuge and its impact on major galactic events are well known.");
        // 1170,1850, 
        StarSystem corellia = new StarSystem("Corellia", 5, 1170, 1850, imageName,"Corellia, a core world known for its skilled pilots and shipbuilders, has long been a linchpin in galactic trade and conflict. Home to the legendary Han Solo, Corellia's shipyards produce some of the galaxy's finest starships. The planet's strategic position and industrial capabilities have made it a crucial asset throughout history. Corellia's storied past highlights its enduring importance.");
        // 900, 1480, 
        StarSystem coruscant = new StarSystem("Coruscant", 5, 900, 1480, imageName,"Coruscant, the glittering jewel of the Core Worlds, serves as the political and cultural heart of the galaxy. It has been the capital of the Galactic Republic and the Galactic Empire, a nexus of power, trade, and influence. The Republic Senate once convened here, guiding the fate of countless star systems. Later, the Galactic Empire's iron grip was firmly established within its towering spires. Coruscant's strategic location and immense population have shaped the course of galactic history.");
        // 1060, 690, 
        StarSystem dantooine = new StarSystem("Dantooine", 1, 1060, 690, imageName,"Dantooine, a remote agrarian world, holds a quiet significance in galactic history. Once a hidden Rebel base, its plains and ruins have seen both peace and conflict. Though the Rebel base was abandoned, the planet's isolation has made it a potential staging ground for covert operations. Dantooine's pastoral serenity belies its historical role in the larger galactic narrative.");
        // 1390, 2120, 
        StarSystem denon = new StarSystem("Denon", 4, 1390, 2120, imageName,"Denon, a bustling ecumenopolis, rivals Coruscant in its urban sprawl and economic might. Its location at the intersection of major hyperlanes makes it a vital nexus for trade and travel. Denon's infrastructure and population density make it a key strategic asset. The planet's significance lies in its economic power and central position, influencing galactic commerce and politics.");
        // 2040, 620, 
        StarSystem dromundKaas= new StarSystem("Dromund Kaas", 5, 2040, 620, imageName,"Dromund Kaas, shrouded in perpetual storms and dark side energy, serves as the capital of the Reconstituted Sith Empire. This ancient world is steeped in Sith history, with powerful dark side nexuses that bolster the strength of any Sith who rule there. The Sith Emperor's presence has solidified Dromund Kaas as a bastion of dark side influence, with its strategic and mystical importance drawing Sith from across the galaxy.");
        // 350, 2520, 
        StarSystem endor = new StarSystem("Endor", 5, 350, 2520, imageName,"The forest moon of Endor, nestled in the Outer Rim, unexpectedly became a pivotal point in galactic history. Once a tranquil sanctuary for the Ewoks, Endor's significance soared when Emperor Palpatine made the second Death Star his command center. With the destruction of this battle station, the Galactic Empire suffered a crippling blow. Today, Endor's legacy as a former seat of Imperial power and the site of a decisive Rebel victory cannot be understated.");
        // 1220, 2770, 
        StarSystem eriadu = new StarSystem("Eriadu", 4, 1220, 2770, imageName,"Eriadu is an industrial hub, influential in the rise of key Imperial figures such as Grand Moff Tarkin. The planet's manufacturing capabilities have made it a significant contributor to the Imperial war machine. Eriadu's strategic location and resources play crucial roles in galactic politics and conflicts. Its industrial prowess continues to impact the galaxy.");
        // 1930, 920, 
        StarSystem felucia = new StarSystem("Felucia", 3, 1930, 920, imageName,"Felucia, a vibrant and dangerous jungle world, is known for its exotic flora and fauna. The planet saw significant action during the Clone Wars, with its unique terrain posing challenges for both droid and clone forces. Felucia's biodiversity and potential as a hidden base have long made it a point of interest. The planet's colorful landscape hides many secrets, reflecting its complex role in the galaxy.");
        // 1940, 2550, 
        StarSystem geonosis = new StarSystem("Geonosis", 5, 1940, 2550, imageName,"Geonosis, the arid desert world, is where the Separatist Alliance was forged. This planet's role in the Clone Wars is undeniable, having hosted the first major conflict between the Republic and the Confederacy of Independent Systems. The Geonosian foundries produced legions of battle droids, making it a critical asset for the Separatists. Geonosis remains a symbol of rebellion against centralized control and a reminder of the war that reshaped the galaxy.");
        // 1050, 340, 
        StarSystem helska = new StarSystem("Helska IV", 2, 1050, 340, imageName,"Helska IV, a frozen world in the Unknown Regions, marks the vanguard of the Yuuzhan Vong's invasion into the galaxy. The Supreme Overlord's flagship initially anchored here, orchestrating the first strikes against the galaxy. Though the Vong's foothold in Helska was eventually eradicated, the system's significance as the starting point of their incursion into known space endures.");
        // 2210, 1540, 
        StarSystem honoghr = new StarSystem("Honoghr", 2, 2210, 1540, imageName,"Honoghr, a devastated world, is the home of the Noghri. Once poisoned during the Clone Wars, the planet has struggled to recover. Despite its ecological hardships, Honoghr's inhabitants offer fierce loyalty and formidable combat skills. The Noghri's dedication to their saviors has made the planet an asset in various conflicts, with its significance rooted in the strength and loyalty of its people.");
        // 670, 2770, 
        StarSystem hoth = new StarSystem("Hoth", 1, 670, 2770, imageName,"Hoth, an icy wasteland on the fringe of the galaxy, was once the site of the Rebel Alliance's Echo Base. This remote location provided temporary refuge until the Empire's assault drove the Rebels away. Today, Hoth offers little more than desolation and a stark reminder of past battles. Its current strategic value is minimal, though its historical significance as a Rebel stronghold persists.");
        // 2140, 2260, 
        StarSystem kamino = new StarSystem("Kamino", 4, 2140, 2260, imageName,"Kamino, an oceanic planet, is renowned for its cloning facilities, where the Grand Army of the Republic was created. The planet's strategic importance during the Clone Wars cannot be overstated, as its clone troopers were pivotal in the Republic's fight against the Separatists. Kamino's role in the creation of the clone army makes it a key location in the galaxy.");
        // 1700, 1470, 
        StarSystem kashyyyk = new StarSystem("kashyyyk", 3, 1700, 1470, imageName,"Kashyyyk, the lush forest homeworld of the Wookiees, is known for its unique ecosystem and fierce warriors. The planet was a battleground during the Clone Wars and later faced brutal occupation by the Empire. Wookiee resistance fighters played a crucial role in various conflicts, supporting both the Republic and the Rebellion. Kashyyyk's strategic value and strong defenders make it a pivotal location.");
        // 1910, 740, 
        StarSystem korriban = new StarSystem("Korriban", 4, 1910, 740, imageName,"Korriban, the ancient Sith homeworld, is steeped in dark side energy and history. Its tombs and temples hold powerful artifacts and secrets, making it a focal point for Sith power. Korriban's influence extends beyond its barren surface, with the dark side's presence felt throughout the galaxy. The planet's legacy as a cradle of Sith knowledge has made it a key point of interest for those seeking to harness its power.");
        // 1240, 1670, 
        StarSystem kuat = new StarSystem("Kuat", 5, 1240, 1670, imageName,"Kuat, renowned for its shipyards, is a cornerstone of galactic naval power. The planet's orbital ring has produced some of the most advanced warships in the galaxy. Kuat's industrial capacity and strategic location have made it indispensable in numerous conflicts. The planet's contributions to countless fleets underscore its central role in galactic warfare.");
        // 2180, 1100, 
        StarSystem lego = new StarSystem("Lego", 1, 2180, 1100, imageName,"Lego, a remote and relatively obscure planet, has not played a significant role in major galactic events. Its peaceful existence and lack of notable resources have kept it largely out of the spotlight. Despite its obscurity, Lego's untouched landscapes and tranquility offer a stark contrast to the tumultuous galaxy. The planet remains a quiet enclave away from the conflict.");
        // 1560, 1050, 
        StarSystem mandalore = new StarSystem("Mandalore", 4, 1560, 1050, imageName,"Mandalore, home of the  fierce Mandalorian warriors, has a rich warrior culture and history of conflict. Mandalore has been a pivotal world in numerous conflicts. Its warrior culture and advanced technology have made it a significant force in galactic history. Mandalore's strategic position and the combat prowess of its inhabitants have long influenced the balance of power. The planet's legacy is marked by its martial traditions and impact on warfare.");
        // 2400, 1000, 
        StarSystem monCala = new StarSystem("Mon Cala", 5, 2400, 1000, imageName,"Mon Cala, home to the Mon Calamari and Quarren, is a vital aquatic world known for its shipyards. These shipyards were instrumental in the creation of the Rebel Alliance's fleet. The planet's strategic value lies not only in its shipbuilding prowess but also in its resilient spirit, having withstood multiple Imperial assaults. Mon Cala's legacy is one of defiance and ingenuity.");
        // 890, 3000, 
        StarSystem mustafar = new StarSystem("Mustafar", 2, 890, 3000, imageName,"Mustafar, a volcanic planet of fire and brimstone, is most infamous as the site of the duel between Anakin Skywalker and Obi-Wan Kenobi. Its lava rivers and treacherous terrain have made it a hazardous locale. Despite its dangers, Mustafar's resources have attracted mining operations. The planet was home to many droid factories and served as a final refuge for the Separatist leadership towards the end of the Clone Wars.The planet's fiery landscape and historical significance have etched it into the annals of galactic lore.");
        // 740, 630, 
        StarSystem muunilinst = new StarSystem("Muunilinst", 4, 740, 630, imageName,"Muunilinst is the headquarters of the InterGalactic Banking Clan, a major financial power during the Clone Wars. The planet's wealth and resources made it a key supporter of the Separatist Alliance. Muunilinst saw significant battles as the Republic sought to disrupt Separatist funding. Its economic influence extends beyond the Clone Wars, affecting galactic politics and finance.");
        // 870, 810, 
        StarSystem mygeeto = new StarSystem("Mygeeto", 3, 870, 810, imageName,"Mygeeto, a planet rich in valuable crystal deposits, was a significant battleground during the Clone Wars. The Republic and Separatists both sought control of this strategic world due to its crucial resources. The icy, crystalline landscape made the planet a unique and challenging site for conflict. Mygeeto's role in the Clone Wars underscores its importance as a resource-rich world vital to the war efforts of both sides.");
        // 1480, 2600, 
        StarSystem naboo = new StarSystem("Naboo", 4, 1480, 2600, imageName,"Naboo is a planet known for its natural beauty and cultural heritage, playing a crucial role in galactic politics. It is the homeworld of Emperor Palpatine and saw significant battles during the Clone Wars. The planet's peaceful society was disrupted by the Trade Federation's blockade and invasion, which were pivotal in Anakin Skywalker's early story. Naboo's significance continued as it influenced the rise and fall of key galactic events.");
        // 2020, 1810, 
        StarSystem nalHutta= new StarSystem("Nal Hutta", 4, 2020, 1810, imageName,"Nal Hutta, the Hutt homeworld, is a swampy and polluted planet dominated by the Hutt Cartel. Its significance in the galactic underworld cannot be overstated, as it serves as the center of Hutt power and criminal enterprise. Nal Hutta's influence extends through its control of smuggling routes and illicit activities. The planet's role in the galaxy is marked by its shadowy dealings and pervasive corruption.");
        // 1450, 1470, 
        StarSystem onderon = new StarSystem("Onderon", 2, 1450, 1470, imageName,"Onderon is a planet with a long history of rebellion, playing key roles during the Clone Wars and the Galactic Civil War. The planet's dense jungles and aggressive wildlife provided natural defenses. Onderon's resistance movements, led by figures like Saw Gerrera, have been influential in various conflicts. The planet's strategic importance and rebellious spirit continue to shape its legacy.");
        // 940, 1080, 
        StarSystem ordMantell = new StarSystem("Ord Mantell", 2, 940, 1080, imageName,"Ord Mantell, known for its rugged terrain and status as a haven for smugglers and bounty hunters, played a minor but notable role in galactic conflicts. The planet's strategic value comes from its position as a center for illegal activities and as a base of operations for those on the fringes of galactic society. Its role in the galaxy's underworld and its strategic location make it a noteworthy world in the broader galactic landscape.");
        // 1910, 2760, 
        StarSystem ryloth = new StarSystem("Ryloth", 3, 1910, 2760, imageName,"The Twi'lek homeworld, Ryloth, is strategically important due to its location in the Outer Rim and its natural resources. Ryloth faced numerous invasions and occupations, from Separatists during the Clone Wars to the Empire. The planet's inhabitants have a strong tradition of resistance, with notable leaders like Cham Syndulla. Ryloth's ongoing struggle for freedom reflects the broader galactic conflict.");
        // 1970, 1240, 
        StarSystem saleucami = new StarSystem("Saleucami", 2, 1970, 1240, imageName,"Saleucami, a harsh Outer Rim world, saw substantial action during the Clone Wars due to its strategic location. The planet's difficult terrain and its significance as a strategic outpost made it a focal point for both the Republic and Separatists. Saleucami's role in the Clone Wars underscores its importance as a key battleground in the galaxy's larger conflicts.");
        // 1150, 680, 
        StarSystem serenno = new StarSystem("Serenno", 3, 1150, 680, imageName,"Serenno is the homeworld of Count Dooku, significant for its role in the formation of the Separatist Alliance. The planet's noble heritage and wealth have influenced galactic politics and conflicts. Serenno's strategic location and resources make it a valuable asset for any faction. Its legacy is marked by its contribution to the rise of the Sith and the Clone Wars.");
        // 1180, 480, 
        StarSystem sernpidal = new StarSystem("Sernpidal", 1, 1180, 480, imageName,"Sernpidal, a planet devastated by a catastrophic impact event, is known for its ruined and barren landscape. While it did not play a major role in the major galactic conflicts, its environmental disaster and the loss of its population add to its significance as a symbol of the broader galaxy's struggles and the impacts of large-scale events.");
        // 1120, 2570, 
        StarSystem sullust = new StarSystem("Sullust", 3, 1120, 2570, imageName,"Sullust, a volcanic world with vast underground cities, has been a critical site for both the Galactic Empire and the Rebel Alliance. Its strategic location and industrial capacity have made it a key target in many conflicts. The planet's harsh environment is countered by its advanced technology and industry. Sullust's role in producing ships for the Rebel Alliance was crucial in their fight against the Empire. Its resources and location make it a valuable asset.");
        // 1280, 1070, 
        StarSystem taris = new StarSystem("Taris", 3, 1280, 1070, imageName,"Taris, a city-covered planet, has experienced both prosperity and ruin. Once a thriving ecumenopolis, it was devastated by the Sith during the Jedi Civil War. The planet's towering skyscrapers and lower levels tell a story of wealth and decay. Taris' history of conflict and recovery highlights its resilience. The planet's legacy is one of enduring through cycles of destruction and renewal.");
        // 2040, 2430, 
        StarSystem tatooine = new StarSystem("Tatooine", 1, 2040, 2430, imageName,"Tatooine, a desert world on the fringes of the galaxy, is best known as the home of Anakin and Luke Skywalker. Its twin suns and harsh environment have shaped its inhabitants into resilient survivors. Despite its remote location, Tatooine has been a focal point for significant events and characters in galactic history. The planet's role as a crossroads for unlikely heroes and pivotal moments is well established.");
        // 2480, 1280, 
        StarSystem tund = new StarSystem("Tund", 1, 2480, 1280, imageName,"Tund, an icy and remote planet, is not known for its role in major galactic conflicts. Its significance lies in its position as a distant and unexplored world, contributing to the broader galaxy's sense of mystery and diversity. Tund's role is more about its status as a remote outpost rather than its strategic or historical importance.");
        // 1000, 2200, 
        StarSystem yagDhul= new StarSystem("Yag'Dhul", 2, 1000, 2200, imageName,"Yag'Dhul is home to the Givin, known for its shipbuilding and strategic location. The planet's inhabitants are renowned for their mathematical prowess and structural engineering. Yag'Dhul's shipyards and strategic importance have made it a contested site in various conflicts. Its role in galactic industry and warfare continues to be significant.");
        // 1720, 830, 
        StarSystem yavin = new StarSystem("Yavin IV", 1, 1720, 830, imageName,"Yavin IV, a jungle moon, served as a critical Rebel Alliance base and the site of the first major Rebel victory against the Galactic Empire. The Battle of Yavin saw the destruction of the first Death Star, solidifying the Rebellion's presence in the galaxy. The moon's ancient temples provided a hidden refuge for the Rebel forces. Yavin IV's victory had far-reaching effects on the galactic struggle for freedom."); 
        
        // starSystems = new List<StarSystem>{alderaan, alsakan, bespin, bilbringi, bonadan, bothawui, corellia, coruscant, dantooine, denon, dromundKaas, endor, eriadu, felucia, geonosis, helska, honoghr, hoth, kamino, kashyyyk, korriban, kuat, lego, mandalore, monCala, mustafar, muunilinst, mygeeto, naboo, nalHutta, onderon, ordMantell, ryloth, saleucami, serenno, sernpidal, sullust, taris, tatooine, tund, yagDhul, yavin};
        systemDictionary = new Dictionary<string, StarSystem>() {{"alderaan", alderaan}, {"alsakan", alsakan}, {"bespin", bespin}, {"bilbringi", bilbringi}, {"bonadan", bonadan}, {"bothawui", bothawui}, {"corellia", corellia}, {"coruscant", coruscant}, {"dantooine", dantooine}, {"denon", denon}, {"dromundKaas", dromundKaas}, {"endor", endor}, {"eriadu", eriadu}, {"felucia", felucia}, {"geonosis", geonosis}, {"helska", helska}, {"honoghr", honoghr}, {"hoth", hoth}, {"kamino", kamino}, {"kashyyyk", kashyyyk}, {"korriban", korriban}, {"kuat", kuat}, {"lego", lego}, {"mandalore", mandalore}, {"monCala", monCala}, {"mustafar", mustafar}, {"muunilinst", muunilinst}, {"mygeeto", mygeeto}, {"naboo", naboo}, {"nalHutta", nalHutta}, {"onderon", onderon}, {"ordMantell", ordMantell}, {"ryloth", ryloth}, {"saleucami", saleucami}, {"serenno", serenno}, {"sernpidal", sernpidal}, {"sullust", sullust}, {"taris", taris}, {"tatooine", tatooine}, {"tund", tund}, {"yagDhul", yagDhul}, {"yavin", yavin}};

        // List<StarSystem> systems = new List<StarSystem>();
        // AddHyperLanes(alderaan, alsakan);
        // AddHyperLanes(alderaan, kuat);
        // AddHyperLanes(alsakan, coruscant);
        // AddHyperLanes(alsakan, corellia);
        // AddHyperLanes(bespin, endor);
        // AddHyperLanes(bespin, hoth);
        // AddHyperLanes(bespin, yagDhul);
        // AddHyperLanes(bilbringi, coruscant);
        // AddHyperLanes(bilbringi, ordMantell);
        // AddHyperLanes(bonadan, dromundKaas);
        // AddHyperLanes(bonadan, serenno);
        // AddHyperLanes(bothawui, denon);
        // AddHyperLanes(bothawui, kamino);
        // AddHyperLanes(bothawui, nalHutta);
        // AddHyperLanes(corellia, kuat);
        // AddHyperLanes(corellia, denon);
        // AddHyperLanes(corellia, yagDhul);
        // AddHyperLanes(dantooine, mygeeto);
        // AddHyperLanes(dantooine, sernpidal);
        // AddHyperLanes(denon, ryloth);
        // AddHyperLanes(denon, sullust);
        // AddHyperLanes(dromundKaas, korriban);
        // AddHyperLanes(endor, hoth);
        // AddHyperLanes(eriadu, mustafar);
        // AddHyperLanes(eriadu, naboo);
        // AddHyperLanes(eriadu, sullust);
        // AddHyperLanes(felucia, korriban);
        // AddHyperLanes(felucia, saleucami);
        // AddHyperLanes(felucia, yavin);
        // AddHyperLanes(geonosis, ryloth);
        // AddHyperLanes(geonosis, tatooine);
        // AddHyperLanes(helska, muunilinst);
        // AddHyperLanes(helska, sernpidal);
        // AddHyperLanes(honoghr, nalHutta);
        // AddHyperLanes(honoghr, saleucami);
        // AddHyperLanes(honoghr, tund);
        // AddHyperLanes(hoth, mustafar);
        // AddHyperLanes(kamino, tatooine);
        // AddHyperLanes(kashyyyk, nalHutta);
        // AddHyperLanes(kashyyyk, onderon);
        // AddHyperLanes(kashyyyk, saleucami);
        // AddHyperLanes(kuat, onderon);
        // AddHyperLanes(lego, monCala);
        // AddHyperLanes(lego, saleucami);
        // AddHyperLanes(mandalore, serenno);
        // AddHyperLanes(mandalore, taris);
        // AddHyperLanes(mandalore, yavin);
        // AddHyperLanes(monCala, tund);
        // AddHyperLanes(muunilinst, mygeeto);
        // AddHyperLanes(mygeeto, ordMantell);
        // AddHyperLanes(naboo, ryloth);
        // AddHyperLanes(onderon, taris);
        // AddHyperLanes(ordMantell, taris);
        // AddHyperLanes(serenno, sernpidal);
        // AddHyperLanes(serenno, yavin);
        // AddHyperLanes(sullust, yagDhul);
    }

    // private void AddHyperLanes(StarSystem system1, StarSystem system2)
    // {
    //     hyperlanes.Add(new List<StarSystem>{system1, system2});
    //     system1.AddHyperLane(system2);
    //     system2.AddHyperLane(system1);
    // }

    public List<StarSystem> GetStarSystems()
    {
        return starSystems;
    }

    public static Dictionary<string, StarSystem> GetSystemDictionary()
    {
        return systemDictionary;
    }

    // public List<List<StarSystem>> GetHyperLanes()
    // {
    //     return hyperlanes;
    // }
}