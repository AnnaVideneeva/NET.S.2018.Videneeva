using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Provides method for id generate.
    /// </summary>
    public class Generator : IGenerator
    {
        #region Constructor

        /// <summary>
        /// Inintializes a new instance.
        /// </summary>
        public Generator()
        {
            Id = 0;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets and sets Id.
        /// </summary>
        private int Id { get; set; }

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