namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Provides method for id generate.
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// Generate new id.
        /// </summary>
        /// <returns>A new id.</returns>
        int GenerateId();
    }
}
