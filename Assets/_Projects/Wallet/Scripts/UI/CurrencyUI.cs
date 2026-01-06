using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Wallet {
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _valueText;
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _removeButton;
        
        private Currency _currency;

        private const int ValueButton = 1;
        
        public void Initialize(Currency currency)
        {
            _currency = currency;
            _iconImage.sprite = currency.Icon;
            
            _addButton.onClick.AddListener(OnAddButtonClick);
            _removeButton.onClick.AddListener(OnRemoveButtonClick);
            
            UpdateValue(currency.Value);
        }
        
        public void UpdateValue(int value) => _valueText.text = value.ToString();
        
        private void OnAddButtonClick()
        {
            _currency.TryAdd(ValueButton);
            UpdateValue(_currency.Value);
        }
        
        private void OnRemoveButtonClick()
        {
            _currency.TryReduce(ValueButton);
            UpdateValue(_currency.Value);
        }
        
        private void OnDestroy()
        {
            _removeButton.onClick.RemoveListener(OnRemoveButtonClick);
            _addButton.onClick.RemoveListener(OnAddButtonClick);
        }
    }
}
