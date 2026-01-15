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
        private List<Currency> _currencies = new();

        private void Awake()
        {
            SetupWallet();
            SetupWalletUI();
        }

        private void SetupWallet()
        {
            foreach (CurrencyConfig config in _currenciesConfig)
                _currencies.Add(new Currency(config));
            
            _walletService = new WalletService(_currencies);
        }

        private void SetupWalletUI()
        {
            _walletUI = Instantiate(_walletUIPrefab, Vector3.zero, Quaternion.identity, null);
            _walletUI.Initialize(_walletService);
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