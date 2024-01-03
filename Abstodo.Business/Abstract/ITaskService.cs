

using Abstodo.Entities.Concrete;

namespace Abstodo.Business.Abstract
{
    public interface ITaskService
    {
        Task InsertAsync(TaskEntity taskEntity);
        Task DeleteAsync(TaskEntity taskEntity);
        Task<List<TaskEntity>> GetAllAsync();
        //Task<List<TaskEntity>> GetTasksByTaskIDAsync(int taskID);
        //Task<List<TaskEntity>> GetTasksByTitleAsync(string title);
        Task UpdateAsync(TaskEntity task);
    }
}
