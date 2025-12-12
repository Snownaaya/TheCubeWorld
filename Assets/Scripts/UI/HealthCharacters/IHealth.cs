using UniRx;

namespace Assets.Scripts.UI.HealthCharacters
{
    public interface IHealth
    {
        ReactiveProperty<float> MaxHealth { get; }
        ReactiveProperty<float> CurrentHealth { get; }

        void TakeDamage(float damage);
    }
}