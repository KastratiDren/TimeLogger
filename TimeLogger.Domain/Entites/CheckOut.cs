namespace TimeLogger.Domain.Entites
{
    /// <summary>
    /// Represents the check-out record of a specific user.
    /// </summary>
    public class CheckOut : Base
    {
        /// <summary>
        /// The unique identifier for the check-out record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The time when the user checked out.
        /// </summary>
        public DateTime CheckOutTime { get; set; }


        /// <summary>
        /// The unique identifier for the office associated with the check-out.
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// The office entity where the user checked out.
        /// </summary>
        public Office Office { get; set; }
    }
}
