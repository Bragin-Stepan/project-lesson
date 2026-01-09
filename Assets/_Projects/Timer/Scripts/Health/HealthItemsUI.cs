using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Timer
{
    public class HealthItemsUI : MonoBehaviour
    {
        [SerializeField] private HorizontalOrVerticalLayoutGroup _heartItemsContainer;
        [SerializeField] private GameObject _heartItemPrefab;
        
        private Health _health;
        private List<GameObject> _heartItems = new();
        
        public void Initialize(Health health)
        {   
            _health = health;
            _health.Current.Changed +=  OnHealthChanged;
            
            for (int i = 0; i < _health.Max.Value; i++)
                AddHeartItemUI();
        }

        private void OnHealthChanged(int oldValue, int currentValue)
        {
            if (currentValue > oldValue)
                for (int i = oldValue; i < currentValue; i++)
                    AddHeartItemUI();
            else if (currentValue < oldValue)
                for (int i = currentValue; i < oldValue; i++)
                    RemoveHeartItemUI();
        }

        private void AddHeartItemUI() => _heartItems.Add(Instantiate(_heartItemPrefab, _heartItemsContainer.transform));

        private void RemoveHeartItemUI()
        {
            if (_heartItems.Count == 0)
                return;
            
            int lastIndex = _heartItems.Count - 1;
            GameObject heartToRemove = _heartItems[lastIndex];
            
            Destroy(heartToRemove);
            _heartItems.RemoveAt(lastIndex);
        }

        private void OnDestroy()
        {
            _health.Current.Changed -= OnHealthChanged;
        }
    }
}