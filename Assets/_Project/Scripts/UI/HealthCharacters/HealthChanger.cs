namespace Assets.Scripts.UI.HealthCharacters
{
    using System.Threading;
    using Cysharp.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.UI;

    public class HealthChanger : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Health _health;
        [SerializeField] private float _animationSpeed;

        private CancellationTokenSource _cancellationTokenSource;

        private void Awake()
        {
            _healthSlider.maxValue = _health.MaxHealth;
            _healthSlider.value = _health.CurrentHealth;
        }

        public void OnEnable() =>
            _health.HealthChanged += OnHealthChanged;

        private void OnDisable()
        {
            _health.HealthChanged -= OnHealthChanged;

            CancelAnimation();
        }

        private void OnHealthChanged(float current, float max)
        {
            CancelAnimation();

            _cancellationTokenSource = new CancellationTokenSource();
            UpdateHealth(_cancellationTokenSource.Token, current).Forget();
        }

        private async UniTask UpdateHealth(CancellationToken cancellationToken, float targetValue)
        {
            while (cancellationToken.IsCancellationRequested == false &&
                   Mathf.Approximately(_healthSlider.value, targetValue) == false)
            {
                _healthSlider.value = Mathf.MoveTowards(
                    _healthSlider.value,
                    targetValue,
                    _animationSpeed * Time.deltaTime
                );

                await UniTask.Yield();
            }

            if (cancellationToken.IsCancellationRequested == false)
                _healthSlider.value = _health.CurrentHealth;
        }

        private void CancelAnimation()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = null;
        }
    }
}