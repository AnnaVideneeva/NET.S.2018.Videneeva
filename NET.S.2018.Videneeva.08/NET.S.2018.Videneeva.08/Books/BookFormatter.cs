using System;
using System.Globalization;

namespace Books
{
    public class BookFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return (formatType == typeof(ICustomFormatter)) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format == string.Empty) 
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException ex)
                {
                    throw new FormatException($"The format of '{format}' is invalid.", ex);
                }
            }

            return  HandleOtherFormats(format, arg);
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
            else
            {
                return (arg != null) ? (arg.ToString()) : (String.Empty);
            }
        }
    }


}

