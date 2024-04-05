using Abstodo.Entities.Concrete;
using Abstodo.WebUI.Models;
using AutoMapper;

namespace Abstodo.WebUI.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();

            CreateMap<TaskModel, TaskEntity>();
            CreateMap<TaskEntity, TaskModel>();

            CreateMap<ProjectModel, Project>();
            CreateMap<Project, ProjectModel>();
        }
    }
}
