namespace TimeLogger.Domain.Entites
{
    public class CheckIn : Base
    {
        public int Id { get; set; }
        public DateTime CheckInTime { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }

    }
}
