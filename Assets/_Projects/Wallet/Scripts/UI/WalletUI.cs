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

        public void Initialize(WalletService walletService)
        {
            _walletService = walletService;
            
            SetupCurrenciesUI();
        }
        
        private void SetupCurrenciesUI()
        {
            foreach (Currency currency in _walletService.Currencies)
            {
                CurrencyUI ui = Instantiate(_currencyItemPrefab, _currencyContainer);
                ui.Initialize(currency);
            }
        }
    }
}
