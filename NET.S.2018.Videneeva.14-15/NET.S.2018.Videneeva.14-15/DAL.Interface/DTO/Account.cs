﻿namespace DAL.Interface.DTO
{
    /// <summary>
    /// Contains information about the account to work with it.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Account id.
        /// </summary>
        public int Id { get; set; }

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
        public int BonusPoints { get; set;  } 

        /// <summary>
        /// Type of account graduation.
        /// </summary>
        public int TypeGrading { get; set; }
    }
}