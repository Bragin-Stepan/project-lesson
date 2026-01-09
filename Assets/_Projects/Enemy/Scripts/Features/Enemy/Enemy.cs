using System;
using UnityEngine;

namespace Project.Enemy
{
    [SelectionBase]
    public class Enemy: MonoBehaviour, IDestroyable, IKillable, IWithLifetime
    {
        private Health _health = new(4);

        public float CurrentHealth => _health.Current.Value;
        public float Lifetime { get; private set; }

        private void FixedUpdate()
        {
            Lifetime += Time.fixedDeltaTime;
        }

        public void Destroy() => Destroy(gameObject);

        public void Kill() => _health.Kill();

    }
}