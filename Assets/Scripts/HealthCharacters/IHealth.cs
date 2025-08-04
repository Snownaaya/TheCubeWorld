using Assets.Scripts.Interfaces;
using Assets.Scripts.Properties;
using System;

namespace Assets.Scripts.HealthCharacters
{
    public interface IHealth
    {
        IReadOnlyProperty<float> MaxHealth { get; }
        IReadOnlyProperty<float> CurrentHealth { get; }

        void TakeDamage(float damage);
    }
}