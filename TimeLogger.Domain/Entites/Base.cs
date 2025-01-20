namespace TimeLogger.Domain.Entites
{
    /// <summary>
    /// Represents the base class for entities with user association.
    /// </summary>
    public class Base
    {
        /// <summary>
        /// The unique identifier for the user.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The associated user entity.
        /// </summary>
        public User User { get; set; }
    }
}
