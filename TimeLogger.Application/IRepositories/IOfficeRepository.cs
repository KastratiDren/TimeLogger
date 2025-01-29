namespace TimeLogger.Application.IRepositories
{
    public interface IOfficeRepository
    {
        Task<Office?> GetOfficeById(int id);
        Task<IEnumerable<Office>> GetAllOffices();
        Task CreateOffice(Office office);
    }
}
