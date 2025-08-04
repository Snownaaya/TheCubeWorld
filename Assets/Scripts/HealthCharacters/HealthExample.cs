using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Assets.Scripts.HealthCharacters
{
    public class HealthExample : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private HealthChanger _healthChanger;
        [SerializeField] private Health _health;

        [SerializeField] private float _animationSpeed;

        private CancellationTokenSource _cancellationTokenSource;

        private void Awake()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            _healthChanger.Initialize(_health.CurrentHealth, _health.MaxHealth);
        }

        private void Start() =>
            UpdateHealth(_cancellationTokenSource.Token).Forget();

        private async UniTask UpdateHealth(CancellationToken cancellationToken)
        {
            float initialValue = _healthChanger.HealthSlider.value;

            while (cancellationToken.IsCancellationRequested == false && Mathf.Approximately(_healthChanger.HealthSlider.value, _health.CurrentHealth.Value) == false)
            {
                initialValue = Mathf.MoveTowards(initialValue, _health.CurrentHealth.Value, _animationSpeed * Time.deltaTime);
                _healthChanger.HealthSlider.value = initialValue;
                await UniTask.Yield();
            }

            if (cancellationToken.IsCancellationRequested == false)
                _healthChanger.HealthSlider.value = _health.CurrentHealth.Value;
        }
    }
}
