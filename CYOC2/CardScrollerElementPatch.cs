using Controllers;
using HarmonyLib;
using Kitchen;
using Kitchen.Modules;
using KitchenData;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CYOC2
{
    [HarmonyPatch(typeof(CardScrollerElement), "HandleInteraction")]
    public static class CardScrollerElementPatch
    {
        [HarmonyPrefix]
        public static void Prefix(InputState state, CardScrollerElement __instance, UnlockCardElement ___Card, int ___Index)
        {
            if (Main.Menu.CardScroller == __instance)
            {
                if (state.MenuLeft == ButtonState.Pressed)
                {
                    Main.Menu.ToggleCard(___Card, ___Index);

                    PreferenceUtils.Save("UserData/CYOC2/preferences.dat");
                }
                if (state.MenuRight == ButtonState.Pressed)
                {
                    MethodInfo setIndex = __instance.GetType().GetMethod("SetIndex", BindingFlags.NonPublic | BindingFlags.Instance);

                    if (CardSelectMenu.Collection[___Index].Header < CardSelectMenu.Collection[CardSelectMenu.Collection.Count - 1].Header)
                    {
                        setIndex.Invoke(__instance, new object[] { CardSelectMenu.Collection.Headers[CardSelectMenu.Collection[___Index].Header + 1] });
                    }
                    else
                    {
                        setIndex.Invoke(__instance, new object[] { 0 });
                    }
                }
                if (state.IsCancellingMenu)
                {
                    Debug.Log("Saving CYOC2 preferences...");

                    PreferenceUtils.Save("UserData/CYOC2/preferences.dat");
                }
            }
        }

        [HarmonyPostfix]
        public static void Postfix(InputState state, CardScrollerElement __instance, UnlockCardElement ___Card, int ___Index)
        {
            if (Main.Menu.CardScroller == __instance)
            {
                if (state.MenuDown == ButtonState.Pressed || state.MenuUp == ButtonState.Pressed)
                {
                    if (Main.Menu.CurrentIndex != ___Index)
                    {
                        Main.Menu.CurrentIndex = ___Index;
                    }

                    Main.Menu.ToggleColor(___Card, ___Index);
                }

                if (state.MenuRight == ButtonState.Pressed)
                {
                    Main.Menu.ToggleColor(___Card, ___Index);
                }
            }
        }
    }
}
