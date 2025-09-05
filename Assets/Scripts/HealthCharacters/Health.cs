using Assets.Scripts.Service.Properties;
using UnityEngine;

namespace Assets.Scripts.HealthCharacters
{
    public abstract class Health : MonoBehaviour, IHealth
    {
        private NotLimitedProperty<float> _maxHealth;
        private NotLimitedProperty<float> _currentHealth;

        private bool _isDead = false;

        private void Awake()
        {
            _maxHealth = new NotLimitedProperty<float>(100);
            _currentHealth = new NotLimitedProperty<float>(100);
        }

        public IReadOnlyProperty<float> CurrentHealth => _currentHealth;
        public IReadOnlyProperty<float> MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value as NotLimitedProperty<float>;
            }
        }

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