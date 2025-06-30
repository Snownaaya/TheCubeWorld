using UnityEngine;
using System;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Loss;

namespace Assets.Scripts.HealthCharacters
{
    public abstract class Health : MonoBehaviour, IHealth
    {
        [SerializeField] private float _maxHealth;

        public event Action Changed;
        public event Action<ILoss> Died;

        private float _currentHealth;
        private bool _isDead = false;

        public float MaxHealth => _maxHealth;
        public float CurrentHealth => _currentHealth;

        private void Awake() =>
            _currentHealth = MaxHealth;

        public virtual void TakeDamage(float damage)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
            Changed?.Invoke();

            Die();
        }

        public virtual bool CheckHealth(float health = 0)
        {
            if (_currentHealth < health)
                return true;

            return false;
        }

        public virtual void Die()
        {
            if (_currentHealth <= 0)
            {
                _isDead = true;
                Died?.Invoke(new LossHealth());
            }
        }
    }
}