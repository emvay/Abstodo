namespace Abstodo.Entities.Concrete
{
    public class UserInRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public UserRole UserRole { get; set; }
    }
}
