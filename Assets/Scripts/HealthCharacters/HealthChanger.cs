using UnityEngine.UI;
using UnityEngine;
using Assets.Scripts.Service.Properties;

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
            if (currentHealth == null)
                Debug.LogError("currentHealth is null!");
            if (maxHealth == null)
                Debug.LogError("maxHealth is null!");

            _currentHealth = currentHealth;
            _maxHealth = maxHealth;
            _currentHealth.Changed += OnChangeValue;
        }

        private void OnDestroy() =>
           _currentHealth.Changed -= OnChangeValue;

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