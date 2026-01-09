using System;
using UnityEngine;

namespace Project.Timer
{
    public class TimerService
    {
        public event Action<TimerState> ChangedState;
        public event Action<float> Ticked;
        
        private float _tickInterval;
        private float _nextTickTime;

        public float CurrentTime { get; private set; }
        public bool IsRunning { get; private set; }
        
        public TimerService(float tickInterval = 1.0f)
        {
            _tickInterval = tickInterval;
            
            ResetTick();
        }

        public void Update(float deltaTime)
        {
            if (IsRunning == false || _tickInterval <= 0)
                return;

            CurrentTime += deltaTime;
            
            while (CurrentTime >= _nextTickTime)
            {
                Ticked?.Invoke(_nextTickTime);
                _nextTickTime += _tickInterval;
            }
        }

        public void Start()
        {
            IsRunning = true;
            ChangedState?.Invoke(TimerState.Start);
        }

        public void Pause()
        {
            IsRunning = false;
            ChangedState?.Invoke(TimerState.Pause);
        }

        public void Stop()
        {
            IsRunning = false;
            ResetTick();
            ChangedState?.Invoke(TimerState.Stop);
        }

        public void Reset()
        {
            ResetTick();
            ChangedState?.Invoke(TimerState.Reset);
        }
        
        private void ResetTick()
        {
            CurrentTime = 0;
            
            if (_tickInterval <= 0) 
                return;
            
            float roundedTime = Mathf.Floor(CurrentTime / _tickInterval);
            _nextTickTime = (roundedTime + 1) * _tickInterval;
        }
    }
}