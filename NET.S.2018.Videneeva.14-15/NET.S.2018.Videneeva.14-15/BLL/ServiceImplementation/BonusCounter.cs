using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class BonusCounter : IBonusCounter
    {
        #region Fields

        BonusCounterType bonusCounter;

        #endregion Fields

        #region Constructor

        public BonusCounter(GradingType gradingType)
        {
            bonusCounter = BonusCounterFactory.GetBonusCounter(gradingType);
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
            return bonusPoints + bonusCounter.CoeffCostReplenishment;
        }

        /// <summary>
        /// Reduces bonus points depending on the value of the balance.
        /// </summary>
        /// <param name="bonusPoints">Existing bonus points.</param>
        /// <returns>Reduced bonus points.</returns>
        public virtual int Reduction(int bonusPoints)
        {
            return (bonusPoints <= bonusCounter.CoeffCostReplenishment)
                ? 0
                : bonusPoints - bonusCounter.CoeffCostReplenishment;
        }

        #endregion Public methods to decrease/increase bonus points
    }
}
