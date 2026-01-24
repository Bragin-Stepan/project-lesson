using System;
using System.Collections.Generic;

namespace Project.Inventory
{
    public class Inventory<T>
    {
        public int MaxSize { get; private set; }

        private List<T> _items;
    
        public Inventory(List<T> items, int maxSize)
        {
            _items = new List<T>(items);
            MaxSize = maxSize;
        }
        
        public IReadOnlyList<T> Items => _items;
        public int CurrentSize => _items.Count;
        public bool IsFull => CurrentSize == MaxSize;

        public bool TryAdd(T item)
        {
            if (IsFull)
                return false;
            
            _items.Add(item);
            return true;
        }

        public bool TryRemove(T item)
        {
            if (_items.Contains(item) == false)
                return false;
            
            _items.Remove(item);
            return true;
        }
        
        public List<T> GetItemsBy(Func<T, bool> filter)
        {
            List<T> result = new ();
            
            foreach (T item in _items)
                if (filter.Invoke(item))
                    result.Add(item);

            return result;
        }
    }
}