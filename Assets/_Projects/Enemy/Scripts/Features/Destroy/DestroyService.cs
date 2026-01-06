using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Enemy
{
    public class DestroyService: IDisposable
    {
        private readonly Dictionary<IDestroyable, List<ICauseDestroy>> _dictionary = new();
        private readonly int _maxLimit;

        public int Count => _dictionary.Count;

        public DestroyService(int maxLimit)
        {
            _maxLimit = maxLimit;
        }
        
        public void Register(IDestroyable target, List<ICauseDestroy> causes)
        {
            Add(target, causes);
            
            if (_dictionary.Count >= _maxLimit)
                OverLimitClear();
        }

        private void Unregister(IDestroyable target)
        {
            foreach (ICauseDestroy cause in _dictionary[target])
                cause.Destroyed -= DestroyTarget;
            
            _dictionary.Remove(target);
        }
        
        private void DestroyTarget(IDestroyable target)
        {
            DisposeAllCauses(target);
            Unregister(target);
            target.Destroy();
        }

        private void Add(IDestroyable target, List<ICauseDestroy> causes)
        {
            _dictionary[target] = causes;
            
            foreach (ICauseDestroy cause in causes)
                cause.Destroyed += DestroyTarget;
        }

        private void OverLimitClear()
        {
            if (_maxLimit <= 0) 
                return;

            List<IDestroyable> targets = _dictionary.Keys
                .Where(target => _dictionary[target]
                    .Any(cause => cause is OverLimitIsCauseDestroy))
                .ToList();

            foreach (IDestroyable target in targets)
                DestroyTarget(target);
        }

        private void DisposeAllCauses(IDestroyable target)
        {
            foreach (ICauseDestroy cause in _dictionary[target])
                if (cause is IDisposable disposable)
                    disposable.Dispose();
        }


        public void Dispose()
        {
            foreach (ICauseDestroy cause in _dictionary.Keys.SelectMany(target=> _dictionary[target]))
                cause.Destroyed -= DestroyTarget;

            _dictionary.Clear();
        }
    }
}