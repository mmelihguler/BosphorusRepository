using Microsoft.EntityFrameworkCore;
namespace Entities.Model
{
    public class DataContext : DbContext
    {
        public DataContext() {}
        
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Connection to SQL Server
        {
            optionsBuilder.UseSqlServer("server=M;database=Bosphorus_Database; integrated security=true;"); 
        }
        
        public DbSet<Project> Projects { get; set; }
        public DbSet<Investor> Investors { get; set; }
    }
}