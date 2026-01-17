using UnityEngine;

namespace Project.Wallet {
    public class CurrencyDisplayUI : MonoBehaviour
    {
        [SerializeField] private CurrencyImageUI _icon;
        [SerializeField] private CurrencyTextUI _text;
        
        public void Initialize(Currency currency, CurrencyIconProvider iconProvider)
        {
            _icon.Initialize(iconProvider.GetIconByType(currency.Type));
            _text.Initialize(currency);
        }
    }
}