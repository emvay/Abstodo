using Abstodo.Entities.Concrete;

namespace Abstodo.DataAccess.Abstract
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        //Here, you need to define the operations which are specific to Employee Entity

        //Task<IEnumerable<Task>> GetAllEmployeesAsync();
    }

}
