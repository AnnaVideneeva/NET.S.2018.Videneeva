using System;
using System.Collections.Generic;

namespace Test6.Solution
{
    public interface IGenerator<T>
    {
        IEnumerable<T> Generate(T a, T b, int n, Func<T, T, T> getNextElement);
    }
}
