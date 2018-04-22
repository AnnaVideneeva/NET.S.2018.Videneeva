using BLL.Interface.Entities.BonusCountersType;
using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Provides method for getting a bonus counter.
    /// </summary>
    public class BonusCounterFactory
    {
        /// <summary>
        /// Returns a bonus counter by <paramref name="gradingType"/>.
        /// </summary>
        /// <param name="gradingType">A grading type.</param>
        /// <returns>A bonus counter by <paramref name="gradingType"/>.</returns>
        public static BonusCounterType GetBonusCounter(GradingType gradingType)
        {
            switch (gradingType)
            {
                case GradingType.Base:
                    {
                        return new Base();
                    }

                case GradingType.Gold:
                    {
                        return new Gold();
                    }

                case GradingType.Platinum:
                    {
                        return new Platinum();
                    }
                default:
                    {
                        throw new ArgumentException("This type of gradation does not exist.", nameof(gradingType));
                    }
            }
        }
    }
}