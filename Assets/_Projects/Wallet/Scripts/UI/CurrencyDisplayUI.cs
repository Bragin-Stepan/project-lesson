using UnityEngine;

namespace Project.Wallet {
    public class CurrencyDisplayUI : MonoBehaviour
    {
        [SerializeField] private CurrencyImageUI _icon;
        [SerializeField] private CurrencyTextUI _text;
        
        public void Initialize(Currency currency)
        {
            _icon.Initialize(currency.Icon);
            _text.Initialize(currency);
        }
    }
}