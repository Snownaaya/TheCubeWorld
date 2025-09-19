using Assets.Scripts.Service.Properties;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts.HealthCharacters
{
    public class HealthChanger : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Health _health;

        private IReadOnlyProperty<float> _maxHealth;
        private IReadOnlyProperty<float> _currentHealth;

        public Slider HealthSlider => _healthSlider;

        public void Initialize(IReadOnlyProperty<float> currentHealth, IReadOnlyProperty<float> maxHealth)
        {
            _currentHealth = currentHealth;
            _maxHealth = maxHealth;
            _currentHealth.Changed += OnChangeValue;
        }

        private void OnDestroy()
        {
            if (_currentHealth != null)
                _currentHealth.Changed -= OnChangeValue;
        }

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