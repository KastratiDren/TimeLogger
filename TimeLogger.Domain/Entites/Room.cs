namespace TimeLogger.Domain.Entites
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
