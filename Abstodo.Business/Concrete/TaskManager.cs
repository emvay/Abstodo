using Abstodo.Entities.Concrete;
using Abstodo.Business.Abstract;
using Abstodo.DataAccess.Abstract;
using Abstodo.DataAccess.Concrete.EntityFramework;

namespace Abstodo.Business.Concrete
{
    public class TaskManager : ITaskService
    {
        private readonly EfAbstodoContext _context;
        //Generic Reposiory, specify the Generic type T as Employee
        private readonly IGenericRepository<TaskEntity> _repository;
        ITaskRepository _taskRepository;
        public TaskManager(IGenericRepository<TaskEntity> repository, ITaskRepository taskRepository, EfAbstodoContext context)
        {
            _repository = repository;
            _taskRepository = taskRepository;
            _context = context;
        }

        public async Task InsertAsync(TaskEntity taskEntity)
        {
            //ValidationTool.Validate(new ProductValidator(), product);
            //await _repository.InsertAsync(taskEntity);
            ////Call SaveAsync to Insert the data into the database
            //await _repository.SaveAsync();

            await _taskRepository.InsertAsync(taskEntity);
            await _taskRepository.SaveAsync();
        }

        public async Task UpdateAsync(TaskEntity taskEntity)
        {
            //    ValidationTool.Validate(new ProductValidator(), product);
            await _taskRepository.UpdateAsync(taskEntity);
        }

        public async Task DeleteAsync(int ID)
        {
            await _taskRepository.DeleteAsync(ID);
        }

        public async Task<List<TaskEntity>> GetAllAsync()
        {
            return await _taskRepository.GetAllAsync();
            //return await _taskRepository.GetAllWithStatusAsync();
        }
        public async Task<List<TaskEntity>> GetAllWithProjectNameAsync()
        {
            return await _taskRepository.GetAllWithProjectNameAsync();
            //return await _taskRepository.GetAllWithStatusAsync();
        }

        public async Task<TaskEntity> GetByIdAsync(int ID)
        {
            return await _taskRepository.GetByIdAsync(ID);
            //return await _taskRepository.GetAllWithStatusAsync();
        }
        //public async Task<List<TaskEntity>> GetTasksByTaskIDAsync(int taskID)
        //{
        //    await _taskRepository.GetAllAsync(p=>p.UserID == userID);
        //}

        //public async Task<List<TaskEntity>> GetTasksByTitleAsync(string title)
        //{
        //    await _taskRepository.GetAllAsync(p => p.Title.ToLower().Contains(title.ToLower()));
        //}


    }
}
