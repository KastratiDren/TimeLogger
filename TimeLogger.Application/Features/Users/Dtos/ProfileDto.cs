namespace TimeLogger.Application.Features.Users.Dtos
{
    public class ProfileDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<CheckInDto> CheckIns { get; set; } = new();
        public List<CheckOutDto> CheckOuts { get; set; } = new();
        public List<RoomBookingDto>? RoomBookings { get; set; }
    }

    public class CheckInDto
    {
        public DateTime CheckInTime { get; set; }
    }

    public class CheckOutDto
    {
        public DateTime CheckOutTime { get; set; }
    }

    public class RoomBookingDto
    {
        public string RoomName { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
    }
}
