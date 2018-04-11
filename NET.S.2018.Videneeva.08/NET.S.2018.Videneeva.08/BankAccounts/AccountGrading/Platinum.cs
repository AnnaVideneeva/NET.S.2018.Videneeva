namespace BankAccounts
{
    /// <summary>
    /// Provides a score grading factor Platinum.
    /// </summary>
    public class Platinum : AccountGrading
    {
        #region Constractor

        /// <summary>
        /// Initializes the coefficients.
        /// </summary>
        public Platinum() : base(6, 7)
        {
        }

        #endregion Constractor
    }
}
