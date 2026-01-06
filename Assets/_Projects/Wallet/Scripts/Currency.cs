using System;
using UnityEngine;

namespace Project.Wallet
{
    [Serializable]
    public class Currency
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _currentValue;
        [SerializeField] private CurrencyType _type;
        
        public event Action<CurrencyType, int, int> Changed;
        
        public Sprite Icon => _icon;
        public int Value => _currentValue;
        public CurrencyType Type => _type;
        
        public bool TryAdd (int value)
        {
            if (value < 0)
                return false;
            
            int oldValue = _currentValue;
            _currentValue += value;
            
            Changed?.Invoke(_type, oldValue, _currentValue);

            return true;
        }
        
        public bool TryReduce (int value)
        {
            if (value < 0 || _currentValue == 0)
                return false;
            
            int oldValue = _currentValue;

            if (_currentValue < value)
                _currentValue = 0;
            else
                _currentValue -= value;
            
            Changed?.Invoke(_type, oldValue, _currentValue);
            
            return true;
        }
    }
    
    // был выбор или все это держать в WalletService или добавлять сюда, решил сюда добавить
}