using System;

namespace BankAccounts
{
    /// <summary>
    /// Provides properties and methods for working with the account.
    /// </summary>
    public class Account
    {
        #region Fields

        private int _number;
        private string _ownerName;
        private string _ownerSurname;
        private double _amount;
        private int _bonusPoints;
        private AccountGrading _grading;
        private GradingType _typeGrading;

        #endregion Fields

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
        public Account(int number, string ownerName, string ownerSurname, double amount, int bonusPoints, GradingType gradingType)
        {
            Number = number;
            OwnerName = ownerName;
            OwnerSurname = ownerSurname;
            Amount = amount;
            BonusPoints = bonusPoints;
            TypeGrading = gradingType;
            Grading = GradingFactory.GetGrading(gradingType);
        }

        /// <summary>
        /// A constructor to initialize the object.
        /// </summary>
        /// <param name="number">Account number.</param>
        /// <param name="ownerName">Name of account holder.</param>
        /// <param name="ownerSurname">Surname of account holder.</param>
        /// <param name="gradingType">Type of account graduation.</param>
        public Account(int number, string ownerName, string ownerSurname, GradingType gradingType)
            : this(number, ownerName, ownerSurname, 0, 0, gradingType)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Account number.
        /// </summary>
        public int Number
        {
            get
            {
                return _number;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                _number = value;
            }
        }

        /// <summary>
        /// Name of account holder.
        /// </summary>
        public string OwnerName
        {
            get
            {
                return _ownerName;
            }

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _ownerName = value;
            }
        }

        /// <summary>
        /// Surname of account holder.
        /// </summary>
        public string OwnerSurname
        {
            get
            {
                return _ownerSurname;
            }

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _ownerSurname = value;
            }
        }

        /// <summary>
        /// The amount on the account.
        /// </summary>
        public double Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                _amount = value;
            }
        }

        /// <summary>
        /// Bonus points on the account.
        /// </summary>
        public int BonusPoints
        {
            get
            {
                return _bonusPoints;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                _bonusPoints = value;
            }
        }

        /// <summary>
        /// Type of account graduation.
        /// </summary>
        public GradingType TypeGrading
        {
            get
            {
                return _typeGrading;
            }

            private set
            {
                if (value == 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                _typeGrading = value;
            }
        }

        private AccountGrading Grading
        {
            get
            {
                return _grading;
            }

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _grading = value;
            }
        }

        #endregion Properties

        #region Overridden methods

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Account)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, otherwise false.</returns>
        public bool Equals(Account other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Number.Equals(other.Number)
                && OwnerName.Equals(other.OwnerName)
                && OwnerSurname.Equals(other.OwnerSurname)
                && Amount.Equals(other.Amount)
                && BonusPoints.Equals(other.BonusPoints)
                && TypeGrading.Equals(other.TypeGrading);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>The string of a data about account.</returns>
        public override string ToString()
        {
            return $"Number: {Number};\nOwnerName: {OwnerName};\nOwnerSurname: {OwnerSurname};\nAmount: {Amount};\nBonusPoints: {BonusPoints};\nTypeGrading: {TypeGrading}.";
        }

        /// <summary>
        /// Serves as the  hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int hashcode = Number.GetHashCode();
            hashcode = (11 * hashcode) + OwnerName.GetHashCode();
            hashcode = (11 * hashcode) + OwnerSurname.GetHashCode();
            hashcode = (11 * hashcode) + Amount.GetHashCode();
            hashcode = (11 * hashcode) + BonusPoints.GetHashCode();
            hashcode = (11 * hashcode) + TypeGrading.GetHashCode();
            return hashcode;
        }

        #endregion Overridden methods

        #region Public methods for account replenishment/debit from account

        /// <summary>
        /// Replenishes the account with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to replenish the account.</param>
        public void AccountReplenishment(double amount)
        {
            Amount = Amount + amount;
            BonusPoints = Grading.IncreaseBonusPoints(BonusPoints);
        }

        /// <summary>
        /// Removes the specified amount from the account.
        /// </summary>
        /// <param name="amount">Amount to withdraw from the account.</param>
        /// <exception cref="ArgumentException">Throw when the amount to withdraw 
        /// from the account more than the available account balance.</exception>
        public void WithdrawalsFromAccount(double amount)
        {
            if (amount > Amount)
            {
                throw new ArgumentException(nameof(amount));
            }

            Amount = Amount - amount;
            BonusPoints = Grading.ReductionBonusPoints(BonusPoints);
        }

        #endregion Public methods for account replenishment/debit from account
    }
}