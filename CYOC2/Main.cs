using Kitchen;
using KitchenData;
using KitchenLib;
using KitchenLib.Event;
using KitchenMods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CYOC2
{
    public class Main : BaseMod
    {
        public static CardSelectMenu Menu;

        public static bool IsActivated;

        public Main() : base("toyemaker.plateup.cyoc2", "Choose Your Own Cards", "Toyemaker", "2.0.0", ">=1.1.0 <=1.5.0", Assembly.GetExecutingAssembly()) { }
        protected override void Initialise()
        {
            IsActivated = false;

            SetupMenus();

            Debug.Log("[Choose Your Own Cards]: v2.0 loaded.");

            base.Initialise();
        }

        protected override void OnUpdate()
        {

        }

        private void SetupMenus()
        {
            //Setting Up For Pause Menu
            Events.MainMenu_SetupEvent += (s, args) =>
            {
                args.addSubmenuButton.Invoke(args.instance, new object[] { "CYOC", typeof(CardSelectMenu), false });
            };
            Events.PlayerPauseView_SetupMenusEvent += (s, args) =>
            {
                Menu = new CardSelectMenu(args.instance.ButtonContainer, args.module_list);

                if (!IsActivated)
                {
                    Menu.Initialise();
                    IsActivated = true;
                }

                args.addMenu.Invoke(args.instance, new object[] { typeof(CardSelectMenu), Menu });
            };
        }
    }
}
