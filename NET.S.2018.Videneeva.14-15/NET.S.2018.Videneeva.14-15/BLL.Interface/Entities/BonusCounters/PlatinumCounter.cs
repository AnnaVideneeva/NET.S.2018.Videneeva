namespace BLL.Interface.Entities.BonusCounters
{
    public class PlatinumCounter : BonusCounter
    {
        #region Const fields

        private const int CoeffCostReplenishment = 6;
        private const int CoeffCostBalanse = 7;

        #endregion Const fields

        #region Constractor

        /// <summary>
        /// Initializes the coefficients.
        /// </summary>
        public PlatinumCounter() : base(CoeffCostReplenishment, CoeffCostBalanse)
        {
        }

        #endregion Constractor
    }
}
