using System;
using System.Globalization;

namespace NET1.S._2019.Tsyvis._04
{
    /// <summary>
    /// Provide a mechanism formatting double numbers to binary representation.
    /// </summary>
    /// <seealso cref="System.IFormatProvider" />
    /// <seealso cref="System.ICustomFormatter" />
    public class BinaryRepresentationFormatProvider : IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryRepresentationFormatProvider"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public BinaryRepresentationFormatProvider(IFormatProvider provider)
        {
            this.parent = provider;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryRepresentationFormatProvider"/> class.
        /// </summary>
        public BinaryRepresentationFormatProvider() : this(CultureInfo.CurrentCulture) { }

        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>
        /// An instance of the object specified by <paramref name="formatType" />, if the <see cref="T:System.IFormatProvider" /> implementation can supply that type of object; otherwise, <see langword="null" />.
        /// </returns>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.
        /// </summary>
        /// <param name="format">A format string containing formatting specifications.</param>
        /// <param name="arg">An object to format.</param>
        /// <param name="formatProvider">An object that supplies format information about the current instance.</param>
        /// <returns>
        /// The string representation of the value of <paramref name="arg" />, formatted as specified by <paramref name="format" /> and <paramref name="formatProvider" />.
        /// </returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || format != "DB")
            {
                return string.Format(this.parent, "{0:" + format + "}", arg);
            }

            if (arg is double)
            {
                double number = (double)arg;

                unsafe
                {
                    var raw = *(ulong*)&number;
                    ulong remainder;
                    string result = string.Empty;
                    while (raw > 0)
                    {
                        remainder = raw % 2;
                        raw /= 2;
                        result = remainder.ToString() + result;
                    }

                    return result.PadLeft(64, '0');
                }
            }
            else
            {
                return string.Format(this.parent, "{0}", arg);
            }
        }
    }
}
