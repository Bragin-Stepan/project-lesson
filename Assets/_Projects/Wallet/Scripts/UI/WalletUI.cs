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
        private Dictionary<CurrencyType, CurrencyUI> _currencies = new();

        public void Initialize(WalletService walletService)
        {
            _walletService = walletService;
            
            foreach (Currency currency in _walletService.Currencies)
                currency.Changed += OnCurrencyChanged;
            
            SetupCurrenciesUI();
        }
        
        private void SetupCurrenciesUI()
        {
            foreach (Currency currency in _walletService.Currencies)
            {
                CurrencyUI ui = Instantiate(_currencyItemPrefab, _currencyContainer);
                ui.Initialize(currency);
                
                _currencies[currency.Type] = ui;
            }
        }
        
        private void OnCurrencyChanged(CurrencyType type, int oldValue, int value)
        {
            if (_currencies.TryGetValue(type, out CurrencyUI ui))
                ui.UpdateValue(value);
        }
        
        private void OnDisable()
        {
            if (_walletService?.Currencies != null)
                foreach (Currency currency in _walletService.Currencies)
                    currency.Changed -= OnCurrencyChanged;
        }
    }
}
