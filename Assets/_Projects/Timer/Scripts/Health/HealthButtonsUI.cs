using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Timer
{
    public class HealthButtonsUI: MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        [SerializeField] private Button _startButton;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resetButton;
        
        private Health _health;
        private TimerService _timer;
        
        public void Initialize(Health health, TimerService timer)
        {
            _health = health;
            _timer = timer;
            
            _slider.maxValue = _health.Max.Value;
            _slider.value = _health.Current.Value;
            
            _startButton.onClick.AddListener(OnStart);
            _pauseButton.onClick.AddListener(OnPause);
            _resetButton.onClick.AddListener(OnReset);
            
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
            _health.Current.Changed +=  OnHealthChanged;
        }

        private void OnStart() => _timer.Start();

        private void OnPause() => _timer.Pause();

        private void OnReset()
        {
            _health.Reset();
            _timer.Reset();
        }

        private void OnHealthChanged(int oldValue, int currentValue)
        {
            _slider.value = currentValue;
        }
        
        private void OnSliderValueChanged(float changedValue)
        {
            int normalizedValue = (int)changedValue;
            int currentValue = _health.Current.Value;
            
            if (normalizedValue != currentValue)
                if (normalizedValue > currentValue)
                    _health.Increase(normalizedValue - currentValue);
                else
                    _health.Reduce(currentValue - normalizedValue);
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveListener(OnStart);
            _pauseButton.onClick.RemoveListener(OnPause);
            _resetButton.onClick.RemoveListener(OnReset);
            
            _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
            _health.Current.Changed -= OnHealthChanged;
        }
    }
}