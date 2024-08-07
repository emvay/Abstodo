﻿using Abstodo.Entities.Concrete;

namespace Abstodo.Business.Abstract
{
    public interface ITaskService
    {
        Task InsertAsync(TaskEntity taskEntity);
        Task DeleteAsync(int ID);
        Task CompleteTaskAsync(int ID); 
        Task<List<TaskEntity>> GetAllAsync();
        Task<TaskEntity> GetByIdAsync(int ID);
        Task<List<TaskEntity>> GetTasksByProjectID(int ID);
        Task<int> GetAllCompletedTaskCount(int userId);
        Task<int> GetAllOpenTaskCount(int userId);
        //Task<List<TaskEntity>> GetAllWithStatusAsync();
        //Task<List<TaskEntity>> GetTasksByTaskIDAsync(int taskID);
        //Task<List<TaskEntity>> GetTasksByTitleAsync(string title);
        Task UpdateAsync(TaskEntity task);
    }
}
