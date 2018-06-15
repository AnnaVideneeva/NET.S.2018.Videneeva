using System;
using System.Collections.Generic;

namespace Test6.Solution
{
    public class Generator<T> : IGenerator<T>
    {
        public IEnumerable<T> Generate(T a, T b, int n, Func<T, T, T> getNextElement)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Count of sequence is not be negative or equals 0.", nameof(n));
            }

            if (n >= 1)
            {
                yield return a;
            }
           
            if (n >= 2)
            {
                yield return b;
            }

            if (n > 2)
            {
                T xn_1 = a;
                T xn = b;

                for (int i = 3; i <= n; i++)
                {
                    T temp = xn;
                    xn = getNextElement(xn, xn_1);
                    yield return xn;
                    xn_1 = temp;
                }
            }
        }
    }
}