namespace TimeLogger.Infrastructure.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly AppDbContext _context;

        public OfficeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Office office)
        {
            await _context.Offices.AddAsync(office);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var office = await _context.Offices.FindAsync(id);
            if (office == null)
                return false;

            _context.Offices.Remove(office);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Office>> GetAllAsync()
        {
            return await _context.Offices
                .Include(o => o.Rooms)
                .Include(o => o.CheckIns)
                .Include(o => o.CheckOuts)
                .ToListAsync();

        }

        public async Task<Office?> GetByIdAsync(int id)
        {
            return await _context.Offices
                .Include(o => o.Rooms)
                .Include(o => o.CheckIns)
                .Include(o => o.CheckOuts)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<bool> IsValidOfficeAsync(int officeId)
        {
            return await _context.Offices.AnyAsync(o => o.Id == officeId);
        }

        public async Task UpdateAsync(Office office)
        {
            _context.Offices.Update(office);
            await _context.SaveChangesAsync();
        }
    }
}
