using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Wallet
{
    public class WalletExample: MonoBehaviour
    {
        [SerializeField] private WalletUI _walletUIPrefab;
        [SerializeField] private List<CurrencyConfig> _currenciesConfig;
        
        private WalletService _walletService;
        private WalletUI _walletUI;
        private CurrencyIconProvider _iconProvider = new();
        private List<Currency> _currencies = new();

        private void Awake()
        {
            SetupCurrencies();
            SetupWalletUI();
        }

        private void SetupCurrencies()
        {
            foreach (CurrencyConfig config in _currenciesConfig)
            {
                _iconProvider.AddIcon(config.Type, config.Icon);
                _currencies.Add(new Currency(config));
            }
            
            _walletService = new WalletService(_currencies);
        }

        private void SetupWalletUI()
        {
            _walletUI = Instantiate(_walletUIPrefab, Vector3.zero, Quaternion.identity, null);
            _walletUI.Initialize(_walletService, _iconProvider);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _walletService.Currencies[0].TryAdd(15);
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
                _walletService.Currencies[1].TryAdd(15);
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
                _walletService.Currencies[2].TryAdd(15);
        }
    }
}