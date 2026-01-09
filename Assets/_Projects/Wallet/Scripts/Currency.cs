using System;
using UnityEngine;

namespace Project.Wallet
{
    [Serializable]
    public class Currency
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private CurrencyType _type;
        
        public Sprite Icon => _icon;
        public IReadOnlyVariable<int> Current => _current;
        public CurrencyType Type => _type;
        
        private ReactiveVariable<int> _current = new ();
        
        public bool TryAdd (int value)
        {
            if (value < 0)
                return false;

            _current.Value += value;

            return true;
        }
        
        public bool TryReduce (int value)
        {
            if (value < 0 || _current.Value == 0)
                return false;

            if (_current.Value < value)
                _current.Value = 0;
            else
                _current.Value -= value;
            
            return true;
        }
    }
}