namespace TimeLogger.Application.IRepositories
{
    public interface ICheckOutRepository
    {
        Task<IEnumerable<CheckOut>> GetCheckOutsByUserId(string userId);
        Task CreateCheckOut(CheckOut checkOut);
    }
}
