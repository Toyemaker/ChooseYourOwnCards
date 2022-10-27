using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Kitchen;
using KitchenData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChooseYourOwnCards.FindNewUnlocksPatch;

namespace ChooseYourOwnCards
{
    [HarmonyPatch(typeof(GameCreator))]
    public static class ConfigHelper
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void Start_PostfixPatch()
        {
            UnlockList = new List<UnlockData>();

            foreach (Unlock unlock in GameData.Main.Get<Unlock>())
            {
                ConfigEntry<bool> config = ChooseYourOwnCardsMod.Configuration.Bind(unlock.CardType.ToString(), unlock.Name, true);

                UnlockData data = new UnlockData(unlock, config);

                UnlockList.Add(data);
            }
        }

    }
}
