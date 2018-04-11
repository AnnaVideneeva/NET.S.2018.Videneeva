namespace BankAccounts
{
    /// <summary>
    /// Provides a method for initializing the type of gradation, depending on the type.
    /// </summary>
    public class GradingFactory
    {
        /// <summary>
        /// Initializes the account gradation object, depending on the type.
        /// </summary>
        /// <param name="gradingType">The type of account graduation.</param>
        /// <returns>The object corresponding to the type of account graduation.</returns>
        public static AccountGrading GetGrading(GradingType gradingType)
        {
            AccountGrading grading = null;

            switch (gradingType)
            {
                case GradingType.Base:
                    {
                        grading = new Base();
                        break;
                    }

                case GradingType.Gold:
                    {
                        grading = new Gold();
                        break;
                    }

                case GradingType.Platinum:
                    {
                        grading = new Platinum();
                        break;
                    }
            }

            return grading;
        }
    }
}