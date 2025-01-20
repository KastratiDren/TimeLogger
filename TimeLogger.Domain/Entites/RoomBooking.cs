namespace TimeLogger.Domain.Entites
{
    /// <summary>
    /// Represents a room booking, including the start and end times, and associated room.
    /// </summary>
    public class RoomBooking : Base
    {
        /// <summary>
        /// The unique identifier for the room booking.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The start time of the room booking.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The end time of the room booking.
        /// </summary>
        public DateTime EndTime { get; set; }


        /// <summary>
        /// The unique identifier for the room associated with the booking.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// The room entity that is booked.
        /// </summary>
        public Room Room { get; set; }
    }
}
