using Abstodo.DataAccess.Abstract;

namespace Abstodo.Entities.Concrete
{
    public class UserInRole : IEntity
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public UserRole UserRole { get; set; }
    }
}
