using Assets.Scripts.Service.Properties;

namespace Assets.Scripts.HealthCharacters
{
    public interface IHealth
    {
        IReadOnlyProperty<float> MaxHealth { get; }
        IReadOnlyProperty<float> CurrentHealth { get; }

        void TakeDamage(float damage);
    }
}