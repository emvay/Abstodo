using Abstodo.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using TaskEntity = Abstodo.Entities.Concrete.TaskEntity;

namespace Abstodo.DataAccess.Concrete.EntityFramework
{
    public class EfTaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {
        protected readonly EfAbstodoContext _context;
        protected readonly DbSet<TaskEntity> _dbSet;
        public EfTaskRepository(EfAbstodoContext context) : base(context) 
        {
            _context = context;
            _dbSet = context.Set<TaskEntity>();
        }
        public async Task<List<TaskEntity>> GetAllWithProjectNameAsync()
        {
            //var tasks2= await _dbSet.ToListAsync();
            var tasks = await _context.Tasks
            .Include(t => t.Project).Select(t => new TaskEntity
            {
                ID = t.ID,
                Description = t.Description,
                ProjectID = t.ProjectID,
                CreatedAt = t.CreatedAt,
                DueDate = t.DueDate,
                PriorityID = t.PriorityID,
                StatusID = t.StatusID,
                UserID = t.UserID,
                Project = t.Project,
                //ProjectName = t.Project.Title // Assuming Project has a Name property
            })
            .ToListAsync();
            return tasks;
        }

        //Returns all employees from the database.
        //public async Task<IEnumerable<Task>> GetAllEmployeesAsync()
        //{
        //    return await _context.Tasks.Include(e => e.Department).ToListAsync();
        //}

    }
}
