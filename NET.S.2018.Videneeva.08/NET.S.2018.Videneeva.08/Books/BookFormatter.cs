using NLog;
using System;
using System.Globalization;

namespace Books
{
    /// <summary>
    /// Provides methods for formatting.
    /// </summary>
    public class BookFormatter : IFormatProvider, ICustomFormatter
    {
        #region Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion Fields

        #region Public methods

        /// <summary>
        /// Gets an object type of custom formatter.
        /// </summary>
        /// <param name="formatType">The type of formatter.</param>
        /// <returns>An object type of custom formatter.</returns>
        public object GetFormat(Type formatType)
        {
            return (formatType == typeof(ICustomFormatter)) ? this : null;
        }

        /// <summary>
        /// Gets a string representation of the object in format using formatProvider.
        /// </summary>
        /// <param name="format">The format of string.</param>
        /// <param name="arg">An object for representation to string.</param>
        /// <param name="formatProvider">A format provider.</param>
        /// <returns>A string representation of the object in passed format.</returns>
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

            return HandleOtherFormats(format, arg);
        }

        #endregion Public methods

        #region Private method

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

        #endregion Private method
    }
}

