using System;
using UnityEngine;

namespace Project.Wallet
{
    [Serializable]
    public class Currency
    {
        public readonly CurrencyType Type;
        
        public IReadOnlyVariable<int> Current => _current;
        
        private ReactiveVariable<int> _current = new ();

        public Currency(CurrencyConfig config)
        {
            Type = config.Type;
            
            _current.Value = config.StartValue;
        }

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