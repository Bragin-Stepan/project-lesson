using UnityEngine;

namespace Project.Timer
{
    public class TimerExample: MonoBehaviour
    {
        [SerializeField] private TimerExampleUI _uiPrefab;

        private TimerExampleUI _ui;
        private TimerService _timerService;
        private Health _health;
        
        private const int MaxCount = 10;
        private const int ReduceValue = 1;

        private void Awake()
        {
            _health = new Health(MaxCount);
            _timerService = new TimerService();

            _timerService.Ticked += OnTicked;
            _timerService.Start();
            
            _ui = Instantiate(_uiPrefab, Vector3.zero, Quaternion.identity, null);
            _ui.Initialize(_health, _timerService);
        }

        private void Update()
        {
            _timerService.Update(Time.deltaTime);
        }
        
        private void OnTicked(float time)
        {
            Debug.Log("Time: " + time);
            
            if (_health.CurrentValue > 0)
                _health.Reduce(ReduceValue);
            
            Debug.Log("Current Value: " + _health.CurrentValue);
        }

        private void OnDestroy()
        {
            _timerService.Ticked -= OnTicked;
        }
    }
}