using System;
using UnityEngine;

namespace Project.Enemy
{
    [SelectionBase]
    public class Enemy: MonoBehaviour, IDestroyable, IKillable
    {
        public event Action<IKillable> Dead;

        private Health _health = new(4);

        private void Awake()
        {
            _health.Dead += OnDead;
        }

        public void Destroy() => Destroy(gameObject);

        public void Kill() => _health.Kill();
        
        private void OnDead() => Dead?.Invoke(this);
        
        private void OnDestroy()
        {
            _health.Dead -= OnDead;
        }
    }
}