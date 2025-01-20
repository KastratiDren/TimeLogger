namespace TimeLogger.Domain.Entites
{
    /// <summary>
    /// Represents an office with associated rooms and check-in/check-out records.
    /// </summary>
    public class Office
    {
        /// <summary>
        /// The unique identifier for the office.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the office.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// The collection of rooms associated with the office.
        /// </summary>
        public ICollection<Room>? Rooms { get; set; }

        /// <summary>
        /// The collection of check-in records for the office.
        /// </summary>
        public ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();

        /// <summary>
        /// The collection of check-out records for the office.
        /// </summary>
        public ICollection<CheckOut> CheckOuts { get; set; } = new List<CheckOut>();
    }
}
