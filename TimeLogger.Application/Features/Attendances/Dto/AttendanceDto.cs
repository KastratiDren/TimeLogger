namespace TimeLogger.Application.Features.Attendances.Dto
{
    public class AttendanceDto
    {
        public DateOnly Date {  get; set; }
        public string UserId { get; set; }
        public int OfficeId { get; set; }
    }
}
