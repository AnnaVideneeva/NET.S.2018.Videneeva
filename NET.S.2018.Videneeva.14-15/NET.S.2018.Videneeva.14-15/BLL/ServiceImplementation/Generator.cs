using BLL.Interface.Interfaces;
using System;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Provides method for id generate.
    /// </summary>
    public class Generator : IGenerator
    {
        #region Fields

        private int id;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Inintializes a new instance.
        /// </summary>
        public Generator()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Inintializes a new instance.
        /// </summary>
        public Generator(int id)
        {
            this.Id = id;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets and sets Id.
        /// </summary>
        private int Id
        {
            get => this.id;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id is not be negative.", nameof(value));
                }

                this.id = value;
            }
        }

        #endregion Properties

        #region IGenerator implementation

        /// <summary>
        /// Generate new id.
        /// </summary>
        /// <returns>A new id.</returns>
        public int GenerateId()
        {
            return Id++;
        }

        #endregion  IGenerator implementation
    }
}