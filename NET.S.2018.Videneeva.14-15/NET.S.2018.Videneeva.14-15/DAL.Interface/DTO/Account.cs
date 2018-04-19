namespace DAL.Interface.DTO
{
    public class Account
    {
        #region Constructors

        /// <summary>
        /// A complete constructor to initialize the object.
        /// </summary>
        /// <param name="number">Account number.</param>
        /// <param name="ownerName">Name of account holder.</param>
        /// <param name="ownerSurname">Surname of account holder.</param>
        /// <param name="amount">The amount on the account.</param>
        /// <param name="bonusPoints">Bonus points on the account.</param>
        /// <param name="gradingType">Type of account graduation.</param>
        public Account(int number, string ownerName, string ownerSurname, double amount, int bonusPoints, int gradingType)
        {
            this.Number = number;
            this.OwnerName = ownerName;
            this.OwnerSurname = ownerSurname;
            this.Amount = amount;
            this.BonusPoints = bonusPoints;
            this.TypeGrading = gradingType;
        }

        #endregion

        /// <summary>
        /// Account number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Name of account holder.
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Surname of account holder.
        /// </summary>
        public string OwnerSurname { get; set; }

        /// <summary>
        /// The amount on the account.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Bonus points on the account.
        /// </summary>
        public int BonusPoints { get; set} 

        /// <summary>
        /// Type of account graduation.
        /// </summary>
        public int TypeGrading { get; set; }
    }
}