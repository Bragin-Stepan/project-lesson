using System;
using System.Collections;
using UnityEngine;

namespace Project.Enemy
{
    public class LifetimeIsCauseDestroy: ICauseDestroy, IDisposable
    {
        public event Action<IDestroyable> Destroyed;
        
        private MonoBehaviour _coroutine;
        private IDestroyable _target;
        private float _time;
        
        public LifetimeIsCauseDestroy(IDestroyable target, float time, MonoBehaviour coroutine)
        {
            _time = time;
            _target = target;
            _coroutine = coroutine;
            
            _coroutine.StartCoroutine(LifetimeProcess(_target, _time));
        }
        
        private IEnumerator LifetimeProcess(IDestroyable target, float time)
        {
            yield return new WaitForSeconds(time);
            Destroyed?.Invoke(target);
        }

        public void Dispose()
        {
            _coroutine.StopCoroutine(LifetimeProcess(_target, _time));
        }
    }
}