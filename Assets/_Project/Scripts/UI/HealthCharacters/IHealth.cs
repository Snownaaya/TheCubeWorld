using UniRx;

namespace Assets.Scripts.UI.HealthCharacters
{
    public interface IHealth
    {
        float MaxHealth { get; }
        float CurrentHealth { get; }

        void TakeDamage(float damage);
    }
}