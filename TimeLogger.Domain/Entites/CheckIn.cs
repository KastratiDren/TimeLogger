namespace TimeLogger.Domain.Entites
{
    /// <summary>
    /// Represents the check-in record of a specific user.
    /// </summary>
    public class CheckIn : Base
    {
        /// <summary>
        /// The unique identifier for the check-in record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The time when the user checked in.
        /// </summary>
        public DateTime CheckInTime { get; set; }


        /// <summary>
        /// The unique identifier for the office associated with the check-in.
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// The office entity where the user checked in.
        /// </summary>
        public Office Office { get; set; }

    }
}
