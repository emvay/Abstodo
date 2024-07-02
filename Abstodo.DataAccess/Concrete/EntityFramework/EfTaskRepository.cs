using Abstodo.DataAccess.Abstract;
using Abstodo.Entities.Concrete;
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

        public async Task CompleteTaskAsync(int ID)
        {
            await _dbSet.Where(t => t.ID==ID).ExecuteUpdateAsync(b => b.SetProperty(u => u.StatusID, (int)StatusEnum.Done));
        }

        public async Task<List<TaskEntity>> GetTasksByProjectID(int ID)
        {
            //var tasks2= await _dbSet.ToListAsync();
            var tasks = await _context.Tasks
            .Include(t => t.Project).Where(t=> t.ProjectID == ID).Select(t => new TaskEntity
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
