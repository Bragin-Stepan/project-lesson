using UnityEngine;
using UnityEngine.UI;

namespace Project.Wallet {
    public class CurrencyButtonsUI : MonoBehaviour
    {
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _removeButton;
        
        private Currency _currency;
        private const int ValueButton = 1;
        
        public void Initialize(Currency currency)
        {
            _currency = currency;
            
            _addButton.onClick.AddListener(OnAddButtonClick);
            _removeButton.onClick.AddListener(OnRemoveButtonClick);
        }
        
        private void OnAddButtonClick()
        {
            _currency.TryAdd(ValueButton);
        }

        private void OnRemoveButtonClick()
        {
            _currency.TryReduce(ValueButton);
        }
        
        private void OnDestroy()
        {
            _removeButton.onClick.RemoveListener(OnRemoveButtonClick);
            _addButton.onClick.RemoveListener(OnAddButtonClick);
        }
    }
}