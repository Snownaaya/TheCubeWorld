using UnityEngine;

namespace Assets.Scripts.Health
{
    public abstract class HealthUIElement : MonoBehaviour
    {
        [SerializeField] protected Health _health;

        protected float MaxHealth => _health.MaxHealth;

        protected float CurrentHealth => _health.CurrentHealth;

        private void Awake() => 
            _health.Changed += HealthChanged;

        private void OnDisable() => 
            _health.Changed -= HealthChanged;

        protected abstract void HealthChanged();
    }
}