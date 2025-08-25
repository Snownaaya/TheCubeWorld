using System;

namespace Assets.Scripts.Service.Properties
{
    public interface IReadOnlyProperty<T>
    {
        event Action<T> Changed;
        T Value { get; }
    }
}