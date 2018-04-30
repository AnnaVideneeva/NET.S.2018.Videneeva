using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using System;

namespace BLL.ServiceImplementation
{
    public class BonusCounter : IBonusCounter
    {
        #region Fields

        private BonusCounterType bonusCounter;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Inintializes a new instance.
        /// </summary>
        public BonusCounter()
        {
            bonusCounter = null;
        }

        #endregion Constructor

        #region Public method for getting bonusCounter

        /// <summary>
        /// Install the bonus counter.
        /// </summary>
        /// <param name="gradingType">A grading type.</param>
        public void InstallTypeBonusCounter(GradingType gradingType)
        {
            this.bonusCounter = BonusCounterFactory.GetBonusCounter(gradingType);
        }

        #endregion Public method for getting bonusCounter

        #region Public methods to decrease/increase bonus points

        /// <summary>
        /// Increases bonus points depending on the coefficient of replenishment.
        /// </summary>
        /// <param name="bonusPoints">Existing bonus points.</param>
        /// <returns>Increased bonus points.</returns>
        public virtual int Increase(int bonusPoints)
        {
            if (ReferenceEquals(null, bonusCounter))
            {
                throw new InvalidOperationException("The type of bonus counter is not install.");
            }

            return bonusPoints + this.bonusCounter.CoeffCostReplenishment;
        }

        /// <summary>
        /// Reduces bonus points depending on the value of the balance.
        /// </summary>
        /// <param name="bonusPoints">Existing bonus points.</param>
        /// <returns>Reduced bonus points.</returns>
        public virtual int Reduction(int bonusPoints)
        {
            if (ReferenceEquals(null, bonusCounter))
            {
                throw new InvalidOperationException("The type of bonus counter is not install.");
            }

            return (bonusPoints <= this.bonusCounter.CoeffCostReplenishment)
                ? 0
                : bonusPoints - this.bonusCounter.CoeffCostReplenishment;
        }

        #endregion Public methods to decrease/increase bonus points
    }
}
