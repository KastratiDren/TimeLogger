namespace TimeLogger.Domain.Entites
{
    /// <summary>
    /// Represents a room within an office, including associated room bookings.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// The unique identifier for the room.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the room.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// The unique identifier for the office where the room is located.
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// The office entity where the room is located.
        /// </summary>
        public Office Office { get; set; }

        /// <summary>
        /// The collection of room bookings for this room.
        /// </summary>
        public ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
