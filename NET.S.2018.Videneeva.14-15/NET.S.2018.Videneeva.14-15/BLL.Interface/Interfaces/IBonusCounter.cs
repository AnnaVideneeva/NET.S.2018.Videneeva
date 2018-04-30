using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Contains methods for calculating bonuses.
    /// </summary>
    public interface IBonusCounter
    {
        /// <summary>
        /// State the bonus counter.
        /// </summary>
        /// <param name="gradingType">A grading type.</param>
        void InstallTypeBonusCounter(GradingType gradingType);

        /// <summary>
        /// Increases bonus points.
        /// </summary>
        /// <param name="bonusPoints">A bonus points.</param>
        /// <returns>New bonus points.</returns>
        int Increase(int bonusPoints);

        /// <summary>
        /// Reductions bonus points.
        /// </summary>
        /// <param name="bonusPoints">A bonus points.</param>
        /// <returns>New bonus points.</returns>
        int Reduction(int bonusPoints);
    }
}