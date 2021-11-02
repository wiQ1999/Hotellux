using DataBase.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class Context : DbContext
    {
        public DbSet<WorkerDataModel> Workers { get; set; }
        public DbSet<LoginDataModel> Logins { get; set; }
        public DbSet<RoomDataModel> Rooms { get; set; }
        public DbSet<CustomerDataModel> Customers { get; set; }
        public DbSet<ReservationDataModel> Reservations { get; set; }
        public DbSet<CleaningsDataModel> Cleanings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"  
                Server=localhost;Database=Hotellux;Trusted_Connection=True;"
            );
        }
    }
}
