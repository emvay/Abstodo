using Abstodo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Task = Abstodo.Entities.Concrete.Task;

namespace Abstodo.DataAccess.Concrete.EntityFramework
{
    public class AbstodoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            try
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-MSRGA6I\SQLEXPRESS;Database=aAbstodoDB;Integrated Security=True;");
            }
            catch (Exception ex)
            {
                // Log the exception or print it to the console
                Console.WriteLine(ex.ToString());
                throw;  // Rethrow the exception to avoid silent failures
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Task>().HasNoKey();
            // Other configurations...
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskDetail> TaskDetails { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public DbSet<Log> Logs { get; set; }
    }
}
