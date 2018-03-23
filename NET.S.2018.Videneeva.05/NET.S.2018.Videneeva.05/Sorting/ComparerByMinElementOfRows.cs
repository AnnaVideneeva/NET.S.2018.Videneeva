using System.Linq;

namespace Sorting
{
    /// <summary>
    /// Compares two arrays for equivalence by min element.
    /// </summary>
    public class ComparerByMinElementOfRows : Comparer
    {
        /// <summary>
        /// Compares two arrays by the minimum element.
        /// </summary>
        /// <param name="firstArray">The first array.</param>
        /// <param name="secondArray">The second array.</param>
        /// <returns>A value indicating whether one is less than, equal to, or greater than the other.</returns>
        public override int Compare(int[] firstArray, int[] secondArray)
        {
            return firstArray.Min() - secondArray.Min();
        }
    }
}
