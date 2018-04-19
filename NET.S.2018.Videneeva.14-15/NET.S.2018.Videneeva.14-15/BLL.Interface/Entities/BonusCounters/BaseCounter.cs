namespace BLL.Interface.Entities.BonusCounters
{
    /// <summary>
    /// Provides a score grading factor Base.
    /// </summary>
    public class BaseCounter : BonusCounter
    {
        #region Const fields

        private const int CoeffCostReplenishment = 2;
        private const int CoeffCostBalanse = 3;

        #endregion Const fields

        #region Constractor

        /// <summary>
        /// Initializes the coefficients.
        /// </summary>
        public BaseCounter() : base(CoeffCostReplenishment, CoeffCostBalanse)
        {
        }

        #endregion Constractor
    }
}