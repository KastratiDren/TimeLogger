using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface IOfficeRepository
    {
        Task<Office?> GetOfficeById(int id);
        Task<IEnumerable<Office>> GetAllOffices();
        Task CreateOffice(Office office);
        Task UpdateOffice(Office office);
        Task<bool> DeleteOffice(int id);
        Task<bool> IsOfficeValid(int officeId);
    }
}
