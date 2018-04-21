namespace BLL.Interface.Entities.BonusCountersType
{
    /// <summary>
    /// Provides a score grading factor Base.
    /// </summary>
    public class Base : BonusCounterType
    {
        #region Const fields

        private const int CoeffCostReplenishment = 2;
        private const int CoeffCostBalanse = 3;

        #endregion Const fields

        #region Constractor

        /// <summary>
        /// Initializes the coefficients.
        /// </summary>
        public Base() : base(CoeffCostReplenishment, CoeffCostBalanse)
        {
        }

        #endregion Constractor
    }
}