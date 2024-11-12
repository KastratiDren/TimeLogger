namespace TimeLogger.Domain.Entites
{
    public class RoomBooking : Base
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
