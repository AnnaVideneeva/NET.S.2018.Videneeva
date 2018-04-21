namespace BLL.Interface.Entities
{
    public abstract class BonusCounterType
    {
        #region Constructor

        /// <summary>
        /// Full constructor to initialize the coefficients.
        /// </summary>
        /// <param name="coeffCostReplenishment">The coefficient of replenishment used in the replenishment of the account.</param>
        /// <param name="coeffCostBalanse">The balance cost factor used when debiting an account.</param>
        public BonusCounterType(int coeffCostReplenishment, int coeffCostBalanse)
        {
            CoeffCostReplenishment = coeffCostReplenishment;
            CoeffCostBalanse = coeffCostBalanse;
        }

        #endregion Constructor

        #region  Properties

        public int CoeffCostReplenishment { get; private set; }
        public int CoeffCostBalanse { get; private set; }

        #endregion  Properties
    }
}