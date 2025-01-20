namespace TimeLogger.Infrastructure.Repositories
{
    public class CheckOutRepository : ICheckOutRepository
    {
        private readonly AppDbContext _context;
        public CheckOutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CheckOut checkOut)
        {
            await _context.CheckOuts.AddAsync(checkOut);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var checkOut = await _context.CheckOuts.FindAsync(id);
            if (checkOut == null)
                return false;

            _context.CheckOuts.Remove(checkOut);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CheckOut?> GetByIdAsync(int id)
        {
            return await _context.CheckOuts
                .Include(c => c.Office)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CheckOut>> GetAllAsync()
        {
            return await _context.CheckOuts
                .Include(c => c.Office)
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<CheckOut>> GetByUserIdAsync(string userId)
        {
            return await _context.CheckOuts
                .Where(c => c.UserId == userId)
                .Include(c => c.Office)
                .OrderByDescending(c => c.CheckOutTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<CheckOut>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.CheckOuts
                .Where(c => c.CheckOutTime >= startDate && c.CheckOutTime <= endDate)
                .Include(c => c.Office)
                .Include(c => c.User)
                .OrderByDescending(c => c.CheckOutTime)
                .ToListAsync();
        }
    }
}
