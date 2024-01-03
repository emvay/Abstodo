using Abstodo.DataAccess.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Abstodo.Entities.Concrete
{
    public class Task : IEntity
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        //public string Priority { get; set; }
        //public DateTime? DueDate { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public int ProjectID { get; set; }
        //public int UserID { get; set; }
        //public int StatusID { get; set; }

        // Navigation properties
        //public Project Project { get; set; }
        //public User User { get; set; }
        //public Status Status { get; set; }
        //public List<TaskDetail>? TaskDetails { get; set; }
    }
}
