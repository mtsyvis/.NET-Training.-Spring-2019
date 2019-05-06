using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1.S._2019.Tsyvis._19.Tests
{
    public class BookFormatProviderTest : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            var book = (Book)arg;
            return $"{book.Pages}, {book.Price}";
        }
    }
}
