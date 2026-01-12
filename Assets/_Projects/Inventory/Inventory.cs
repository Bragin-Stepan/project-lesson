using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Project.Inventory
{
    public class Inventory<T> where T : IIdentifiable
    {
        public event Action<T> SizeChanged;
        public event Action<T, int , int> StackChanged;
        
        public IReadOnlyDictionary<T, int> Items => _items;
        public int CurrentSize => _items.Count;
        public int MaxSize { get; }
        public bool IsFull => CurrentSize == MaxSize;
        
        private Dictionary<T, int> _items;
    
        public Inventory(Dictionary<T, int> items, int maxSize)
        {
            _items = new Dictionary<T, int>(items);
            MaxSize = maxSize;
        }

        public void Add(T item, int count = 1)
        {
            if (count < 1)
                ExceptionThrower.MustGreaterZero();
            
            if (IsFull)
                return;

            if (CanStack(item))
                AddStack(item, count);
            else
            {
                _items.Add(item, count);
                SizeChanged?.Invoke(item);
            }
        }

        public void Remove(T item, int count = 1)
        {
            if (count < 1)
                ExceptionThrower.MustGreaterZero();
            
            if (_items.ContainsKey(item))
            {
                if (_items[item] > count)
                    RemoveStack(item, count);
                else
                    _items.Remove(item);
            }
        }
        
        public IReadOnlyDictionary<T, int> GetItemsBy(Func<T, bool> filter)
        {
            Dictionary<T, int> result = new ();
            
            foreach (KeyValuePair<T, int> item in _items)
                if (filter.Invoke(item.Key))
                    result.Add(item.Key, item.Value);

            return result;
        }

        public T GetById(IIdentifiable target)
            => _items.First(item => item.Key.Id == target.Id).Key;
        
        public int GetStackSizeById(IIdentifiable target)
            => _items.First(item => item.Key.Id == target.Id).Value;
        
        
        private bool CanStack(T item)
        {
            if (_items.ContainsKey(item) && item is IStackable stackable)
                return _items[item] < stackable.StackSize;
            
            return false;
        }

        private void AddStack(T item, int count)
        {
            int oldCount = _items[item];
            IStackable stackable = (IStackable)item;
            
            _items[item] += count;
            
            if (_items[item] > stackable.StackSize)
                _items[item] = stackable.StackSize;
            
            StackChanged?.Invoke(item, oldCount, _items[item]);
        }

        private void RemoveStack(T item, int count)
        {
            int oldCount = _items[item];
            _items[item] -= count;
            StackChanged?.Invoke(item, oldCount, _items[item]);
        }
    }
    
    // - есть фильтр GetItemsBy, по нему уже и искать по имени, тегам, стихиям и т.д.
    // - решил не добавлять реактивность, читалось не очень хорошо для проверки
    
    // ps: на работоспособность не проверял :D
}