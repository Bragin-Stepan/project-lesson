using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Wallet {
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField] private CurrencyDisplayUI _displayUI;
        [SerializeField] private CurrencyButtonsUI _buttonsUI;
        
        public void Initialize(Currency currency, CurrencyIconProvider iconProvider)
        {
            _displayUI.Initialize(currency, iconProvider);
            _buttonsUI.Initialize(currency);
        }
    }
}
