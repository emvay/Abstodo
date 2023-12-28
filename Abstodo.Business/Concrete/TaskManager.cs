using Task = Abstodo.Entities.Concrete.Task;
using Abstodo.Business.Abstract;
using Abstodo.DataAccess.Abstract;

namespace Abstodo.Business.Concrete
{
    public class TaskManager : ITaskService
    {
        ITaskDal _taskDal;
        public TaskManager(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }

        public void Add(Task task)
        {
            //ValidationTool.Validate(new ProductValidator(), product);
            _taskDal.Add(task);
        }

        public void Update(Task task)
        {
            //    ValidationTool.Validate(new ProductValidator(), product);
            _taskDal.Update(task);
        }

        public void Delete(Task task)
        {
            _taskDal.Delete(task);
        }

        public List<Task> GetAll()
        {
            return _taskDal.GetAll();
        }

        public List<Task> GetTasksByUserID(int userID)
        {
            return _taskDal.GetAll(p=>p.UserId == userID);
        }

        public List<Task> GetTasksByTitle(string title)
        {
            return _taskDal.GetAll(p => p.Title.ToLower().Contains(title.ToLower()));
        }


    }
}
