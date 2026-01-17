using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Wallet {
    public class WalletUI : MonoBehaviour
    {
        [SerializeField] private Transform _currencyContainer;
        [SerializeField] private CurrencyUI _currencyItemPrefab;
        
        private WalletService _walletService;
        private CurrencyIconProvider _iconProvider;

        public void Initialize(WalletService walletService, CurrencyIconProvider iconProvider)
        {
            _walletService = walletService;
            _iconProvider = iconProvider;
            
            SetupCurrenciesUI();
        }
        
        private void SetupCurrenciesUI()
        {
            foreach (Currency currency in _walletService.Currencies)
            {
                CurrencyUI ui = Instantiate(_currencyItemPrefab, _currencyContainer);
                ui.Initialize(currency, _iconProvider);
            }
        }
    }
}
