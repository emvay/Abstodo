using Abstodo.DataAccess.Abstract;

namespace Abstodo.Entities.Concrete
{
    public class Project : IEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int StatusID { get; set; }

        // Navigation property
        public Status Status { get; set; }
    }
}
