using Abstodo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Task = Abstodo.Entities.Concrete.Task;

namespace Abstodo.DataAccess.Concrete.EntityFramework
{
    public class AbstodoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=Abstodo;integrated security=true");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
