using Abstodo.Entities.Concrete;
using Abstodo.Business.Abstract;
using Abstodo.DataAccess.Abstract;
using Abstodo.DataAccess.Concrete.EntityFramework;

namespace Abstodo.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly EfAbstodoContext _context;
        //Generic Reposiory, specify the Generic type T as Employee
        private readonly IGenericRepository<User> _repository;
        IUserRepository _userRepository;
        public UserManager(IGenericRepository<User> repository, IUserRepository userRepository, EfAbstodoContext context)
        {
            _repository = repository;
            _userRepository = userRepository;
            _context = context;
        }

        public async Task InsertAsync(User user)
        {
            //ValidationTool.Validate(new ProductValidator(), product);
            //await _repository.InsertAsync(taskEntity);
            ////Call SaveAsync to Insert the data into the database
            //await _repository.SaveAsync();

            await _userRepository.InsertAsync(user);
            await _userRepository.SaveAsync();
        }

        public async Task UpdateAsync(User user)
        {
            //    ValidationTool.Validate(new ProductValidator(), product);
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int ID)
        {
            await _userRepository.DeleteAsync(ID);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
            //return await _taskRepository.GetAllWithStatusAsync();
        }

        public async Task<User> GetByIdAsync(int ID)
        {
            return await _userRepository.GetByIdAsync(ID);
            //return await _taskRepository.GetAllWithStatusAsync();
        }

        public async Task<User> GetMatchingUserAsync(string username, string password)
        {
            return await _userRepository.GetMatchingUserAsync(username, password);
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
