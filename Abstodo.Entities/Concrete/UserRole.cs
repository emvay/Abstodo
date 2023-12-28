namespace Abstodo.Entities.Concrete
{
    public class UserRole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        // Navigation property for users
        public ICollection<User> Users { get; set; }
    }
}
