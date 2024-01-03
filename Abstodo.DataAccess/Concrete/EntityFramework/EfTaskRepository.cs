using Abstodo.DataAccess.Abstract;
using Abstodo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEntity = Abstodo.Entities.Concrete.TaskEntity;

namespace Abstodo.DataAccess.Concrete.EntityFramework
{
    public class EfTaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {
        public EfTaskRepository(EfAbstodoContext context) : base(context) { }
        //Returns all employees from the database.
        //public async Task<IEnumerable<Task>> GetAllEmployeesAsync()
        //{
        //    return await _context.Tasks.Include(e => e.Department).ToListAsync();
        //}

    }
}
