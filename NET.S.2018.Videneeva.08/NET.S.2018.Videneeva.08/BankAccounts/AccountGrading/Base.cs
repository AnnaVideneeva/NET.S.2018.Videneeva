namespace BankAccounts
{
    /// <summary>
    /// Provides a score grading factor Base.
    /// </summary>
    public class Base : AccountGrading
    {
        #region Constractor

        /// <summary>
        /// Initializes the coefficients.
        /// </summary>
        public Base() : base(2, 3)
        {
        }

        #endregion Constractor
    }
}
