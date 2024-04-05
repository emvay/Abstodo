using Abstodo.Entities.Concrete;

namespace Abstodo.DataAccess.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetMatchingUserAsync(string username, string password);
    }
}
