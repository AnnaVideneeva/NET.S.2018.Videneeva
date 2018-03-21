using System;
using System.Text;


namespace ExtensionDouble
{
    /// <summary>
    /// This class contains a method for converting double to IEEE754 standard.
    /// </summary>
    public class ExtensionDoubleIEEE754
    {
        #region Private variables

        private const int exponentialShift = 1023;
        private const int exponentialLenght = 11;
        private const int matissueLength = 52;

        #endregion Private variables

        #region Public method converting double

        /// <summary>
        /// This method implements a string binary representation 
        /// of a double precision real number in the IEEE 754 format. 
        /// </summary>
        /// <param name="number">Double number which must be converted.</param>
        /// <returns>String representation of double in IEEE 754.</returns>
        public static string ConvertDoubleToIEEE754(double number)
        {
            string sing = IdentifySign(ref number);
            string exponent = IdentifyExponent(number).Substring(0, exponentialLenght);
            string mantissa = IdentifyMantissa(number).Substring(0, matissueLength);
            return sing + exponent + mantissa;
        }

        #endregion Public method converting double

        #region Private method converting double

        /// <summary>
        /// This method determines the sign. 
        /// </summary>
        /// <param name="number">Double number which must be converted.</param>
        /// <returns>A string "1" if the number is negative, the string "0" - if positive.</returns>
        private static string IdentifySign(ref double number)
        {
            if ((number < 0) || (double.IsNaN(number)) || double.IsNegativeInfinity(1 / number))
            {
                number = Math.Abs(number);
                return "1";
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// This method determines the exponent. 
        /// </summary>
        /// <param name="number">Double number which must be converted.</param>
        /// <returns>Exponent in binary representation.</returns>
        private static string IdentifyExponent(double number)
        {
            if ((double.IsNaN(number)) || (double.IsNegativeInfinity(number)) || (double.IsPositiveInfinity(number)))
            {
                return "11111111111";
            }

            string[] binaryRepresentation = ConverterToBinary(number);
            int exponent = binaryRepresentation[0].Length - 1;
            return ConverterToBinary(exponent + exponentialShift)[0];
        }

        /// <summary>
        /// This method represents a binary number in a normalized exponential form. 
        /// </summary>
        /// <param name="number">A binary number.</param>
        private static void RepresentationNormalizedExponentialForm(string[] binaryNumber)
        {
            binaryNumber[1] = binaryNumber[1].Insert(0, binaryNumber[0].Substring(1));
            binaryNumber[0] = "1";
        }

        /// <summary>
        /// This method determines the mantissa. 
        /// </summary>
        /// <param name="number">Double number which must be converted.</param>
        /// <returns>Mantissa in binary representation.</returns>
        private static string IdentifyMantissa(double number)
        {
            if ((double.IsNaN(number)) || (double.IsNegativeInfinity(number)) || (double.IsPositiveInfinity(number)))
            {
                return "0000000000000000000000000000000000000000000000000000";
            }
            string[] binaryNumber = ConverterToBinary(number);
            RepresentationNormalizedExponentialForm(binaryNumber);
            return binaryNumber[1];
        }

        /// <summary>
        /// This method converts the integer part from the decimal number system to binary. 
        /// </summary>
        /// <param name="number">A integer number.</param>
        /// <returns>A string with a binary representation.</returns>
        private static string ConvertIntPart(int number)
        {
            StringBuilder result = new StringBuilder();

            while (number != 1)
            {
                result.Insert(0, number % 2);
                number /= 2;
            }

            result.Insert(0, 1);

            return result.ToString();
        }

        /// <summary>
        /// This method converts the fraction from the decimal number system to binary. 
        /// </summary>
        /// <param name="number">A fraction.</param>
        /// <returns>A string with a binary representation.</returns>
        private static string ConvertFraction(double number)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 52; i++)
            {
                number *= 2;
                int intPart = (int)number;
                result.Append(intPart.ToString());
                number -= intPart;
            }

            return result.ToString();
        }

        /// <summary>
        /// This method converts the number from the decimal number system to binary. 
        /// </summary>
        /// <param name="number">A number for converting.</param>
        /// <returns>A string array with a binary representation.</returns>
        private static string[] ConverterToBinary(double number)
        {
            string[] binaryString = new string[2];

            binaryString[0] = ConvertIntPart((int)number);
            binaryString[1] = ConvertFraction(number - (int)number);

            return binaryString;
        }

        #endregion Private method converting double
    }
}
