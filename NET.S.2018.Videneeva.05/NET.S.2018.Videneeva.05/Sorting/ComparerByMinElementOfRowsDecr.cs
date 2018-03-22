using System.Linq;

namespace Sorting
{
    public class ComparerByMinElementOfRowsDecr : Comparer
    {
        public override int Compare(int[] firstArray, int[] secondArray)
        {
            return secondArray.Min() - firstArray.Min();
        }
    }
}
