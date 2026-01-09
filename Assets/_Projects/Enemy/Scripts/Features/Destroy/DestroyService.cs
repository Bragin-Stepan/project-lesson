using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Enemy
{
    public class DestroyService: IDisposable
    {
        private readonly Dictionary<IDestroyable, List<Func<bool>>> _dictionary = new();
        private readonly MonoBehaviour _coroutineContext;

        public int Count => _dictionary.Count;

        public DestroyService(MonoBehaviour coroutineContext)
        {
            _coroutineContext = coroutineContext;
        }
        
        public void Register(IDestroyable target, List<Func<bool>> causes)
        {
            _dictionary.TryAdd(target, causes);
            _coroutineContext.StartCoroutine(WaitCauseDestroy(target, causes));
        }

        private void DestroyTarget(IDestroyable target)
        {
            _dictionary.Remove(target);
            target.Destroy();
        }
        
        private IEnumerator<Func<bool>> WaitCauseDestroy(IDestroyable target, List<Func<bool>> causes)
        {
            while (_dictionary.ContainsKey(target))
                foreach (Func<bool> cause in causes)
                    if (cause.Invoke())
                    {
                        DestroyTarget(target);
                        yield break;
                    }
                
            yield return null;
        }

        public void Dispose()
        {
            _dictionary.Clear();
        }
    }
}