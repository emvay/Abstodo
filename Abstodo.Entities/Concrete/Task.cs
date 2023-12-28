using Abstodo.DataAccess.Abstract;

namespace Abstodo.Entities.Concrete
{
    public class Task : IEntity
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }

        // Foreign key for the associated user
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
