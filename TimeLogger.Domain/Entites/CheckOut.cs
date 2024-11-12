namespace TimeLogger.Domain.Entites
{
    public class CheckOut : Base
    {
        public int Id { get; set; }
        public DateTime CheckOutTime { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
