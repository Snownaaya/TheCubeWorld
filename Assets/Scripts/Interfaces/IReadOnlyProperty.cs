using System;

namespace Assets.Scripts.Interfaces
{
    public interface IReadOnlyProperty<T>
    {
        event Action<T> Changed;
        T Value { get; }
    }
}