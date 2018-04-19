namespace BLL.Interface.Entities.BonusCounters
{
    public class GoldCounter : BonusCounter
    {
        #region Const fields

        private const int CoeffCostReplenishment = 4;
        private const int CoeffCostBalanse = 5;

        #endregion Const fields

        #region Constractor

        /// <summary>
        /// Initializes the coefficients.
        /// </summary>
        public GoldCounter() : base(CoeffCostReplenishment, CoeffCostBalanse)
        {
        }

        #endregion Constractor
    }
}
