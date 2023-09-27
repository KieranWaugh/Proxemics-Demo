using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunKiosk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!Preferences.calibrated && Preferences.interactionType != InteractionType.Debug)
        {
            SceneManager.LoadScene("Calibration");
        }

        Preferences.pointsOfInterest = new List<PointOfInterest>
        {
            new PointOfInterest { Type =  "Attraction", Name = " Kelvingrove Art Gallery and Museum", Address = " Argyle St", Description = " A renowned museum featuring European artwork and interactive displays." },
            new PointOfInterest { Type =  "Attraction", Name = " Glasgow Cathedral", Address = " Castle St", Description = " A historic and stunning medieval cathedral." },
            new PointOfInterest { Type =  "Attraction", Name = " Riverside Museum", Address = " 100 Pointhouse Rd", Description = " A modern museum displaying various modes of transport." },
            new PointOfInterest { Type =  "Attraction", Name = " The Tall Ship at Riverside", Address = " 150 Pointhouse Pl", Description = " A historic ship that offers a glimpse into maritime history." },
            new PointOfInterest { Type =  "Attraction", Name = " Glasgow Botanic Gardens", Address = " 730 Great Western Rd", Description = " Beautiful gardens with a variety of plants and greenhouses." },
            new PointOfInterest { Type =  "Restaurant", Name = " Mother India", Address = " 28 Westminster Terrace", Description = " Popular for its Indian cuisine." },
            new PointOfInterest { Type =  "Restaurant", Name = " Ubiquitous Chip", Address = " 12 Ashton Ln", Description = " A Scottish restaurant set in a unique atmosphere." },
            new PointOfInterest { Type =  "Restaurant", Name = " Paesano Pizza", Address = " 94 Miller St", Description = " Known for their authentic Neapolitan pizza." },
            new PointOfInterest { Type =  "Restaurant", Name = " Mono", Address = " 12 Kings Court", Description = " Vegan restaurant and bar with live music." },
            new PointOfInterest { Type =  "Attraction", Name = " George Square", Address = " George St", Description = " A prominent square in Glasgow with historical statues and structures." },
            new PointOfInterest { Type =  "Restaurant", Name = " Two Fat Ladies at The Buttery", Address = " 652-654 Argyle St", Description = " Offers a variety of seafood dishes." },
            new PointOfInterest { Type =  "Attraction", Name = " Buchanan Street", Address = " Buchanan St", Description = " A famous shopping district in Glasgow." },
            new PointOfInterest { Type =  "Attraction", Name = " Glasgow Science Centre", Address = " 50 Pacific Quay", Description = " Interactive science exhibits and a planetarium." },
            new PointOfInterest { Type =  "Restaurant", Name = " The Gannet", Address = " 1155 Argyle St", Description = " Modern Scottish cuisine with a twist." },
            new PointOfInterest { Type =  "Restaurant", Name = " Ox and Finch", Address = " 920 Sauchiehall St", Description = " Contemporary  tapas-style dishes." },
            new PointOfInterest { Type =  "Attraction", Name = " Pollok Country Park", Address = " 2060 Pollokshaws Rd", Description = " Expansive park with woodland walks and the Burrell Collection museum." },
            new PointOfInterest { Type =  "Restaurant", Name = " Drygate Brewing Co.", Address = " 85 Drygate", Description = " A brewery and bar with unique beer and food menus." },
            new PointOfInterest { Type =  "Restaurant", Name = " Rishi's Indian Aroma", Address = " 61 Bath St", Description = " Delicious Indian dishes in a modern setting." },
            new PointOfInterest { Type =  "Attraction", Name = " Gallery of Modern Art", Address = " Royal Exchange Square", Description = " Features modern and contemporary art collections." },
            new PointOfInterest { Type =  "Restaurant", Name = " Cafe Gandolfi", Address = " 64 Albion St", Description = " A Glasgow classic serving Scottish dishes." },
            new PointOfInterest { Type =  "Attraction", Name = " The Lighthouse", Address = " 11 Mitchell Ln", Description = " Scotland's Centre for Design and Architecture." },
            new PointOfInterest { Type =  "Restaurant", Name = " Stravaigin", Address = " 28 Gibson St", Description = " Offers international dishes using Scottish produce." },
            new PointOfInterest { Type =  "Attraction", Name = " House for an Art Lover", Address = " Bellahouston Park", Description = " A unique building inspired by designs by Charles Rennie Mackintosh." },
            new PointOfInterest { Type =  "Restaurant", Name = " Cail Bruich", Address = " 725 Great Western Rd", Description = " Fine dining with a focus on Scottish ingredients." },
            new PointOfInterest { Type =  "Attraction", Name = " Glasgow Green", Address = " Greendyke St", Description = " The oldest park in Glasgow  featuring the People's Palace museum." },
            new PointOfInterest { Type =  "Restaurant", Name = " The Hanoi Bike Shop", Address = " 8 Ruthven Ln", Description = " Authentic Vietnamese cuisine." },
            new PointOfInterest { Type =  "Attraction", Name = " The Hunterian Museum", Address = " University Ave", Description = " Museum with various exhibits including Roman artefacts." },
            new PointOfInterest { Type =  "Restaurant", Name = " Alchemilla", Address = " 1126 Argyle St", Description = " Offers modern Mediterranean dishes." },
            new PointOfInterest { Type =  "Attraction", Name = " Scotland Street School Museum", Address = " 225 Scotland St", Description = " Designed by Charles Rennie Mackintosh  offers insight into education in the past." },
            new PointOfInterest { Type =  "Restaurant", Name = " Babu Bombay Street Kitchen", Address = " 186 W Regent St", Description = " Street food-style Indian dishes." },
            new PointOfInterest { Type =  "Attraction", Name = " Tenement House", Address = " 145 Buccleuch St", Description = " A look into the life of the early 20th-century Glaswegians." },
            new PointOfInterest { Type =  "Restaurant", Name = " Julie's Kopitiam", Address = " 1109A Pollokshaws Rd", Description = " Malaysian street food-inspired dishes." },
            new PointOfInterest { Type =  "Attraction", Name = " Provand's Lordship", Address = " 3 Castle St", Description = " The oldest house in Glasgow  showcasing medieval life." },
            new PointOfInterest { Type =  "Restaurant", Name = " Crabshakk", Address = " 1114 Argyle St", Description = " Seafood specialist with a compact setting." },
            new PointOfInterest { Type =  "Attraction", Name = " The Mackintosh House", Address = " 82 Hillhead St", Description = " Reconstructed interiors from Charles Rennie Mackintosh's home." },
            new PointOfInterest { Type =  "Restaurant", Name = " Bread Meats Bread", Address = " 104 St Vincent St", Description = " Known for their burgers and comfort food." },
            new PointOfInterest { Type =  "Attraction", Name = " Glasgow Necropolis", Address = " Castle St", Description = " A vast cemetery with Victorian mausoleums and views over the city." },
            new PointOfInterest { Type =  "Restaurant", Name = " The Butterfly and the Pig", Address = " 153 Bath St", Description = " Whimsical decor and Scottish fare." },
            new PointOfInterest { Type =  "Attraction", Name = " Kibble Palace", Address = " 730 Great Western Rd", Description = " A large glasshouse in the Glasgow Botanic Gardens." },
            new PointOfInterest { Type =  "Restaurant", Name = " Singl-end", Address = " 15 John St", Description = " A bakery and cafe known for its brunch offerings." },
            new PointOfInterest { Type =  "Attraction", Name = " Glasgow Police Museum", Address = " 30 Bell St", Description = " Chronicles the history of Britain's first police force." },
            new PointOfInterest { Type =  "Restaurant", Name = " Shilling Brewing Co.", Address = " 92 W George St", Description = " A unique combination of brewery and wood-fired pizzeria." },
            new PointOfInterest { Type =  "Attraction", Name = " The Willow Tea Rooms", Address = " 217 Sauchiehall St", Description = " Iconic tearooms designed by Charles Rennie Mackintosh." },
            new PointOfInterest { Type =  "Restaurant", Name = " Bloc+", Address = " 117 Bath St", Description = " A bar and venue with a varied food menu." },
            new PointOfInterest { Type =  "Attraction", Name = " Martyrs' School", Address = " 17 Parson St", Description = " Another of Mackintosh's designs  an architectural wonder." },
            new PointOfInterest { Type =  "Restaurant", Name = " King Tut's Wah Wah Hut", Address = " 272A St Vincent St", Description = " Iconic venue for live music and great food." }
        };

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Preferences.proxemic = true;
            print("proxemics enabled");
        }

        if (Input.GetKeyDown("d"))
        {
            Preferences.interactionType = InteractionType.Debug;
        }
    }
}
