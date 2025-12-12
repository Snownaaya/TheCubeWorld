using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.HealthCharacters
{
    public class HealthChanger : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Health _health;

        private CompositeDisposable _disposables = new CompositeDisposable();

        private ReactiveProperty<float> _maxHealth;
        private ReactiveProperty<float> _currentHealth;

        public Slider HealthSlider => _healthSlider;

        public void Initialize(ReactiveProperty<float> currentHealth, ReactiveProperty<float> maxHealth)
        {
            _currentHealth = currentHealth;
            _maxHealth = maxHealth;

            _currentHealth
                .Subscribe(OnChangeValue)
                .AddTo(_disposables);

            ChangeValue(_currentHealth.Value, _maxHealth.Value);
        }

        private void OnDestroy() =>
            _disposables.Dispose();

        private void OnChangeValue(float newValue) =>
            ChangeValue(newValue, _maxHealth.Value);

        private void ChangeValue(float currentHealth, float maxHealth)
        {
            if (_healthSlider != null)
            {
                _healthSlider.value = currentHealth;
                _healthSlider.maxValue = maxHealth;
            }
        }
    }
}