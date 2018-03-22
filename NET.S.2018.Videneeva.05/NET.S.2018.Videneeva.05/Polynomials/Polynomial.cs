using System;

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
            if (coefficients == null)
            {
                throw new NullReferenceException();
            }

            if (coefficients.Length == 0)
            {
                throw new ArgumentException();
            }

            _coefficients = coefficients;
        }

        /// <summary>
        /// This property sets and returns the coefficient at given index.
        /// </summary>
        /// <param name="index">Index of the coefficient.</param>
        /// <exception cref="ArgumentOutOfRangeException">Create exception if index less then 0 
        /// and more then length of the array of coefficients.</exception>
        /// <returns>The coefficient at given index.</returns>
        public double this [int index]
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

        #endregion Methods for creating and initializing objects
    }
}
