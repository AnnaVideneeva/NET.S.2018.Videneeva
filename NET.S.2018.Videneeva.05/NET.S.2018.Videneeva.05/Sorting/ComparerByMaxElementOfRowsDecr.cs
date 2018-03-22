using System.Linq;

namespace Sorting
{
    public class ComparerByMaxElementOfRowsDecr : Comparer
    {
        public override int Compare(int[] firstArray, int[] secondArray)
        {
            return secondArray.Max() - firstArray.Max();
        }
    }
}
