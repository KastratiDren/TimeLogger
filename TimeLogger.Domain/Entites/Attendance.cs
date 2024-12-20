namespace TimeLogger.Domain.Entites
{
    public class Attendance
    {
        public string OfficeName { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string UserName { get; set; }
    }
}
