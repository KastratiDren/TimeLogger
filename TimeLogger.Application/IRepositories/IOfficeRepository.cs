using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface IOfficeRepository
    {
        Task<Office?> GetByIdAsync(int id);
        Task<IEnumerable<Office>> GetAllAsync();
        Task AddAsync(Office office);
        Task UpdateAsync(Office office);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsValidOfficeAsync(int officeId);
    }
}
