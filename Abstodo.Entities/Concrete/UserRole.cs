using Abstodo.DataAccess.Abstract;

namespace Abstodo.Entities.Concrete
{
    public class UserRole : IEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        // Navigation property for users
        public ICollection<User> Users { get; set; }
    }
}
