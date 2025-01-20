namespace TimeLogger.Domain.Entites
{
    /// <summary>
    /// Represents the attendance record for a user in an office.
    /// </summary>
    public class Attendance
    {
        /// <summary>
        /// The name of the office where the user checked in.
        /// </summary>
        public string OfficeName { get; set; }

        /// <summary>
        /// The time when the user checked in.
        /// </summary>
        public DateTime CheckInTime { get; set; }

        /// <summary>
        /// The time when the user checked out. Nullable if the user hasn't checked out yet.
        /// </summary>
        public DateTime? CheckOutTime { get; set; }

        /// <summary>
        /// The username associated with the attendance record.
        /// </summary>
        public string UserName { get; set; }
    }
}
