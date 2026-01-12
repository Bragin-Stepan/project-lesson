using System;
using UnityEngine;

namespace Project.Timer
{
   public class Health
    {
        public IReadOnlyVariable<int> Current => _current;
        public IReadOnlyVariable<int> Max => _max;
        
        private ReactiveVariable<int> _max;
        private ReactiveVariable<int> _current;

        public Health(int maxValue)
        {
            _max = new ReactiveVariable<int>(maxValue);
            _current = new ReactiveVariable<int>(maxValue);
        }
        
        public void Increase(int value)
        {
            if (value < 0)
                return;
            
            _current.Value += value;

            if (_current.Value > _max.Value)
                _current = _max;
        }

        public void Reduce(int value)
        {
            if (value < 0)
                return;
            
            _current.Value -= value;
            
            if (_current.Value <= 0)
                _current.Value = 0;
        }

        public void Reset()
        {
            _current.Value = _max.Value;
        }
    }
}