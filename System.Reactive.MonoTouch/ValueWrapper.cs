using System;

namespace System.Reactive.MonoTouch
{
    class ValueWrapper<T> : IComparable<ValueWrapper<T>>, IEquatable<ValueWrapper<T>>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        static public implicit operator ValueWrapper<T> (T value) 
        {
            return new ValueWrapper<T> (value);
        }

        static public implicit operator T (ValueWrapper<T> wrapper)
        {
            return wrapper.Value;
        }

        public T Value { get; private set; }

        public ValueWrapper (T value)
        {
            Value = value;
        }

        public bool Equals (ValueWrapper<T> that)
        {
            return this.Value.Equals (that.Value);
        }

        public int CompareTo (ValueWrapper<T> other)
        {
            return this.Value.CompareTo (other.Value);
        }

        public override bool Equals (object obj)
        {
            var that = obj as ValueWrapper<T>;
            if (that == null)
                return false;
            
            return this.Equals (that);
        }

        public override int GetHashCode ()
        {
            return Value.GetHashCode ();
        }
    }
}

