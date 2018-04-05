using System;
using System.Collections.Generic;

namespace Sorting
{
    class DelegateAdapter : IComparer<int[]>
    {
        #region Fields

        private Comparison<int[]> _delegateComparator;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Full constructor.
        /// </summary>
        /// <param name="delegateComparator">Delegate that represents the method that compares two objects of the same type.</param>
        public DelegateAdapter(Comparison<int[]> delegateComparator)
        {
            DelegateComparator = delegateComparator;
        }

        #endregion Constructor

        #region Property

        /// <summary>
        /// Delegate that represents the method that compares two objects of the same type.
        /// </summary>
        public Comparison<int[]> DelegateComparator
        {
            get
            {
                return _delegateComparator;
            }
            private set
            {
                Validator.ValidateComparison(value);
                _delegateComparator = value;
            }
        }

        #endregion Property

        #region IComparer<int[]> interface implementation

        /// <summary>
        /// Compares two objects of the same type.
        /// </summary>
        /// <param name="lhs">The first object to compare.</param>
        /// <param name="rhs">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            return DelegateComparator(lhs, rhs);
        }

        #endregion IComparer<int[]> interface implementation
    }
}
