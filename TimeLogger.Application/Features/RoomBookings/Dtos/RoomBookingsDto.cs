namespace TimeLogger.Application.Features.RoomBookings.Dtos
{
    public class RoomBookingsDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RoomId { get; set; }
        public string UserId { get; set; }
    }
}
