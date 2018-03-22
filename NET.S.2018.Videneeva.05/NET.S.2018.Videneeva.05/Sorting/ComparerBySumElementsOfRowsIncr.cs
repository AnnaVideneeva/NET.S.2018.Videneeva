using System.Linq;

namespace Sorting
{
    public class ComparerBySumElementsOfRowsIncr : Comparer
    {
        public override int Compare(int[] firstArray, int[] secondArray)
        {
            return firstArray.Sum() - secondArray.Sum();
        }
    }
}
