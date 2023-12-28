using Abstodo.DataAccess.Abstract;
using Task = Abstodo.Entities.Concrete.Task;

namespace Abstodo.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Task, AbstodoContext>, ITaskDal
    {

    }
}
