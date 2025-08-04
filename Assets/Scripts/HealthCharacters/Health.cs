using UnityEngine;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Properties;

namespace Assets.Scripts.HealthCharacters
{
    public abstract class Health : MonoBehaviour, IHealth
    {
        [SerializeField] private float _maxHealthValue = 100f;

        private NotLimitedProperty<float> _maxHealth;
        private NotLimitedProperty<float> _currentHealth;

        private bool _isDead = false;

        private void Awake()
        {
            _maxHealth = new NotLimitedProperty<float>(_maxHealthValue);
            _currentHealth = new NotLimitedProperty<float>(_maxHealthValue);
        }

        public IReadOnlyProperty<float> CurrentHealth => _currentHealth;
        public IReadOnlyProperty<float> MaxHealth => _maxHealth;

        public virtual void TakeDamage(float damage)
        {
            _currentHealth.Value = Mathf.Clamp(CurrentHealth.Value - damage, 0, MaxHealth.Value);

            Die();
        }

        public void Die()
        {
            if (CurrentHealth.Value <= 0 && _isDead == false)
            {
                _isDead = true;
                _currentHealth.Value = 0;
                NotifyDeath();
            }
        }

        public abstract void NotifyDeath();
    }
}