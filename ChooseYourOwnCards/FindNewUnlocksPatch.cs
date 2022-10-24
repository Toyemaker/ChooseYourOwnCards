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
        [HarmonyPatch("GetUnlocks")]
        [HarmonyPostfix]
        public static void GetUnlocks_PostfixPatch(ref List<Unlock> __result)
        {
            foreach (KeyValuePair<string, ConfigEntry<bool>> card in ConfigHelper.UnlockCardBlacklistDictionary)
            {
                if (card.Value.Value)
                {
                    continue;
                }

                if (ConfigHelper.MainsUnlockCards.ContainsKey(card.Key))
                {
                    __result.RemoveAll(a => a.ID == ConfigHelper.MainsUnlockCards[card.Key]);
                }
                else if (ConfigHelper.AdditionalMainsUnlockCards.ContainsKey(card.Key))
                {
                    __result.RemoveAll(a => a.ID == ConfigHelper.AdditionalMainsUnlockCards[card.Key]);
                }
                else if (ConfigHelper.ExtrasUnlockCards.ContainsKey(card.Key))
                {
                    __result.RemoveAll(a => a.ID == ConfigHelper.ExtrasUnlockCards[card.Key]);
                }
                else if (ConfigHelper.SidesUnlockCards.ContainsKey(card.Key))
                {
                    __result.RemoveAll(a => a.ID == ConfigHelper.SidesUnlockCards[card.Key]);
                }
                else if (ConfigHelper.StartersUnlockCards.ContainsKey(card.Key))
                {
                    __result.RemoveAll(a => a.ID == ConfigHelper.StartersUnlockCards[card.Key]);
                }
                else if (ConfigHelper.DessertsUnlockCards.ContainsKey(card.Key))
                {
                    __result.RemoveAll(a => a.ID == ConfigHelper.DessertsUnlockCards[card.Key]);
                }
                else if (ConfigHelper.ThemeUnlockCards.ContainsKey(card.Key))
                {
                    __result.RemoveAll(a => a.ID == ConfigHelper.ThemeUnlockCards[card.Key]);
                }
                else if (ConfigHelper.CustomerUnlockCards.ContainsKey(card.Key))
                {
                    __result.RemoveAll(a => a.ID == ConfigHelper.CustomerUnlockCards[card.Key]);
                }
                else if (ConfigHelper.FranchiseUnlockCards.ContainsKey(card.Key))
                {
                    __result.RemoveAll(a => a.ID == ConfigHelper.FranchiseUnlockCards[card.Key]);
                }
                else if (ConfigHelper.LegacyUnlockCards.ContainsKey(card.Key))
                {
                    __result.RemoveAll(a => a.ID == ConfigHelper.LegacyUnlockCards[card.Key]);
                }
                else if (ConfigHelper.UnknownUnlockCards.ContainsKey(card.Key))
                {
                    __result.RemoveAll(a => a.ID == ConfigHelper.UnknownUnlockCards[card.Key]);
                }
                else
                {
                    ChooseYourOwnCardsMod.DebugLogger.LogError("Unable to blacklist card. How did we get here?");
                }
            }
        }

        [HarmonyPatch("AddUnlock")]
        [HarmonyPostfix]
        public static void AddUnlock_PostfixPatch(HashSet<int> ___CurrentUnlockIDs)
        {
            ChooseYourOwnCardsMod.DebugLogger.LogInfo("Begin Logging...");
            foreach (int id in ___CurrentUnlockIDs)
            {
                ChooseYourOwnCardsMod.DebugLogger.LogInfo(id);
            }
        }
    }
}
