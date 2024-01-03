using Abstodo.DataAccess.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Abstodo.Entities.Concrete
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Navigation property for tasks
        public ICollection<TaskEntity> Tasks { get; set; }

        // Navigation property for roles (if using roles)
        //public ICollection<UserRole> UserRoles { get; set; }
    }
}
