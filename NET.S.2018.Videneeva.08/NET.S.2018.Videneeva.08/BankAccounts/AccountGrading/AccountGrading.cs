namespace BankAccounts
{
    /// <summary>
    /// Provides methods for working with bonus points depending on the coefficients.
    /// </summary>
    public abstract class AccountGrading
    {
        #region  Fields

        protected readonly int _coeffCostReplenishment;
        protected readonly int _coeffCostBalanse;

        #endregion  Fields

        #region Constructor

        /// <summary>
        /// Full constructor to initialize the coefficients.
        /// </summary>
        /// <param name="coeffCostReplenishment">The coefficient of replenishment used in the replenishment of the account.</param>
        /// <param name="coeffCostBalanse">The balance cost factor used when debiting an account.</param>
        public AccountGrading(int coeffCostReplenishment, int coeffCostBalanse)
        {
            _coeffCostReplenishment = coeffCostReplenishment;
            _coeffCostBalanse = coeffCostBalanse;
        }

        #endregion Constructor

        #region Public methods to decrease/increase bonus points

        /// <summary>
        /// Increases bonus points depending on the coefficient of replenishment.
        /// </summary>
        /// <param name="bonusPoints">Existing bonus points.</param>
        /// <returns>Increased bonus points.</returns>
        public virtual int IncreaseBonusPoints(int bonusPoints)
        {
            return bonusPoints + _coeffCostReplenishment;
        }

        /// <summary>
        /// Reduces bonus points depending on the value of the balance.
        /// </summary>
        /// <param name="bonusPoints">Existing bonus points.</param>
        /// <returns>Reduced bonus points.</returns>
        public virtual int ReductionBonusPoints(int bonusPoints)
        {
            return (bonusPoints <= _coeffCostReplenishment)
                ? 0
                : bonusPoints - _coeffCostReplenishment;
        }

        #endregion Public methods to decrease/increase bonus points
    }
}

