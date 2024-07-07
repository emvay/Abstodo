using Abstodo.Entities.Concrete;

namespace Abstodo.DataAccess.Abstract
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
        Task<List<TaskEntity>> GetTasksByProjectID(int ID);

        Task CompleteTaskAsync(int Id);

        Task<int> GetAllCompletedTaskCount(int userId);

        Task<int> GetAllOpenTaskCount(int userId);
        //Here, you need to define the operations which are specific to Employee Entity

        //Task<IEnumerable<Task>> GetAllEmployeesAsync();
    }

}
