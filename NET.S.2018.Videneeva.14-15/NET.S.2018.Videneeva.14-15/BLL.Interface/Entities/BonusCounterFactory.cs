using BLL.Interface.Entities.BonusCountersType;
using System;

namespace BLL.Interface.Entities
{
    public class BonusCounterFactory
    {
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