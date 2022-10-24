using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnCards
{
    public static class ConfigHelper
    {
        public static Dictionary<string, int> MainsUnlockCards;
        public static Dictionary<string, int> AdditionalMainsUnlockCards;
        public static Dictionary<string, int> ExtrasUnlockCards;
        public static Dictionary<string, int> SidesUnlockCards;
        public static Dictionary<string, int> StartersUnlockCards;
        public static Dictionary<string, int> DessertsUnlockCards;
        public static Dictionary<string, int> ThemeUnlockCards;
        public static Dictionary<string, int> CustomerUnlockCards;
        public static Dictionary<string, int> FranchiseUnlockCards;
        public static Dictionary<string, int> LegacyUnlockCards;
        public static Dictionary<string, int> UnknownUnlockCards;

        public static Dictionary<string, ConfigEntry<bool>> UnlockCardBlacklistDictionary;

        public static void Initialize(ConfigFile config)
        {
            MainsUnlockCards = new Dictionary<string, int>()
            {
                { "Breakfast", -2075899 },
                { "Burgers", -1778969928 },
                { "Fish", 1743900205 },
                { "Hot Dogs", 1626323920 },
                { "Nut Roast", 536093200 },
                { "Pies", -133939790 },
                { "Pizza", 550743424 },
                { "Salad", 1356267749 },
                { "Steak", -959076098 },
                { "Stir Fry", -1653221873 },
                { "Turkey", 1551533879 },
            };
            AdditionalMainsUnlockCards = new Dictionary<string, int>()
            {
                { "Apple Salad", 1570910782 },
                { "Crab Cake", -297968808 },
                { "Fish Fillet", 1442262270 },
                { "Fresh Patties", -1091625127 },
                { "Mushroom Pie", -1992316049 },
                { "Oysters", 274986412 },
                { "Potato Salad", -862637543 },
                { "Thick Cut Steaks", 1916300984 },
                { "Thin Cut Steaks", -1716993344 },
                { "Vegetable Pies", -1802123036 },
            };
            ExtrasUnlockCards = new Dictionary<string, int>()
            {
                { "Breakfast Beans", -1199743580 },
                { "Breakfast Eggs", 1436814208 },
                { "Breakfast Extras", -1998930853 },
                { "Burger Toppings", 1298035216 },
                { "Cheeseburgers", 965292477 },
                { "Fish Selection", 243846255 },
                { "Fish Selection2", -243820179 },
                { "Hot Dog - Mustard", -278713285 },
                { "Mushroom Pizza", 1434421325 },
                { "Onion Pizza", -2071275506 },
                { "Salad Toppings", 372460604 },
                { "Steak Sauce - Mushroom", -953651922 },
                { "Steak Sauce - Red Wine Jus", 2074054556 },
                { "Steak Stir Fry", -204178430 },
                { "Steak Topping - Mushroom", -1192928429 },
                { "Steak Topping - Tomato", -851525606 },
            };
            StartersUnlockCards = new Dictionary<string, int>()
            {
                { "Carrot Soup", 2012685115 },
                { "Meat Soup", -997241706 },
                { "Tomato Soup", -233806503 },
            };
            SidesUnlockCards = new Dictionary<string, int>()
            {
                { "Broccoli", 1380953991 },
                { "Chips", -520693398 },
                { "Mashed Potato", 364243605 },
                { "Onion Rings", -1745179096 },
            };
            DessertsUnlockCards = new Dictionary<string, int>()
            {
                { "Apple Pies", -211821608 },
                { "Black Coffee", -85470894 },
                { "Cheese Board", 312770813 },
                { "Ice Cream", 373996608 },
            };
            CustomerUnlockCards = new Dictionary<string, int>()
            {
                { "Advertising1", 73387665 },
                { "Advertising2", 1765310572 },
                { "All You Can Eat", -347199069 },
                { "Blindfolded Chefs", -1617744928 },
                { "Closing Time?", -1815978981 },
                { "Dinner Rush", -37551439 },
                { "Discounts", 113582858 },
                { "Double Helpings", 2055765569 },
                { "Empathy", -28708234 },
                { "Flexible Dining", -2112255403 },
                { "High Expectations", -534291083 },
                { "High Quality", 1103452725 },
                { "High Standards", -957080051 },
                { "Individual Dining", -1747821833 },
                { "Instant Service", 1530184692 },
                { "Large Groups", -523195599 },
                { "Leisurely Eating", -287956430 },
                { "Lunch Rush", -53330922 },
                { "Medium Groups", -1183014556 },
                { "Morning Rush", 2079763934 },
                { "Personalised Waiting", 233335391 },
                { "Photographic Memory", 165138001 },
                { "Relaxed Atmosphere", 1151685289 },
                { "Sedate Atmosphere", 220354841 },
                { "Simplicity", 1914014233 },                
                { "Splash Zone", -491994319 },
                { "Victorian Standards", -913531466 },
            };
            ThemeUnlockCards = new Dictionary<string, int>()
            {
                { "Affordable", -1857686620 },
                { "Charming", 1293847744 },
                { "Exclusive", -1323758054 },
                { "Formal", -1641333859 },
            };
            FranchiseUnlockCards = new Dictionary<string, int>()
            {
                { "Bootstrapping", 1618418478 },
                { "Careful Accounting", -1205203705 },
                { "Catalogue", 868780472 },   
                { "Coffee Tables", -1121427945 },
                { "Conveyors", 1818403570 },
                { "Coupons", -1418317596 },
                { "Double Homework", -357483693 },
                { "Floor Protectors", 1101419251 },
                { "Flower Pots", -220105135 },
                { "Grabber", 1298492736 },
                { "High Tech Suppliers", -1269806478 },
                { "Loyal Customer", -1010143518 },
                { "Mandatory Tips", -947047181 },
                { "Metal Table", -178381693 },
                { "Preparation Time", -401283600 },
                { "Reincarnation", 2022427578 },
                { "Savings", -1096314451 },
                { "Second Helpings", 1543829883 },
                { "Simple Cloth Table", -373772933 },
                { "Supplier Error", -98765415 },
                { "Variety1", 409052852 },
                { "Variety2", -1690048134 },
                { "Variety3", 2026578658 },
                { "Variety4", -437866401 },
                { "Variety5", -1122993754 },
                { "Variety6", -1189327033 },
                { "Variety7", 1366303950 },
                { "Variety8", -771711089 },
                { "Variety9", -1586319402 },
                { "Wash Basin", 1173444265 },
            };
            LegacyUnlockCards = new Dictionary<string, int>()
            {
                { "Discount", 1197914155 },
                { "Expansion", 337471011 },
                { "Expectation1", 965426081 },
                { "Expectation2", 1689349004 },
                { "Focus", 686050224 },
                { "Quality", -760406109 },
                { "Renown1", 779560009 },
                { "Renown2", 840658034 },
                { "Renown3", -1893812821 },
                { "SimplicityL", -1641150757 },
            };

            UnknownUnlockCards = new Dictionary<string, int>()
            {
                { "Unknown1", -1528287489 },
                { "Unknown2", 670300431 },
            };
            
            UnlockCardBlacklistDictionary = new Dictionary<string, ConfigEntry<bool>>();

            foreach (KeyValuePair<string, int> card in MainsUnlockCards)
            {
                UnlockCardBlacklistDictionary.Add(card.Key, config.Bind("Mains", card.Key, true));
            }
            foreach (KeyValuePair<string, int> card in AdditionalMainsUnlockCards)
            {
                UnlockCardBlacklistDictionary.Add(card.Key, config.Bind("Additional Mains", card.Key, true));
            }
            foreach (KeyValuePair<string, int> card in ExtrasUnlockCards)
            {
                UnlockCardBlacklistDictionary.Add(card.Key, config.Bind("Extras", card.Key, true));
            }
            foreach (KeyValuePair<string, int> card in StartersUnlockCards)
            {
                UnlockCardBlacklistDictionary.Add(card.Key, config.Bind("Starters", card.Key, true));
            }
            foreach (KeyValuePair<string, int> card in SidesUnlockCards)
            {
                UnlockCardBlacklistDictionary.Add(card.Key, config.Bind("Sides", card.Key, true));
            }
            foreach (KeyValuePair<string, int> card in DessertsUnlockCards)
            {
                UnlockCardBlacklistDictionary.Add(card.Key, config.Bind("Desserts", card.Key, true));
            }
            foreach (KeyValuePair<string, int> card in CustomerUnlockCards)
            {
                UnlockCardBlacklistDictionary.Add(card.Key, config.Bind("Customers", card.Key, true));
            }
            foreach (KeyValuePair<string, int> card in ThemeUnlockCards)
            {
                UnlockCardBlacklistDictionary.Add(card.Key, config.Bind("Themes", card.Key, true));
            }
            foreach (KeyValuePair<string, int> card in FranchiseUnlockCards)
            {
                UnlockCardBlacklistDictionary.Add(card.Key, config.Bind("Franchise", card.Key, true));
            }
            foreach (KeyValuePair<string, int> card in LegacyUnlockCards)
            {
                UnlockCardBlacklistDictionary.Add(card.Key, config.Bind("Legacy", card.Key, true, "This is a legacy unlock card, blacklisting this likely does nothing."));
            }
            foreach (KeyValuePair<string, int> card in UnknownUnlockCards)
            {
                UnlockCardBlacklistDictionary.Add(card.Key, config.Bind("Unknown", card.Key, true, "This is an unlabeled unlock card, blacklisting this is probably a bad idea."));
            }
        }
    }
}
