namespace TimeLogger.Application.Features.Users.Dtos
{
    public class ProfileDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<UserCheckInDto> CheckIns { get; set; } = new();
        public List<UserCheckOutDto> CheckOuts { get; set; } = new();
        public List<UserRoomBookingDto>? RoomBookings { get; set; }
    }

    public class UserCheckInDto
    {
        public DateTime CheckInTime { get; set; }
    }

    public class UserCheckOutDto
    {
        public DateTime CheckOutTime { get; set; }
    }

    public class UserRoomBookingDto
    {
        public string RoomName { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
    }
}
