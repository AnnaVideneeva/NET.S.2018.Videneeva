﻿using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class BonusCounter : IBonusCounter
    {
        #region  Fields

        private readonly int CoeffCostReplenishment;
        private readonly int CoeffCostBalanse;

        #endregion  Fields

        #region Constructor

        /// <summary>
        /// Full constructor to initialize the coefficients.
        /// </summary>
        /// <param name="coeffCostReplenishment">The coefficient of replenishment used in the replenishment of the account.</param>
        /// <param name="coeffCostBalanse">The balance cost factor used when debiting an account.</param>
        public BonusCounter(int coeffCostReplenishment, int coeffCostBalanse)
        {
            CoeffCostReplenishment = coeffCostReplenishment;
            CoeffCostBalanse = coeffCostBalanse;
        }

        #endregion Constructor

        #region Public methods to decrease/increase bonus points

        /// <summary>
        /// Increases bonus points depending on the coefficient of replenishment.
        /// </summary>
        /// <param name="bonusPoints">Existing bonus points.</param>
        /// <returns>Increased bonus points.</returns>
        public virtual int Increase(int bonusPoints)
        {
            return bonusPoints + CoeffCostReplenishment;
        }

        /// <summary>
        /// Reduces bonus points depending on the value of the balance.
        /// </summary>
        /// <param name="bonusPoints">Existing bonus points.</param>
        /// <returns>Reduced bonus points.</returns>
        public virtual int Reduction(int bonusPoints)
        {
            return (bonusPoints <= CoeffCostReplenishment)
                ? 0
                : bonusPoints - CoeffCostReplenishment;
        }

        #endregion Public methods to decrease/increase bonus points
    }
}
