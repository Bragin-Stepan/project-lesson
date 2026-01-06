using System;
using System.Collections;
using UnityEngine;

namespace Project.Enemy
{
    public class DeathIsCauseDestroy: ICauseDestroy, IDisposable
    {
        public event Action<IDestroyable> Destroyed;

        private IKillable _target;

        public DeathIsCauseDestroy(IKillable target)
        {
            _target = target;
            _target.Dead += OnDead;
        }

        private void OnDead(IKillable target)
        {
            if (target is IDestroyable destroyable)
                Destroyed?.Invoke(destroyable);
        }

        public void Dispose()
        {
            _target.Dead -= OnDead;
        }
    }
}