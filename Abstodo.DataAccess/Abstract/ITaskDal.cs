using Task = Abstodo.Entities.Concrete.Task;

namespace Abstodo.DataAccess.Abstract
{
    public interface ITaskDal : IEntityRepository<Task>
    {

    }
}
