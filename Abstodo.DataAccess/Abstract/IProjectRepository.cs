using Abstodo.Entities.Concrete;

namespace Abstodo.DataAccess.Abstract
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<int> GetAllCompletedProjectCount(int userId);

        Task<int> GetAllOpenProjectCount(int userId);
        //Here, you need to define the operations which are specific to Employee Entity

        //Task<IEnumerable<Task>> GetAllEmployeesAsync();
    }

}
