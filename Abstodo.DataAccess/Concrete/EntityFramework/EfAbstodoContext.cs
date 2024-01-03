using Abstodo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Abstodo.DataAccess.Concrete.EntityFramework
{
    public class EfAbstodoContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    try
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=DESKTOP-MSRGA6I\SQLEXPRESS;Database=aAbstodoDB;Integrated Security=True;");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or print it to the console
        //        Console.WriteLine(ex.ToString());
        //        throw;  // Rethrow the exception to avoid silent failures
        //    }

        //}

        public EfAbstodoContext(DbContextOptions<EfAbstodoContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TaskEntity>().HasKey(t => t.ID);
            //modelBuilder.Entity<Task>().HasNoKey();
            // Other configurations...
        }

        public DbSet<User> Users { get; set; }

        //public DbSet<Project> Projects { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        //public DbSet<TaskDetail> TaskDetails { get; set; }
        //public DbSet<Status> Statuses { get; set; }

        //public DbSet<Log> Logs { get; set; }
    }
}
