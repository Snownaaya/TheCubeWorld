using UnityEngine;
using System;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Health
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] private float _maxHealth;

        public event Action Changed;

        private float _currentHealth;

        public float MaxHealth => _maxHealth;

        public float CurrentHealth => _currentHealth;

        private void Awake() =>
            _currentHealth = MaxHealth;

        public void TakeDamage(float damage)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
            Changed?.Invoke();
        }

        public bool CheckHealth(float health = 0)
        {
            if(_currentHealth < health)
                return true;

            return false;
        }
    }
}