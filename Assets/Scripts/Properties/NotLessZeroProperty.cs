using System;
using System.Collections.Generic;

namespace Assets.Scripts.Utils
{
    public class NotLessZeroProperty<T> : Property<T> where T : IComparable
    {
        public NotLessZeroProperty(T value) : base(value) { }

        protected override bool IsValid(T value)
        {
            if (Comparer<T>.Default.Compare(value, default(T)) < 0)
                return false;
            else
                return true;
        }
    }
}
