using System;
using UnityEngine;

namespace Project.Enemy
{
   public class Health
    {
        public event Action Dead;
        
        private ReactiveVariable<float> _max;
        private ReactiveVariable<float> _current;
        private bool _isDead;

        public Health(float maxValue)
        {
            _max = new ReactiveVariable<float>(maxValue) ;
            _current = new ReactiveVariable<float>(maxValue) ;
        }
        
        public IReadOnlyVariable<float> Current => _current;
        public IReadOnlyVariable<float> Max => _max;
        
        public void Increase(float value)
        {
            if (value < 0 || _isDead)
                return;
            
            _current.Value += value;

            if (_current.Value > _max.Value)
                _current.Value = _max.Value;
        }

        public void Reduce(float value)
        {
            if (value < 0 || _isDead)
                return;
            
            _current.Value -= value;
            
            if (_current.Value <= 0)
            {
                _current.Value = 0;

                _isDead = true;
                Dead?.Invoke();
            }
        }
        
        public void Kill()
        {
            _current.Value = 0;
            
            _isDead = true;
            
            Dead?.Invoke();
        }

        public void Reset()
        {
            _current.Value = _max.Value;
            _isDead = false;
        }
    }
}