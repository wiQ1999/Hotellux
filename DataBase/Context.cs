using DataBase.DataModels;
using DataBase.Enums;
using Microsoft.EntityFrameworkCore;
using System;

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
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Hotellux;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Server=.\MSSQLSERVER2019; Database=Hotellux;;User Id=sa; Password=Carton43;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            #region Workers
            modelBuilder.Entity<WorkerDataModel>().HasData(
                new WorkerDataModel { Id = 1, IsActive = true, Type = WorkerType.Manager, Name = "Jan", Lastname = "Brzęczyszczykiewicz", Gender = Gender.Male, DateOfBirth = new DateTime(1976, 4, 13), Email = "jan.brzęczyszczykiewicz@gmail.com", PhonNumber = "594291112" },
                new WorkerDataModel { Id = 2, IsActive = true, Type = WorkerType.Reception, Name = "Hanna", Lastname = "Mrozek", Gender = Gender.Female, DateOfBirth = new DateTime(1988, 1, 19), Email = "hanna.mrozek@gmail.com", PhonNumber = "234965284" },
                new WorkerDataModel { Id = 3, IsActive = true, Type = WorkerType.CleaningService, Name = "Paweł", Lastname = "Nowak", Gender = null, DateOfBirth = new DateTime(1992, 8, 2), Email = "pawel.nowak@gmail.com", PhonNumber = "110443785" },
                new WorkerDataModel { Id = 4, IsActive = true, Type = WorkerType.CleaningService, Name = "Aneta", Lastname = "Buda", Gender = Gender.Female, DateOfBirth = new DateTime(1980, 12, 17), Email = "aneta.buda@gmail.com", PhonNumber = "924577646" }
            );
            #endregion
            
            #region Logins
            modelBuilder.Entity<LoginDataModel>().HasData(
                new LoginDataModel { Id = 1, WorkerId = 1, Login = "Jan", Password = "Jan" },
                new LoginDataModel { Id = 2, WorkerId = 2, Login = "Hanna", Password = "Hanna" },
                new LoginDataModel { Id = 3, WorkerId = 3, Login = "Paweł", Password = "Paweł" },
                new LoginDataModel { Id = 4, WorkerId = 4, Login = "Aneta", Password = "Aneta" }
            );
            #endregion
            
            #region Rooms
            modelBuilder.Entity<RoomDataModel>().HasData(
                new RoomDataModel { Id = 1, Floor = 1, Number = "01", Size = 14f, Capacity = 2, PricePerDay = 150, Description = "Opis pokoju 01" },
                new RoomDataModel { Id = 2, Floor = 1, Number = "02", Size = 14f, Capacity = 2, PricePerDay = 150, Description = "Opis pokoju 02" },
                new RoomDataModel { Id = 3, Floor = 1, Number = "03", Size = 14f, Capacity = 2, PricePerDay = 150, Description = "Opis pokoju 03" },
                new RoomDataModel { Id = 4, Floor = 1, Number = "04", Size = 14f, Capacity = 2, PricePerDay = 150, Description = "Opis pokoju 04" },
                new RoomDataModel { Id = 5, Floor = 2, Number = "05", Size = 34f, Capacity = 5, PricePerDay = 340, Description = "Opis pokoju 05" },
                new RoomDataModel { Id = 6, Floor = 2, Number = "06", Size = 31.5f, Capacity = 4, PricePerDay = 300, Description = "Opis pokoju 06" }
            );
            #endregion

            #region Customers
            modelBuilder.Entity<CustomerDataModel>().HasData(
                new CustomerDataModel { Id = 1, Name = "Robert", Lastname = "Kozłowski", PhoneNumber = "124543996" },
                new CustomerDataModel { Id = 2, Name = "Maciej", Lastname = "Jeziorek", Email = "maciej.jeziorek@gmail.com", PhoneNumber = "124543996" },
                new CustomerDataModel { Id = 3, Name = "jan", Lastname = "Gitarek" },
                new CustomerDataModel { Id = 4, Name = "Stean", Lastname = "Bobrowski", Email = "stefan.bobrowski@gmail.com" }
            );
            #endregion

            #region Reservations
            modelBuilder.Entity<ReservationDataModel>().HasData(
                new ReservationDataModel { Id = 1, CustomerId = 1, RoomId = 5, PersonCount = 5, WithBreakfast = false, StartDatePlanned = new DateTime(2021, 10, 14, 12, 0, 0), EndDatePlanned = new DateTime(2021, 10, 17, 10, 0, 0), StartDateReal = new DateTime(2021, 10, 14, 12, 12, 45), EndDateReal = new DateTime(2021, 10, 17, 9, 50, 17) },
                new ReservationDataModel { Id = 2, CustomerId = 2, RoomId = 1, PersonCount = 1, WithBreakfast = true, StartDatePlanned = new DateTime(2021, 10, 15, 12, 0, 0), EndDatePlanned = new DateTime(2021, 10, 16, 11, 0, 0), StartDateReal = new DateTime(2021, 10, 15, 13, 10, 32), EndDateReal = new DateTime(2021, 10, 16, 11, 12, 36) },
                new ReservationDataModel { Id = 3, CustomerId = 3, RoomId = 2, PersonCount = 2, WithBreakfast = true, StartDatePlanned = new DateTime(2021, 10, 15, 13, 0, 0), EndDatePlanned = new DateTime(2021, 10, 18, 14, 0, 0), StartDateReal = new DateTime(2021, 10, 15, 12, 11, 42), EndDateReal = new DateTime(2021, 10, 18, 13, 34, 1) },
                new ReservationDataModel { Id = 4, CustomerId = 1, RoomId = 1, PersonCount = 2, WithBreakfast = false, StartDatePlanned = new DateTime(2021, 10, 17, 12, 0, 0), EndDatePlanned = new DateTime(2021, 10, 18, 10, 0, 0), StartDateReal = new DateTime(2021, 10, 17, 11, 31, 19), EndDateReal = new DateTime(2021, 10, 18, 10, 8, 59) },
                new ReservationDataModel { Id = 5, CustomerId = 4, RoomId = 3, PersonCount = 2, WithBreakfast = false, StartDatePlanned = new DateTime(2021, 10, 20, 12, 0, 0), EndDatePlanned = new DateTime(2021, 10, 30, 9, 0, 0), StartDateReal = new DateTime(2021, 10, 20, 14, 55, 4), EndDateReal = new DateTime(2021, 10, 30, 9, 12, 31) }
            );
            #endregion

            #region Cleanings
            modelBuilder.Entity<CleaningsDataModel>().HasData(
                new CleaningsDataModel { Id = 1, State = TaskState.Complited, CreatorId = 2, ExecutorId = 3, RoomId = 5, CreatorDescription = "Opis osoby tworzącej zadanie.", StartDatePlanned = new DateTime(2021, 10, 17, 10, 0, 0), EndDatePlanned = new DateTime(2021, 10, 17, 12, 0, 0), StartDateReal = new DateTime(2021, 10, 17, 9, 50, 17), EndDateReal = new DateTime(2021, 10, 17, 11, 50, 17) },
                new CleaningsDataModel { Id = 2, State = TaskState.Complited, CreatorId = 2, ExecutorId = 4, RoomId = 1, CreatorDescription = "Opis osoby tworzącej zadanie.", StartDatePlanned = new DateTime(2021, 10, 16, 11, 0, 0), EndDatePlanned = new DateTime(2021, 10, 16, 13, 0, 0), StartDateReal = new DateTime(2021, 10, 16, 11, 12, 36), EndDateReal = new DateTime(2021, 10, 16, 13, 01, 36) },
                new CleaningsDataModel { Id = 3, State = TaskState.Complited, CreatorId = 2, ExecutorId = 3, RoomId = 2, CreatorDescription = "Opis osoby tworzącej zadanie.", ExecutorDescription = "Pozostawiony bagaż w szafie", StartDatePlanned = new DateTime(2021, 10, 15, 13, 0, 0), EndDatePlanned = new DateTime(2021, 10, 15, 15, 0, 0), StartDateReal = new DateTime(2021, 10, 18, 13, 34, 1), EndDateReal = new DateTime(2021, 10, 18, 15, 21, 23) },
                new CleaningsDataModel { Id = 4, State = TaskState.Complited, CreatorId = 2, ExecutorId = 4, RoomId = 1, CreatorDescription = "Opis osoby tworzącej zadanie.", StartDatePlanned = new DateTime(2021, 10, 18, 10, 0, 0), EndDatePlanned = new DateTime(2021, 10, 18, 12, 0, 0), StartDateReal = new DateTime(2021, 10, 18, 10, 8, 59), EndDateReal = new DateTime(2021, 10, 18, 12, 1, 43) },
                new CleaningsDataModel { Id = 5, State = TaskState.New, CreatorId = 2, ExecutorId = 3, RoomId = 3, CreatorDescription = "Opis osoby tworzącej zadanie.", StartDatePlanned = new DateTime(2021, 10, 30, 9, 0, 0), EndDatePlanned = new DateTime(2021, 10, 30, 11, 0, 0) },
                new CleaningsDataModel { Id = 6, State = TaskState.Realized, CreatorId = 3, CreatorDescription = "Pranie pościeli.", StartDatePlanned = new DateTime(2021, 10, 20, 8, 0, 0), EndDatePlanned = new DateTime(2021, 10, 20, 10, 0, 0) }
            );
            #endregion

        }
    }
}
