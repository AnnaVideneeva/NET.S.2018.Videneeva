namespace BLL.Interface.Entities.BonusCountersType
{
    public class Gold : BonusCounterType
    {
        #region Const fields

        private const int CoeffCostReplenishment = 4;
        private const int CoeffCostBalanse = 5;

        #endregion Const fields

        #region Constractor

        /// <summary>
        /// Initializes the coefficients.
        /// </summary>
        public Gold() : base(CoeffCostReplenishment, CoeffCostBalanse)
        {
        }

        #endregion Constractor
    }
}
