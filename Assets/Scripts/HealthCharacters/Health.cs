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

        public void Die()
        {
            if (CurrentHealth <= 0 && _isDead == false)
            {
                _isDead = true;
                _currentHealth = 0;
                NotifyDeath();
            }
        }

        public abstract void NotifyDeath();
    }
}