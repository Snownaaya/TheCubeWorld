using Assets.Scripts.Interfaces;
using System;

namespace Assets.Scripts.Utils
{
    public abstract class Property<T> : IReadOnlyProperty<T> where T : IComparable
    {
        public event Action<T> Changed;

        private T _value;

        protected Property(T value)
        {
            Value = value;
        }

        public T Value
        {
            get => _value;
            set
            {
                if (IsValid(value) == false)
                    throw new ArgumentException(nameof(value));

                T oldValue = _value;
                _value = value;

                if (_value.CompareTo(oldValue) != 0)
                    Changed?.Invoke(_value);
            }
        }

        protected abstract bool IsValid(T value);
    }
}