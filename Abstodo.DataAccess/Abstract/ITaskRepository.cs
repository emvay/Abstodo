using TaskEntity = Abstodo.Entities.Concrete.TaskEntity;

namespace Abstodo.DataAccess.Abstract
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
        //Here, you need to define the operations which are specific to Employee Entity

        //Task<IEnumerable<Task>> GetAllEmployeesAsync();
    }

}
