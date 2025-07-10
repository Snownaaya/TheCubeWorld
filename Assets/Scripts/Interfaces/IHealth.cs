using System;

namespace Assets.Scripts.Interfaces
{
    public interface IHealth
    {
        float MaxHealth { get; }
        float CurrentHealth { get; }

        event Action Changed;

        void TakeDamage(float damage);
    }
}
