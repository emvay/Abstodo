using Abstodo.Entities.Concrete;

namespace Abstodo.Business.Abstract
{
    public interface IUserService
    {
        Task InsertAsync(User user);
        Task DeleteAsync(int ID);
        Task<List<User>> GetAllAsync();
        //Task<List<User>> GetAllWithStatusAsync();
        Task<User> GetByIdAsync(int ID);

        Task<User> GetMatchingUserAsync(string username, string password);
        //Task<List<User>> GetTasksByTitleAsync(string title);
        Task UpdateAsync(User user);
    }
}
