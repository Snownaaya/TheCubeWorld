using System.Collections.Generic;
using System;

namespace Assets.Scripts.Service.Properties
{
    public class NotLessZeroProperty<T> : Property<T> where T : IComparable
    {
        public NotLessZeroProperty(T value) : base(value) { }

        protected override bool IsValid(T value)
        {
            return Comparer<T>.Default.Compare(value, default(T)) >= 0;
        }
    }
}
