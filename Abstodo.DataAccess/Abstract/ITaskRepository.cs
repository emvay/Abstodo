﻿using Abstodo.Entities.Concrete;

namespace Abstodo.DataAccess.Abstract
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
        Task<List<TaskEntity>> GetAllWithProjectNameAsync();
        //Here, you need to define the operations which are specific to Employee Entity

        //Task<IEnumerable<Task>> GetAllEmployeesAsync();
    }

}
