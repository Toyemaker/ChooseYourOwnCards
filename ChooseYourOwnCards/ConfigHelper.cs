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
        public static ConfigEntry<bool> DisableAllCards;
        public static ConfigEntry<bool> EnableAllCards;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void Start_PostfixPatch()
        {
            DisableAllCards = ChooseYourOwnCardsMod.Configuration.Bind("1. Toggles", "Disable All Cards", false);
            EnableAllCards = ChooseYourOwnCardsMod.Configuration.Bind("1. Toggles", "Enable All Cards", true);

            DisableAllCards.SettingChanged += DisableAll;
            EnableAllCards.SettingChanged += EnableAll;

            UnlockList = new List<UnlockData>();

            foreach (Unlock unlock in GameData.Main.Get<Unlock>())
            {
                if (unlock.UnlockGroup == UnlockGroup.Dish)
                {
                    ChooseYourOwnCardsMod.DebugLogger.LogInfo(unlock.Name + " | " + unlock.ID);
                }

                ConfigEntry<bool> config = ChooseYourOwnCardsMod.Configuration.Bind(unlock.CardType.ToString(), unlock.Name, true);

                config.SettingChanged += OnSettingChange;

                UnlockData data = new UnlockData(unlock, config);

                UnlockList.Add(data);
            }
        }

        public static void OnSettingChange(object sender, EventArgs e)
        {
            DisableAllCards.Value = false;
            EnableAllCards.Value = false;
        }

        public static void EnableAll(object sender, EventArgs e)
        {
            foreach (UnlockData data in UnlockList)
            {
                data.Config.Value = true;
            }
        }

        public static void DisableAll(object sender, EventArgs e)
        {
            foreach (UnlockData data in UnlockList)
            {
                data.Config.Value = false;
            }
        }
    }
}
