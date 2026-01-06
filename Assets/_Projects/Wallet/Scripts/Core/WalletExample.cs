using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Wallet
{
    public class WalletExample: MonoBehaviour
    {
        [SerializeField] private WalletUI _walletUIPrefab;
        [SerializeField] private List<Currency> _currencies;
        
        private WalletService _walletService;
        private WalletUI _walletUI;

        private void Awake()
        {
            _walletService = new WalletService(_currencies);

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