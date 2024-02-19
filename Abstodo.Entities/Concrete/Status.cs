using Abstodo.DataAccess.Abstract;

namespace Abstodo.Entities.Concrete
{
    public enum StatusEnum
    {
        ToDo = 1,
        InProgress = 2,
        Done = 3,
        Removed = 4
    }

    public class Status : IEntity
    {
        public int ID { get; set; }
        public StatusEnum Name { get; set; }
    }
}
