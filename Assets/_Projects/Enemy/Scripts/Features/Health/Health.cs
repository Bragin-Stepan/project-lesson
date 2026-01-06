using System;
using UnityEngine;

namespace Project.Enemy
{
   public class Health
    {
        public event Action<float, float> Changed;
        public event Action Dead;
        
        private readonly float _maxValue;
        private float _currentValue;
        private bool _isDead;

        public Health(float maxValue)
        {
            _maxValue = maxValue;
            _currentValue = _maxValue;
        }
        
        public float CurrentValue => _currentValue;
        public float MaxValue => _maxValue;
        
        public void Increase(float value)
        {
            if (value < 0 || _isDead)
                return;

            float oldValue = _currentValue;
            _currentValue += value;

            if (_currentValue > _maxValue)
                _currentValue = _maxValue;
            
            Changed?.Invoke(oldValue, _currentValue);
        }

        public void Reduce(float value)
        {
            if (value < 0 || _isDead)
                return;

            float oldValue = _currentValue;
            _currentValue -= value;
            
            if (_currentValue <= 0)
            {
                _currentValue = 0;

                _isDead = true;
                Dead?.Invoke();
            }
            
            Changed?.Invoke(oldValue, _currentValue);
        }
        
        public void Kill()
        {
            float oldValue = _currentValue;
            _currentValue = 0;
            
            _isDead = true;
            
            Dead?.Invoke();
            Changed?.Invoke(oldValue, _currentValue);
        }

        public void Reset()
        {
            float oldValue = _currentValue;
            _currentValue = _maxValue;
            _isDead = false;
            
            Changed?.Invoke(oldValue, _currentValue);
        }
    }
}