namespace BLL.Interface.Entities.BonusCountersType
{
    public class Platinum : BonusCounterType
    {
        #region Const fields

        private const int CoeffCostReplenishment = 6;
        private const int CoeffCostBalanse = 7;

        #endregion Const fields

        #region Constractor

        /// <summary>
        /// Initializes the coefficients.
        /// </summary>
        public Platinum() : base(CoeffCostReplenishment, CoeffCostBalanse)
        {
        }

        #endregion Constractor
    }
}
