using UnityEngine;

namespace Project.Timer
{
    public class HealthUI: MonoBehaviour
    {
        [SerializeField] private HealthItemsUI _itemsUI;
        [SerializeField] private HealthButtonsUI _buttonsUI;
        
        public void Initialize(Health health, TimerService timer)
        { 
            _itemsUI.Initialize(health);
            _buttonsUI.Initialize(health, timer);
        }
    }
}