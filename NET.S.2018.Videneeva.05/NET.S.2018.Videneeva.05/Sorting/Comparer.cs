namespace Sorting
{
    /// <summary>
    /// Compares two objects for equivalence.
    /// </summary>
    abstract public class Comparer
    {
        /// <summary>
        /// Performs a comparison of two objects of the same type.
        /// </summary>
        /// <param name="firstArray"></param>
        /// <param name="secondArray"></param>
        /// <returns>A value indicating whether one is less than, equal to, or greater than the other.</returns>
        public abstract int Compare(int[] firstArray, int[] secondArray);
    }
}
