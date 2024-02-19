using Abstodo.DataAccess.Abstract;
using Abstodo.Entities.Concrete;

namespace Abstodo.DataAccess.Concrete.EntityFramework
{
    public class EfProjectRepository : GenericRepository<Project>, IProjectRepository
    {

        public EfProjectRepository(EfAbstodoContext context) : base(context) 
        {

        }


        //Returns all employees from the database.
        //public async Task<IEnumerable<Task>> GetAllEmployeesAsync()
        //{
        //    return await _context.Tasks.Include(e => e.Department).ToListAsync();
        //}

    }
}
