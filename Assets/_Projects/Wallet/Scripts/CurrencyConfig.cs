using System;
using UnityEngine;

namespace Project.Wallet
{
    [Serializable]
    public struct CurrencyConfig
    {
        public Sprite Icon;
        public CurrencyType Type;
        public int StartValue;
    }
}