using System;
using System.Text;

namespace Polynomials
{
    public class Polynomial
    {
        #region Private values

        private double[] _coefficients;

        #endregion Private values

        #region Methods for creating and initializing objects
        /// <summary>
        /// Class constructor Polynomial.    
        /// </summary>
        /// <param name="coefficients">An array of polynomial сoefficients.</param>
        /// <exception cref="NullReferenceException">Throw NullReferenceException if coefficients is null.</exception>
        /// <exception cref="ArgumentException">Throw ArgumentException if array of polynomial сoefficient is empty.</exception>
        public Polynomial(double[] coefficients)
        {
            if (coefficients is null)
            {
                throw new NullReferenceException();
            }

            if (coefficients.Length is 0)
            {
                throw new ArgumentException();
            }

            _coefficients = coefficients;
        }

        /// <summary>
        /// Sets and returns the coefficient at given index.
        /// </summary>
        /// <param name="index">Index of the coefficient.</param>
        /// <exception cref="ArgumentOutOfRangeException">Create exception if index less then 0 
        /// and more then length of the array of coefficients.</exception>
        /// <returns>The coefficient at given index.</returns>
        public double this[int index]
        {
            get
            {
                if ((index < 0) || (index >= _coefficients.Length))
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "A coefficient with such an index does not exist.");
                }

                return _coefficients[index];
            }

