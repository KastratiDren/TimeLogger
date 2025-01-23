namespace TimeLogger.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _context.Users
                .Include(u => u.CheckIns)
                .Include(u => u.CheckOuts)
                .Include(u => u.RoomBookings)
                .ToListAsync();

            return users;
        }

        public async Task<User?> GetUserById(string userId)
        {
            var user = await _context.Users
                .Include(u => u.CheckIns)
                .Include(u => u.CheckOuts)
                .Include(u => u.RoomBookings)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
