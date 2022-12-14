using Kitchen;
using Kitchen.Modules;
using KitchenData;
using KitchenLib;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Unity.Entities.UniversalDelegates;
using UnityEngine;

namespace CYOC2
{
    public class CardSelectMenu : CardListMenu
    {
        public int CurrentIndex;

        public static UnlockCardCollection Collection;

        public CardScrollerElement CardScroller;

        public static readonly Color DisabledColor = new Color(0.4f, 0.4f, 0.4f);

        public List<int> IndexHeaders;

        public CardSelectMenu(Transform container, ModuleList module_list) : base(container, module_list) { }

        public void Initialise()
        {
            Collection = new UnlockCardCollection(GameData.Main.Get<Unlock>().ToList());
        }

        public override void Setup(int player_id)
        {
            CardScroller = ModuleDirectory.Add<CardScrollerElement>(this.Container, new Vector2(0f, 0f));

            CardScroller.SetCardList(Collection.GetUnlocks().ToList<ICard>());

            Collection.SetColors(CardScroller);

            for (int i = 0; i < Collection.Count; i++)
            {
                ToggleColor(CardScroller.CardBank[i], i);
            }

            ToggleColor(CardScroller.Card, 0);

            this.ModuleList.AddModule(CardScroller, CardScroller.transform.localPosition.ToFlat());
        }

        public void ToggleCard(UnlockCardElement card, int index)
        {
            Debug.Log("ToggleCard");

            PreferenceUtils.Get<KitchenLib.BoolPreference>("toyemaker.plateup.cyoc2", Collection[index].Unlock.ID.ToString()).Value = !PreferenceUtils.Get<KitchenLib.BoolPreference>("toyemaker.plateup.cyoc2", Collection[index].Unlock.ID.ToString()).Value;
            ToggleColor(card, index);
            ToggleColor(CardScroller.CardBank[index], index);
        }

        public void ToggleColor(UnlockCardElement card, int index)
        {
            card.Card.material.SetColor(Shader.PropertyToID("_Title") , PreferenceUtils.Get<KitchenLib.BoolPreference>("toyemaker.plateup.cyoc2", Collection[index].Unlock.ID.ToString()).Value ? Collection[index].DefaultColor : DisabledColor);
        }

        public UnlockOptions GetRandomUnlocks(int day)
        {
            List<Unlock> cards;

            if (day == 5)
            {
                cards = Collection.GetEnabledUnlocks().Where(x => x.CardType == CardType.ThemeUnlock).ToList();
            }
            else if (day == 14)
            {
                cards = Collection.GetEnabledUnlocks().Where(x => x.CardType == CardType.FranchiseTier).ToList();
            }
            else
            {
                cards = Collection.GetEnabledUnlocks().Where(x => x.CardType != CardType.FranchiseTier && x.CardType != CardType.ThemeUnlock).ToList();
            }

            Debug.Log(GameInfo.CurrentDay);

            Debug.Log(cards.Count);

            UnlockOptions options = new UnlockOptions();

            int indexA = UnityEngine.Random.Range(0, cards.Count);

            Debug.Log("index A");

            options.Unlock1 = cards[indexA];
            cards.RemoveAt(indexA);

            Debug.Log("index B");

            int indexB = UnityEngine.Random.Range(0, cards.Count);
            options.Unlock2 = cards[indexB];

            Debug.Log(indexA + ", " + indexB);

            return options;
        }
    }
}

