using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Provides properties and methods for working with the account.
    /// </summary>
    public class BankAccount
    {
        #region Fields

        private int id;
        private string ownerName;
        private string ownerSurname;
        private double amount;
        private int bonusPoints;
        private GradingType typeGrading;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inintializes a new instance.
        /// </summary>
        /// <param name="id">A bank account id.</param>
        /// <param name="ownerName">Name of bank account holder.</param>
        /// <param name="ownerSurname">Surname of bank account holder.</param>
        /// <param name="amount">The amount on the bank account.</param>
        /// <param name="bonusPoints">Bonus points on the bank account.</param>
        /// <param name="gradingType">Type of bank account graduation.</param>
        public BankAccount(int id, string ownerName, string ownerSurname, double amount, int bonusPoints, GradingType gradingType)
        {
            this.Id = id;
            this.OwnerName = ownerName;
            this.OwnerSurname = ownerSurname;
            this.Amount = amount;
            this.BonusPoints = bonusPoints;
            this.TypeGrading = gradingType;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// A bank account id.
        /// </summary>
        public int Id
        {
            get => this.id;
 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                this.id = value;
            }
        }

        /// <summary>
        /// Name of bank account holder.
        /// </summary>
        public string OwnerName
        {
            get => this.ownerName;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.ownerName = value;
            }
        }

        /// <summary>
        /// Surname of bank account holder.
        /// </summary>
        public string OwnerSurname
        {
            get => this.ownerSurname;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.ownerSurname = value;
            }
        }

        /// <summary>
        /// The amount on the bank account.
        /// </summary>
        public double Amount
        {
            get => this.amount;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                this.amount = value;
            }
        }

        /// <summary>
        /// Bonus points on the bank account.
        /// </summary>
        public int BonusPoints
        {
            get => this.bonusPoints;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                this.bonusPoints = value;
            }
        }

        /// <summary>
        /// Type of bank account graduation.
        /// </summary>
        public GradingType TypeGrading
        {
            get => this.typeGrading;

            set
            {
                if (value == 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                this.typeGrading = value;
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
            if (ReferenceEquals(null, obj))
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

            return this.Equals((BankAccount)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, otherwise false.</returns>
        public bool Equals(BankAccount other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Id.Equals(other.id)
                && this.OwnerName.Equals(other.OwnerName)
                && this.OwnerSurname.Equals(other.OwnerSurname)
                && this.Amount.Equals(other.Amount)
                && this.BonusPoints.Equals(other.BonusPoints)
                && this.TypeGrading.Equals(other.TypeGrading);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>The string of a data about account.</returns>
        public override string ToString()
        {
            return $"Id: {Id};\nOwnerName: {OwnerName};\nOwnerSurname: {OwnerSurname};\nAmount: {Amount};\nBonusPoints: {BonusPoints};\nTypeGrading: {TypeGrading}.";
        }

        /// <summary>
        /// Serves as the  hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int hashcode = this.Id.GetHashCode();
            hashcode = (11 * hashcode) + this.OwnerName.GetHashCode();
            hashcode = (11 * hashcode) + this.OwnerSurname.GetHashCode();
            hashcode = (11 * hashcode) + this.Amount.GetHashCode();
            hashcode = (11 * hashcode) + this.BonusPoints.GetHashCode();
            hashcode = (11 * hashcode) + this.TypeGrading.GetHashCode();
            return hashcode;
        }

        #endregion Overridden methods  
    }
}