using System;

namespace FrameworkGoat
{
    public class HidedValue<T>
    {
        private Func<T, T> _hideMethod;
        private Func<T, T> _showMethod;
        private T _value;

        /// <summary>
        /// Creates a hided value.
        /// </summary>
        /// <param name="hideMethod">Method used to hide</param>
        /// <param name="showMethod">Method used to show</param>
        public HidedValue(Func<T, T> hideMethod, Func<T, T> showMethod)
        {
            _hideMethod = hideMethod;
            _showMethod = showMethod;
            Value = default(T);
        }

        /// <summary>
        /// Creates a hided value with an initial value
        /// </summary>
        /// <param name="hideMethod">Method used to hide</param>
        /// <param name="showMethod">Method used to show</param>
        /// <param name="initialValue">Initial value</param>
        public HidedValue(Func<T, T> hideMethod, Func<T, T> showMethod, T initialValue)
        {
            _hideMethod = hideMethod;
            _showMethod = showMethod;
            Value = initialValue;
        }

        /// <summary>
        /// Value
        /// </summary>
        public T Value
        {
            get
            {
                return _showMethod(_value);
            }
            set
            {
                _value = _hideMethod(value);
            }
        }

        /// <summary>
        /// Implicit operator to use the value directly
        /// </summary>
        /// <param name="hidedValue">Returns the value directly</param>
        public static implicit operator T(HidedValue<T> hidedValue)
        {
            return hidedValue.Value;
        }
    }
}