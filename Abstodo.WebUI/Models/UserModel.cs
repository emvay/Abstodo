using System.ComponentModel.DataAnnotations;

namespace Abstodo.WebUI.Models
{
    public class UserModel
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Navigation property for tasks
        public ICollection<TaskModel> Tasks { get; set; }

        // Navigation property for roles (if using roles)
        //public ICollection<UserRole> UserRoles { get; set; }
    }
}
