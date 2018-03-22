using System.Linq;

namespace Sorting
{
    public class ComparerBySumElementsOfRowsDecr : Comparer
    {
        public override int Compare(int[] firstArray, int[] secondArray)
        {
            return secondArray.Sum() - firstArray.Sum();
        }
    }
}
