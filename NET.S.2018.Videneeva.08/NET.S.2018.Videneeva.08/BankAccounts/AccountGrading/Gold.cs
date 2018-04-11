namespace BankAccounts
{
    /// <summary>
    /// Provides a score grading factor Gold.
    /// </summary>
    public class Gold : AccountGrading
    {
        #region Constractor

        /// <summary>
        /// Initializes the coefficients.
        /// </summary>
        public Gold() : base(4, 5)
        {
        }

        #endregion Constractor
    }
}
