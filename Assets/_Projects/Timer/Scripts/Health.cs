using System;
using UnityEngine;

namespace Project.Timer
{
   public class Health
    {
        public event Action<int, int> Changed;
        
        private readonly int _maxValue;
        private int _currentValue;

        public Health(int maxValue)
        {
            _maxValue = maxValue;
            _currentValue = _maxValue;
        }
        
        public int CurrentValue => _currentValue;
        public int MaxValue => _maxValue;
        
        public void Increase(int value)
        {
            if (value < 0)
                return;

            int oldValue = _currentValue;
            _currentValue += value;

            if (_currentValue > _maxValue)
                _currentValue = _maxValue;
            
            Changed?.Invoke(oldValue, _currentValue);
        }

        public void Reduce(int value)
        {
            if (value < 0)
                return;

            int oldValue = _currentValue;
            _currentValue -= value;
            
            if (_currentValue <= 0)
                _currentValue = 0;
            
            Changed?.Invoke(oldValue, _currentValue);
        }

        public void Reset()
        {
            int oldValue = _currentValue;
            _currentValue = MaxValue;
            
            Changed?.Invoke(oldValue, _currentValue);
        }
    }
}