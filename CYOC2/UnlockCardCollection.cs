using Kitchen;
using Kitchen.Modules;
using KitchenData;
using KitchenLib;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CYOC2
{
    public class UnlockCardCollection
    {
        private UnlockCardData[] _unlockCardDict;

        public List<int> Headers;

        public int Count
        {
            get
            {
                return _unlockCardDict.Length;
            }
        }

        public UnlockCardData this[int key]
        {
            get
            {
                return _unlockCardDict[key];
            }
        } 

        public UnlockCardCollection(List<Unlock> unlocks)
        {
            _unlockCardDict = new UnlockCardData[unlocks.Count];
            Headers = new List<int>();

            int header = 0;
            int totalCount = 0;

            foreach (CardType type in (CardType[])Enum.GetValues(typeof(CardType)))
            {
                List<Unlock> temp = unlocks.Where(x => x.CardType == type).ToList();

                Headers.Add(totalCount);

                for (int i = 0; i < temp.Count; i++)
                {
                    _unlockCardDict[totalCount] = new UnlockCardData()
                    {
                        Unlock = temp[i],
                        Header = header,
                        Preference = PreferenceUtils.Register<KitchenLib.BoolPreference>("toyemaker.plateup.cyoc2", temp[i].ID.ToString(), temp[i].Name + temp[i].ID),
                    };

                    PreferenceUtils.Get<KitchenLib.BoolPreference>("toyemaker.plateup.cyoc2", _unlockCardDict[totalCount].Unlock.ID.ToString()).Value = true;

                    totalCount++;
                }

                header++;
            }

            PreferenceUtils.Load("UserData/CYOC2/preferences.dat");
        }

        public List<Unlock> GetUnlocks()
        {
            List<Unlock> unlocks = new List<Unlock>();

            for (int i = 0; i < _unlockCardDict.Length; i++)
            {
                unlocks.Add(_unlockCardDict[i].Unlock);
            }

            return unlocks;
        }

        public List<Unlock> GetEnabledUnlocks()
        {
            List<Unlock> unlocks = new List<Unlock>();

            for (int i = 0; i < _unlockCardDict.Length; i++)
            {
                if (PreferenceUtils.Get<KitchenLib.BoolPreference>("toyemaker.plateup.cyoc2", _unlockCardDict[i].Unlock.ID.ToString()).Value)
                {
                    unlocks.Add(_unlockCardDict[i].Unlock);
                }
            }

            return unlocks;
        }

        public void SetColors(CardScrollerElement scroller)
        {
            for (int i = 0; i < _unlockCardDict.Length; i++)
            {
                _unlockCardDict[i].DefaultColor = scroller.CardBank[i].Card.material.GetColor(Shader.PropertyToID("_Title"));
            }
        }
    }
}