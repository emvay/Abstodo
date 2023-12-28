namespace Abstodo.Entities.Concrete
{
    public class Log
    {
        public int LogId { get; set; }
        public int? UserId { get; set; }
        public DateTime LogDate { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }

        // Navigation property for the associated user
        public User User { get; set; }
    }
}
