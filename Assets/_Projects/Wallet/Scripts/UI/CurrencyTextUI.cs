using TMPro;
using UnityEngine;

namespace Project.Wallet
{
    public class CurrencyTextUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _valueText;
        
        private Currency _currency;
        
        public void Initialize(Currency currency)
        {
            _currency = currency;
            
            _currency.Current.Changed += OnCurrencyChanged;
            UpdateValue(_currency.Current.Value);
        }
        
        private void UpdateValue(int value) => _valueText.text = value.ToString();
        
        private void OnCurrencyChanged(int oldValue, int value) => UpdateValue(value);
        
        private void OnDestroy()
        {
            _currency.Current.Changed -= OnCurrencyChanged;
        }
    }
}