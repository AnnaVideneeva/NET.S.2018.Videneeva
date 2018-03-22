using System.Linq;

namespace Sorting
{
    /// <summary>
    /// Compares two arrays for equivalence by max element.
    /// </summary>
    public class ComparerByMinElementOfRowsIncr : Comparer
    {
        public override int Compare(int[] firstArray, int[] secondArray)
        {
            return firstArray.Min() - secondArray.Min();
        }
    }
}
