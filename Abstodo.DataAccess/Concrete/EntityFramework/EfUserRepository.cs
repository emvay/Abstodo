using Abstodo.DataAccess.Abstract;
using Abstodo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Abstodo.DataAccess.Concrete.EntityFramework
{
    public class EfUserRepository : GenericRepository<User>, IUserRepository
    {
        protected readonly EfAbstodoContext _context;
        protected readonly DbSet<User> _dbSet;
        public EfUserRepository(EfAbstodoContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public async Task<User> GetMatchingUserAsync(string username, string password)
        {
            User user = await _context.Users
            .Where(t => (t.UserName == username) && (t.PasswordHash == password))
            .FirstOrDefaultAsync();
            return user;
        }
    }
}
