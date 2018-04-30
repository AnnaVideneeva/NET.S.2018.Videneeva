using DAL.Interface.DTO;
using ORM.Entities;
using System;

namespace DAL.Mappers
{
    /// <summary>
    /// Implements an adapter for the account.
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Represent <paramref name="bankAccount"/> as an object of Account type.
        /// </summary>
        /// <param name="account">The object of BankAccount type.</param>
        /// <returns>The object of Account type.</returns>
        public static Account ToAccount(this BankAccount bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
            {
                return null;
            }

            return new Account()
            {
                Id = bankAccount.Id,
                OwnerName = bankAccount.OwnerName,
                OwnerSurname = bankAccount.OwnerSurname,
                Amount = Convert.ToDouble(bankAccount.Amount),
                BonusPoints = bankAccount.BonusPoints,
                TypeGrading = bankAccount.TypeGrading
            };
        }

        /// <summary>
        /// Represent <paramref name="account"/> as an object of BankAccount type.
        /// </summary>
        /// <param name="account">The object of Account type.</param>
        /// <returns>The object of BankAccount type.</returns>
        public static BankAccount ToBankAccount(this Account account)
        {
            if (ReferenceEquals(account, null))
            {
                return null;
            }

            return new BankAccount()
            {
                Id = account.Id,
                OwnerName = account.OwnerName,
                OwnerSurname = account.OwnerSurname,
                Amount = Convert.ToDecimal(account.Amount),
                BonusPoints = account.BonusPoints,
                TypeGrading = account.TypeGrading
            };
        }
    }
}
