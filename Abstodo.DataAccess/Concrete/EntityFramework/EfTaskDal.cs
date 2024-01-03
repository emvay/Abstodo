using Abstodo.DataAccess.Abstract;
using Task = Abstodo.Entities.Concrete.Task;

namespace Abstodo.DataAccess.Concrete.EntityFramework
{
    public class EfTaskDal : EfEntityRepositoryBase<Task, AbstodoContext>, ITaskDal
    {

        //public List<Task> GetAllTasks()
        //{
        //    // You can add any business logic or filtering here if needed
        //    return _taskDal.GetAll();
        //}
    }
}
