using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class BonusCounter : IBonusCounter
    {
        #region Fields

        private BonusCounterType bonusCounter;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Inintializes a new instance with <paramref name="gradingType"/>.
        /// </summary>
        /// <param name="gradingType">A grading type.</param>
        public BonusCounter(GradingType gradingType)
        {
            this.bonusCounter = BonusCounterFactory.GetBonusCounter(gradingType);
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
            return bonusPoints + this.bonusCounter.CoeffCostReplenishment;
        }

        /// <summary>
        /// Reduces bonus points depending on the value of the balance.
        /// </summary>
        /// <param name="bonusPoints">Existing bonus points.</param>
        /// <returns>Reduced bonus points.</returns>
        public virtual int Reduction(int bonusPoints)
        {
            return (bonusPoints <= this.bonusCounter.CoeffCostReplenishment)
                ? 0
                : bonusPoints - this.bonusCounter.CoeffCostReplenishment;
        }

        #endregion Public methods to decrease/increase bonus points
    }
}
