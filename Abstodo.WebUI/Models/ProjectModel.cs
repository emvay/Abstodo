using Abstodo.Entities.Concrete;

namespace Abstodo.WebUI.Models
{
    public class ProjectModel/* : IEntity*/
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int StatusID { get; set; }
    }
}
