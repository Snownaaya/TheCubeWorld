using System;

namespace Assets.Scripts.Interfaces
{
    public interface IHealth
    {
        float MaxHealth { get; }
        float CurrentHealth { get; }

        event Action Changed;
        event Action<ILoss> Died;
        public void TakeDamage(float damage);
        public bool CheckHealth(float heal = 0);
    }
}
