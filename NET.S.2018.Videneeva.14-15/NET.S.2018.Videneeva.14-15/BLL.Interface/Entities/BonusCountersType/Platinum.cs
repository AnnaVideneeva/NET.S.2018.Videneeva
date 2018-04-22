namespace BLL.Interface.Entities.BonusCountersType
{
    public class Platinum : BonusCounterType
    {
        #region Const fields

        private const int PlatinumCoeffCostReplenishment = 6;
        private const int PlatinumCoeffCostBalanse = 7;

        #endregion Const fields

        #region Constractor

        /// <summary>
        /// Initializes the coefficients.
        /// </summary>
        public Platinum() : base(PlatinumCoeffCostReplenishment, PlatinumCoeffCostBalanse)
        {
        }

        #endregion Constractor
    }
}
