namespace TimeLogger.Infrastructure.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly AppDbContext _context;

        public OfficeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateOffice(Office office)
        {
            await _context.Offices.AddAsync(office);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Office>> GetAllOffices()
        {
            var offices = await _context.Offices
                .Include(o => o.Rooms)
                .Include(o => o.CheckIns)
                .Include(o => o.CheckOuts)
                .ToListAsync();

            return offices;
        }

        public async Task<Office?> GetOfficeById(int id)
        {
            var office = await _context.Offices
                .Include(o => o.Rooms)
                .Include(o => o.CheckIns)
                .Include(o => o.CheckOuts)
                .FirstOrDefaultAsync(o => o.Id == id);

            return office;
        }
    }
}
