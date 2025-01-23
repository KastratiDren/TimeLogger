namespace TimeLogger.Infrastructure.Repositories
{
    public class CheckOutRepository : ICheckOutRepository
    {
        private readonly AppDbContext _context;
        public CheckOutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCheckOut(CheckOut checkOut)
        {
            await _context.CheckOuts.AddAsync(checkOut);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CheckOut>> GetCheckOutsByUserId(string userId)
        {
            return await _context.CheckOuts
                .Where(c => c.UserId == userId)
                .Include(c => c.Office)
                .OrderByDescending(c => c.CheckOutTime)
                .ToListAsync();
        }
    }
}
