using Abstodo.Entities.Concrete;
using Abstodo.Business.Abstract;
using Abstodo.DataAccess.Abstract;
using Abstodo.DataAccess.Concrete.EntityFramework;

namespace Abstodo.Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        private readonly EfAbstodoContext _context;
        //Generic Reposiory, specify the Generic type T as Employee
        private readonly IGenericRepository<Project> _repository;
        IProjectRepository _projectRepository;
        public ProjectManager(IGenericRepository<Project> repository, IProjectRepository projectRepository, EfAbstodoContext context)
        {
            _repository = repository;
            _projectRepository = projectRepository;
            _context = context;
        }

        public async Task InsertAsync(Project project)
        {
            //ValidationTool.Validate(new ProductValidator(), product);
            await _repository.InsertAsync(project);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            //    ValidationTool.Validate(new ProductValidator(), product);
            await _projectRepository.UpdateAsync(project);
        }

        public async Task DeleteAsync(Project project)
        {
            _projectRepository.DeleteAsync(project);
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        //public async Task<List<Project>> GetTasksByTaskIDAsync(int taskID)
        //{
        //    await _projectRepository.GetAllAsync(p=>p.UserID == userID);
        //}

        //public async Task<List<Project>> GetTasksByTitleAsync(string title)
        //{
        //    await _projectRepository.GetAllAsync(p => p.Title.ToLower().Contains(title.ToLower()));
        //}


    }
}
