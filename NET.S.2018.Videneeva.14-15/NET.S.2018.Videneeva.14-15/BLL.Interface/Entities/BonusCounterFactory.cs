using BLL.Interface.Entities.BonusCounters;
using BLL.Interface.Interfaces;
using System;

namespace BLL.Interface.Entities
{
    public class BonusCounterFactory
    {
        public static BonusCounter GetBonusCounter(GradingType gradingType)
        {
            switch (gradingType)
            {
                case GradingType.Base:
                    {
                        return new BaseCounter();
                    }

                case GradingType.Gold:
                    {
                        return new GoldCounter();
                    }

                case GradingType.Platinum:
                    {
                        return new PlatinumCounter();
                    }
                default:
                    {
                        throw new ArgumentException("This type of gradation does not exist.", nameof(gradingType));
                    }
            }
        }
    }
}
