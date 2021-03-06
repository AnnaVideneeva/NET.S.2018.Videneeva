﻿using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IBankAccountService
    {
        /// <summary>
        /// Gets a list of all objects.
        /// </summary>
        /// <returns>The sequence to type as IEnumerable<BankAccount>.</returns>
        IEnumerable<BankAccount> GetAll();

        /// <summary>
        /// Opens a new bank account.
        /// </summary>
        /// <param name="ownerName">Name of bank account holder.</param>
        /// <param name="ownerSurname">Surname of bank account holder.</param>
        /// <param name="amount">The amount on the bank account.</param>
        /// <param name="gradingType">Type of bank account graduation.</param>
        void Open(string ownerName, string ownerSurname, double amount, GradingType gradingType);

        /// <summary>
        /// Closes a bank account.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        void Close(int id);

        /// <summary>
        /// Refills a bank account with the account <paramref name="id"/> by <paramref name="amount"/>.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        /// <param name="amount">The amount to refill.</param>
        void Refill(int id, double amount);

        /// <summary>
        /// Withdrawals a <paramref name="amount"/> from the bank account with the <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The bank account id.</param>
        /// <param name="amount">The amount to withdrawal.</param>
        void Withdrawal(int id, double amount);        
    }
}