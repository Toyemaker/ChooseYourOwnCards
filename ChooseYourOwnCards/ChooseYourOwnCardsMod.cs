using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnCards
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class ChooseYourOwnCardsMod : BaseUnityPlugin
    {
        public static ManualLogSource DebugLogger;
        public static ConfigFile Configuration;


        public const string pluginGuid = "toyemaker.plateup.chooseyourowncards";
        public const string pluginName = "Choose Your Own Cards";
        public const string pluginVersion = "1.1";

        public void Awake()
        {
            DebugLogger = Logger;

            Configuration = Config;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), pluginGuid);
        }

        public void Update()
        {
            
        }
    }
}
