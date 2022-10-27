using BepInEx.Configuration;
using HarmonyLib;
using Kitchen;
using KitchenData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnCards
{
    [HarmonyPatch(typeof(FindNewUnlocks))]
    public static class FindNewUnlocksPatch
    {
        public class UnlockData
        {
            public ConfigEntry<bool> Config;
            public Unlock Unlock;

            public UnlockData(Unlock unlock, ConfigEntry<bool> config)
            {
                Unlock = unlock;
                Config = config;
            }
        }

        public static List<UnlockData> UnlockList;

        [HarmonyPatch("Initialise")]
        [HarmonyPostfix]
        public static void Initialise_PostfixPatch()
        {
            UnlockList = new List<UnlockData>();

            foreach (Unlock unlock in GameData.Main.Get<Unlock>())
            {
                ConfigEntry<bool> config = ChooseYourOwnCardsMod.Configuration.Bind(unlock.CardType.ToString(), unlock.Name, true);

                UnlockData data = new UnlockData(unlock, config);

                UnlockList.Add(data);
            }
        }

        [HarmonyPatch("FindAllUnlocks")]
        [HarmonyPostfix]
        public static void FindAllUnlocks_PostfixPatch(List<Unlock> __result)
        {
            foreach (UnlockData data in UnlockList)
            {
                if (!data.Config.Value)
                {
                    __result.Remove(data.Unlock);
                }
            }
        }
    }
}
