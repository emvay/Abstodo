﻿using Abstodo.DataAccess.Abstract;
using TaskEntity = Abstodo.Entities.Concrete.TaskEntity;

namespace Abstodo.DataAccess.Concrete.EntityFramework
{
    public class EfTaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {

        public EfTaskRepository(EfAbstodoContext context) : base(context) 
        {

        }


        //Returns all employees from the database.
        //public async Task<IEnumerable<Task>> GetAllEmployeesAsync()
        //{
        //    return await _context.Tasks.Include(e => e.Department).ToListAsync();
        //}

    }
}
