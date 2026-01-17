using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Wallet
{
    public class CurrencyIconProvider
    {
        private Dictionary<CurrencyType, Sprite> _icons = new();
        
        public void AddIcon(CurrencyType type, Sprite icon)
            => _icons.Add(type, icon);

        public Sprite GetIconByType(CurrencyType type)
            => _icons.FirstOrDefault(x => x.Key == type).Value;
    }
}