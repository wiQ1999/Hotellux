using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class Context : DbContext
    {
        //public DbSet<Test1DataModel> Test1 { get; set; }
        //public DbSet<Test2DataModel> Test2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"  
                Server=localhost;Database=TestDB;Trusted_Connection=True;"
            );
        }
    }
}
