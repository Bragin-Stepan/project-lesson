using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Project.Inventory
{
    public class Inventory<T>
    {
        public IReadOnlyList<T> Items => _items;
        public IReadOnlyVariable<int> MaxSize => _maxSize;
        public IReadOnlyVariable<int> CurrentSize => new ReactiveVariable<int>(_items.Count);
        public IReadOnlyVariable<bool> IsFull => new ReactiveVariable<bool>(CurrentSize.Value == _maxSize.Value);

        private ReactiveVariable<int> _maxSize;
        private List<T> _items;
    
        public Inventory(List<T> items, int maxSize)
        {
            _items = new List<T>(items);
            _maxSize = new ReactiveVariable<int>(maxSize);
        }

        public void Add(T item)
        {
            if (IsFull.Value)
                return;
            
            _items.Add(item);
        }

        public void Remove(T item)
        {
            if (_items.Contains(item) == false)
                return;
            
            _items.Remove(item);
        }
        
        public IReadOnlyList<T> GetItemsBy(Func<T, bool> filter)
        {
            List<T> result = new ();
            
            foreach (T item in _items)
                if (filter.Invoke(item))
                    result.Add(item);

            return result;
        }
    }
}