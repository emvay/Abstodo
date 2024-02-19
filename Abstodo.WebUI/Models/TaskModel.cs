using Abstodo.Entities.Concrete;
using System.Data.SqlTypes;

namespace Abstodo.WebUI.Models
{
    public class TaskModel/* : IEntity*/
    {
        public TaskModel()
        {
            CreatedAt = DateTime.UtcNow; // or DateTime.Now if you want local time
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int PriorityID { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public int StatusID { get; set; }

        //Navigation properties
        //public Priority priority { get; set; }
        //public Project Project { get; set; }
        //public User User { get; set; }
        //public Status Status { get; set; }
        //public List<TaskDetail>? TaskDetails { get; set; }
    }
}
