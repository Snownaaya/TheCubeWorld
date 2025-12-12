using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.HealthCharacters
{
    public abstract class Health : MonoBehaviour, IHealth
    {
        private ReactiveProperty<float> _maxHealth;
        private ReactiveProperty<float> _currentHealth;

        private protected bool _isDead = false;

        public ReactiveProperty<float> CurrentHealth => _currentHealth;
        public ReactiveProperty<float> MaxHealth => _maxHealth;

        private void Awake()
        {
            _maxHealth = new ReactiveProperty<float>(100);
            _currentHealth = new ReactiveProperty<float>(100);
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

        public void Reset() =>
            _currentHealth.Value = _maxHealth.Value;

        public abstract void NotifyDeath();
    }
}