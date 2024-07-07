using Abstodo.DataAccess.Abstract;
using Abstodo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Abstodo.DataAccess.Concrete.EntityFramework
{
    public class EfProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        protected readonly EfAbstodoContext _context;
        protected readonly DbSet<Project> _dbSet;
        public EfProjectRepository(EfAbstodoContext context) : base(context) 
        {
            _context = context;
            _dbSet = context.Set<Project>();
        }

        public async Task<int> GetAllCompletedProjectCount(int userId)
        {
            return _context.Projects.Count(x => x.StatusID == (int)StatusEnum.Done);
        }

        public async Task<int> GetAllOpenProjectCount(int userId)
        {
            return _context.Projects.Count(x => x.StatusID == (int)StatusEnum.InProgress || x.StatusID == (int)StatusEnum.ToDo);
        }



        //Returns all employees from the database.
        //public async Task<IEnumerable<Task>> GetAllEmployeesAsync()
        //{
        //    return await _context.Tasks.Include(e => e.Department).ToListAsync();
        //}

    }
}
