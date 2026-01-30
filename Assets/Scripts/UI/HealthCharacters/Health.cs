using Assets.Scripts.UI.HealthCharacters;
using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IHealth
{
    public event Action<float, float> HealthChanged;

    private float _maxHealth;
    private float _currentHealth;
    protected bool _isDead;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    protected virtual void Awake()
    {
        _maxHealth = 100;
        _currentHealth = _maxHealth;
    }

    public virtual void TakeDamage(float damage) =>
        SetHealth(_currentHealth - damage);

    protected void SetHealth(float value)
    {
        float clamped = Mathf.Clamp(value, 0, _maxHealth);
        if (Mathf.Approximately(_currentHealth, clamped))
            return;

        _currentHealth = clamped;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0 && !_isDead)
        {
            _isDead = true;
            NotifyDeath();
        }
    }

    public virtual void ResetHealth()
    {
        SetHealth(_maxHealth);
    }

    protected abstract void NotifyDeath();
}
