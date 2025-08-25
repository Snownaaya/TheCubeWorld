using System;

namespace Assets.Scripts.Service.Properties
{
    public class NotLimitedProperty<T> : Property<T> where T : IComparable
    {
        public NotLimitedProperty(T value) : base(value) { }

        protected override bool IsValid(T value) => true;
    }
}