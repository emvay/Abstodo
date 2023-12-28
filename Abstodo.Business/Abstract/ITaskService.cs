using Task = Abstodo.Entities.Concrete.Task;

namespace Abstodo.Business.Abstract
{
    public interface ITaskService
    {
        void Add(Task task);
        void Delete(Task task);
        List<Task> GetAll();
        List<Task> GetTasksByUserID(int userID);
        List<Task> GetTasksByTitle(string Title);
        void Update(Task task);
    }
}
