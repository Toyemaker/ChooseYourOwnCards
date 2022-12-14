using HarmonyLib;
using Kitchen;
using KitchenData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;

namespace CYOC2
{
    [HarmonyPatch(typeof(FindNewUnlocks), "AddOption")]
    public static class FindNewUnlocksPatch
    {
        public static bool IsFirst = true;
        public static UnlockOptions Options;

        [HarmonyPrefix]
        public static bool Prefix(FindNewUnlocks __instance)
        {
            if (IsFirst)
            {
                Options = Main.Menu.GetRandomUnlocks(GameInfo.CurrentDay);

                Entity entity = __instance.EntityManager.CreateEntity(new ComponentType[]
                {
                    typeof(CProgressionOption)
                });
                __instance.EntityManager.SetComponentData(entity, new CProgressionOption
                {
                    ID = Options.Unlock1.ID,
                });

                IsFirst = false;
            }
            else
            {
                Entity entity = __instance.EntityManager.CreateEntity(new ComponentType[]
                {
                    typeof(CProgressionOption)
                });
                __instance.EntityManager.SetComponentData(entity, new CProgressionOption
                {
                    ID = Options.Unlock2.ID,
                });

                IsFirst = true;
            }

            return false;
        }
    }
}
