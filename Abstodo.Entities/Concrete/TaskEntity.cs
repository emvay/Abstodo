using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Abstodo.Entities.Concrete
{
    public class TaskEntity/* : IEntity*/
    {
        public TaskEntity()
        {
            CreatedAt = DateTime.UtcNow; // or DateTime.Now if you want local time
        }
        [Key]
        public int ID { get; set; }
        //public string Title { get; set; }
        public string? Description { get; set; }
        public int PriorityID { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProjectID { get; set; }
        //public string? ProjectName { get; set; }
        public int UserID { get; set; }
        public int StatusID { get; set; }

        //Navigation properties
        public Priority Priority { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }
        public Status Status { get; set; }
        //public List<TaskDetail>? TaskDetails { get; set; }
    }
}