            private set
            {
                if ((index < 0) || (index >= _coefficients.Length))
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "A coefficient with such an index does not exist.");
                }

                _coefficients[index] = value;
            }
        }

        /// <summary>
        /// Returns an array of coefficients.
        /// </summary>
        /// <returns>The array of coefficients.</returns>
        public double[] Coefficients
        {
            get
            {
                return _coefficients;
            }
        }

        /// <summary>
        /// Returns the number of coefficients.
        /// </summary>
        /// <returns>The number of coefficients.</returns>
        public int Count
        {
            get
            {
                return _coefficients.Length;
            }
        }

        /// <summary>
        /// Checks for coefficients.
        /// </summary>
        /// <returns>True is empty or false is not empty.</returns>
        public bool IsEmpty()
        {
            return Count is 0;
        }

        #endregion Methods for creating and initializing objects

        #region Methods of operations overloading

        /// <summary>
        /// Addition of two polinomials.
        /// </summary>
        /// <param name="firstPolynomial">First polynomial.</param>
        /// <param name="secondPolynomial">Second polynomial.</param>
        /// <exception cref="ArgumentNullException">Create exception if first or second 
        /// polynomials are null or empry at the same time.</exception>
        /// <returns>The sum of two polynomials.</returns>
        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial is null)
            {
                throw new ArgumentNullException(nameof(firstPolynomial), "First polynomial is null.");
            }

            if (secondPolynomial is null)
            {
                throw new ArgumentNullException(nameof(secondPolynomial), "Second polynomial is null.");
            }

            if (firstPolynomial.IsEmpty() && secondPolynomial.IsEmpty())
            {
                throw new ArgumentNullException("Both polynomials are empty.");
            }

            int largerCount = (firstPolynomial > secondPolynomial) ? (firstPolynomial.Count) : (secondPolynomial.Count);
            int smallerCount = (firstPolynomial > secondPolynomial) ? (secondPolynomial.Count) : (firstPolynomial.Count);

            double[] resultArray = new double[largerCount];

            for (int i = 0; i < smallerCount; i++)
            {
                resultArray[i] = firstPolynomial[i] + secondPolynomial[i];
            }

            if (firstPolynomial > secondPolynomial)
            {
                for (int j = smallerCount; j < largerCount; j++)
                {
                    resultArray[j] = firstPolynomial[j];
                }
            }
            else
            {
                for (int j = smallerCount; j < largerCount; j++)
                {
                    resultArray[j] = secondPolynomial[j];
                }
            }

            return new Polynomial(resultArray);
        }

        /// <summary>
        /// Subtraction of two polinomials.
        /// </summary>
        /// <param name="firstPolynomial">First polynomial.</param>
        /// <param name="secondPolynomial">Second polynomial.</param>
        /// <exception cref="ArgumentNullException">Create exception if first or second 
        /// polynomials are null or empry at the same time.</exception>
        /// <returns>The subtraction of two polinomials.</returns>
        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial is null)
            {
                throw new ArgumentNullException(nameof(firstPolynomial), "First polynomial is null.");
            }

            if (secondPolynomial is null)
            {
                throw new ArgumentNullException(nameof(secondPolynomial), "Second polynomial is null.");
            }

            if (firstPolynomial.IsEmpty() && secondPolynomial.IsEmpty())
            {
                throw new ArgumentNullException("Both polynomials are empty.");
            }

            int largerCount = (firstPolynomial > secondPolynomial) ? (firstPolynomial.Count) : (secondPolynomial.Count);
            int smallerCount = (firstPolynomial > secondPolynomial) ? (secondPolynomial.Count) : (firstPolynomial.Count);

            double[] resultArray = new double[largerCount];

            for (int i = 0; i < smallerCount; i++)
            {
                resultArray[i] = firstPolynomial[i] - secondPolynomial[i];
            }

            if (firstPolynomial > secondPolynomial)
            {
                for (int j = smallerCount; j < largerCount; j++)
                {
                    resultArray[j] = firstPolynomial[j];
                }
            }
            else
            {
                for (int j = smallerCount; j < largerCount; j++)
                {
                    resultArray[j] = (-1) * secondPolynomial[j];
                }
            }

            return new Polynomial(resultArray);
        }

        /// <summary>
        /// Multiply the polinomial by factor.
        /// </summary>
        /// <param name="polynomial">A polynomial.</param>
        /// <param name="factor">A factor.</param>
        /// <returns>The polynomial multiplied by factor.</returns>
        public static Polynomial operator *(Polynomial polynomial, double factor)
        {
            if (factor is 1)
            {
                return new Polynomial(polynomial.Coefficients);
            }

            double[] result = new double[polynomial.Count];

            for (int i = 0; i < polynomial.Count; i++)
            {
                result[i] = polynomial[i] * factor;
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Multiply the polinomial by factor.
        /// </summary>
        /// <param name="polynomial">A polynomial.</param>
        /// <param name="factor">A factor.</param>
        /// <returns>The polynomial multiplied by factor.</returns>
        public static Polynomial operator *(double factor, Polynomial polynomial)
        {
            return polynomial * factor;
        }

        /// <summary>
        /// Divids the polinomial by factor.
        /// </summary>
        /// <param name="polynomial">A polynomial.</param>
        /// <param name="factor">A factor.</param>
        /// <exception cref="ArgumentNullException">Create exception if factor is 0.</exception>
        /// <returns>The polynomial divided by factor.</returns>
        public static Polynomial operator /(Polynomial polynomial, double factor)
        {
            if (factor is 0)
            {
                throw new ArgumentNullException(nameof(factor), "The factor can not be 0.");
            }

            if (factor is 1)
            {
                return new Polynomial(polynomial.Coefficients);
            }

            double[] result = new double[polynomial.Count];

            for (int i = 0; i < polynomial.Count; i++)
            {
                result[i] = polynomial[i] / factor;
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Checks for equality.
        /// </summary>
        /// <param name="firstPolynomial">First polynomial.</param>
        /// <param name="secondPolynomial">Second polynomial.</param>
        /// <returns>True if two objects are equal, otherwise false.</returns>
        public static bool operator ==(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial is null && secondPolynomial != null)
            {
                return false;
            }

            return firstPolynomial.Equals(secondPolynomial);
        }

        /// <summary>
        /// Checks for equality.
        /// </summary>
        /// <param name="firstPolynomial">First polynomial.</param>
        /// <param name="secondPolynomial">Second polynomial.</param>
        /// <returns>True if two objects are not equal, otherwise false.</returns>
        public static bool operator !=(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return !(firstPolynomial == secondPolynomial);
        }

        /// <summary>
        /// Compares two polynomials.
        /// </summary>
        /// <param name="firstPolynomial">First polynomial.</param>
        /// <param name="secondPolynomial">Second polynomial.</param>
        /// <exception cref="ArgumentNullException">Create exception if first or second polynomials are null.</exception>
        /// <returns>True if the first polynomial is greater than the second and false if the first is less than the second.</returns>
        public static bool operator >(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial is null)
            {
                throw new ArgumentNullException(nameof(firstPolynomial), "First polynomial is null.");
            }

            if (secondPolynomial is null)
            {
                throw new ArgumentNullException(nameof(secondPolynomial), "Second polynomial is null.");
            }

            return firstPolynomial.Count > secondPolynomial.Count;
        }

        /// <summary>
        /// Compares two polynomials.
        /// </summary>
        /// <param name="firstPolynomial">First polynomial.</param>
        /// <param name="secondPolynomial">Second polynomial.</param>
        /// <exception cref="ArgumentNullException">Create exception if first or second polynomials are null.</exception>
        /// <returns>True if the second polynomial is greater than the first and false if the second is less than the first.</returns>
        public static bool operator <(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial is null)
            {
                throw new ArgumentNullException(nameof(firstPolynomial), "First polynomial is null.");
            }

            if (secondPolynomial is null)
            {
                throw new ArgumentNullException(nameof(secondPolynomial), "Second polynomial is null.");
            }

            return firstPolynomial.Count < secondPolynomial.Count;
        }

        #endregion Methods of operations overloading

        #region Methods of object methods overloading

        /// <summary>
        /// Forms a string of a polynomial.
        /// </summary>
        /// <returns>The string of a polynomial.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (Coefficients[i] != 0)
                {
                    if (i == 0)
                    {
                        result.AppendFormat($"{Coefficients[i]}");
                        continue;
                    }

                    if (Coefficients[i] > 0 && result.Length > 0)
                    {
                        result.AppendFormat($" + {Coefficients[i]}*x^{i}");
                    }
                    else
                    {
                        result.AppendFormat($" {Coefficients[i]}*x^{i}");
                    }
                }
            }

            return result.ToString().Trim();
        }

        /// <summary>
        /// Generates a hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = 1;

            for (int i = 0; i < Count; i++)
            {
                hashCode *= Count;
                hashCode += (int)this[i];
            }

            return hashCode;
        }

        /// <summary>
        /// Checks for equality.
        /// </summary>
        /// <returns>True if two objects are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if ((obj is null) || (obj.GetType() != this.GetType()))
            {
                return false;
            }

            return this.Equals((Polynomial)obj);
        }

        private bool Equals(Polynomial polynomial)
        {
            if ((polynomial.Count != this.Count))
            {
                return false;
            }

            for (int i = 0; i < polynomial.Count; i++)
            {
                if (!this[i].Equals(polynomial[i]))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion Methods of object methods overloading
    }
}
