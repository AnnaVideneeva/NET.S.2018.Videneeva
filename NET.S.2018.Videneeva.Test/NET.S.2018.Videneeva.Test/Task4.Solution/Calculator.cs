using System.Collections.Generic;
using Task4.Solution.Interface;

namespace Task4.Solution
{
    public class Calculator
    {
        public delegate double AlgorithmCalculateAverage(List<double> values);

        public double CalculateAverage(List<double> values, AlgorithmCalculateAverage algorithmCalculateAverage)
        {
            return algorithmCalculateAverage(values);
        }

        public double CalculateAverage(List<double> values, IAlgorithmCalculateAverage algorithmCalculateAverage)
        {
            return algorithmCalculateAverage.Calculate(values);
        }
    }
}
