using System;
using System.Collections.Generic;
using System.Linq;
using Task4.Solution.Interface;

namespace Task4.Solution.Services
{
    public class AlgorithmCalculateAverageByMean : IAlgorithmCalculateAverage
    {
        public double Calculate(List<double> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Sum() / values.Count;
        }
    }
}
