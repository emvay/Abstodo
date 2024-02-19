using Abstodo.Entities.Concrete;

namespace Abstodo.Business.Abstract
{
    public interface IProjectService
    {
        Task InsertAsync(Project project);
        Task DeleteAsync(Project project);
        Task<List<Project>> GetAllAsync();
        //Task<List<TaskEntity>> GetAllWithStatusAsync();
        //Task<List<TaskEntity>> GetTasksByTaskIDAsync(int taskID);
        //Task<List<TaskEntity>> GetTasksByTitleAsync(string title);
        Task UpdateAsync(Project project);
    }
}
