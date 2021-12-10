﻿// <auto-generated />
using System;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataBase.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataBase.DataModels.CleaningsDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatorDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDatePlanned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDateReal")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExecutorDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExecutorId")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDatePlanned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDateReal")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("RoomId");

                    b.ToTable("Cleanings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatorDescription = "Opis osoby tworzącej zadanie.",
                            CreatorId = 2,
                            EndDatePlanned = new DateTime(2021, 10, 17, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDateReal = new DateTime(2021, 10, 17, 11, 50, 17, 0, DateTimeKind.Unspecified),
                            ExecutorId = 3,
                            RoomId = 5,
                            StartDatePlanned = new DateTime(2021, 10, 17, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDateReal = new DateTime(2021, 10, 17, 9, 50, 17, 0, DateTimeKind.Unspecified),
                            State = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatorDescription = "Opis osoby tworzącej zadanie.",
                            CreatorId = 2,
                            EndDatePlanned = new DateTime(2021, 10, 16, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDateReal = new DateTime(2021, 10, 16, 13, 1, 36, 0, DateTimeKind.Unspecified),
                            ExecutorId = 4,
                            RoomId = 1,
                            StartDatePlanned = new DateTime(2021, 10, 16, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDateReal = new DateTime(2021, 10, 16, 11, 12, 36, 0, DateTimeKind.Unspecified),
                            State = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatorDescription = "Opis osoby tworzącej zadanie.",
                            CreatorId = 2,
                            EndDatePlanned = new DateTime(2021, 10, 15, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDateReal = new DateTime(2021, 10, 18, 15, 21, 23, 0, DateTimeKind.Unspecified),
                            ExecutorDescription = "Pozostawiony bagaż w szafie",
                            ExecutorId = 3,
                            RoomId = 2,
                            StartDatePlanned = new DateTime(2021, 10, 15, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDateReal = new DateTime(2021, 10, 18, 13, 34, 1, 0, DateTimeKind.Unspecified),
                            State = 0
                        },
                        new
                        {
                            Id = 4,
                            CreatorDescription = "Opis osoby tworzącej zadanie.",
                            CreatorId = 2,
                            EndDatePlanned = new DateTime(2021, 10, 18, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDateReal = new DateTime(2021, 10, 18, 12, 1, 43, 0, DateTimeKind.Unspecified),
                            ExecutorId = 4,
                            RoomId = 1,
                            StartDatePlanned = new DateTime(2021, 10, 18, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDateReal = new DateTime(2021, 10, 18, 10, 8, 59, 0, DateTimeKind.Unspecified),
                            State = 0
                        },
                        new
                        {
                            Id = 5,
                            CreatorDescription = "Opis osoby tworzącej zadanie.",
                            CreatorId = 2,
                            EndDatePlanned = new DateTime(2021, 10, 30, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            ExecutorId = 3,
                            RoomId = 3,
                            StartDatePlanned = new DateTime(2021, 10, 30, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            State = 2
                        },
                        new
                        {
                            Id = 6,
                            CreatorDescription = "Pranie pościeli.",
                            CreatorId = 3,
                            EndDatePlanned = new DateTime(2021, 10, 20, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDatePlanned = new DateTime(2021, 10, 20, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            State = 1
                        });
                });

            modelBuilder.Entity("DataBase.DataModels.CustomerDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Lastname = "Kozłowski",
                            Name = "Robert",
                            PhoneNumber = "124543996"
                        },
                        new
                        {
                            Id = 2,
                            Email = "maciej.jeziorek@gmail.com",
                            Lastname = "Jeziorek",
                            Name = "Maciej",
                            PhoneNumber = "124543996"
                        },
                        new
                        {
                            Id = 3,
                            Lastname = "Gitarek",
                            Name = "jan"
                        },
                        new
                        {
                            Id = 4,
                            Email = "stefan.bobrowski@gmail.com",
                            Lastname = "Bobrowski",
                            Name = "Stean"
                        });
                });

            modelBuilder.Entity("DataBase.DataModels.LoginDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Logins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "Jan",
                            Password = "$MYHASH$V1$10000$VZip5uHJd9AZkEGAd4sI2NrDhYyNlHk7Shxch3Oz2vp80thn",
                            WorkerId = 1
                        },
                        new
                        {
                            Id = 2,
                            Login = "Hanna",
                            Password = "$MYHASH$V1$10000$VZip5uHJd9AZkEGAd4sI2NrDhYyNlHk7Shxch3Oz2vp80thn",
                            WorkerId = 2
                        },
                        new
                        {
                            Id = 3,
                            Login = "Paweł",
                            Password = "$MYHASH$V1$10000$VZip5uHJd9AZkEGAd4sI2NrDhYyNlHk7Shxch3Oz2vp80thn",
                            WorkerId = 3
                        },
                        new
                        {
                            Id = 4,
                            Login = "Aneta",
                            Password = "$MYHASH$V1$10000$VZip5uHJd9AZkEGAd4sI2NrDhYyNlHk7Shxch3Oz2vp80thn",
                            WorkerId = 4
                        });
                });

            modelBuilder.Entity("DataBase.DataModels.ReservationDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDatePlanned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDateReal")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonCount")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDatePlanned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDateReal")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<bool>("WithBreakfast")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            EndDatePlanned = new DateTime(2021, 10, 17, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDateReal = new DateTime(2021, 10, 17, 9, 50, 17, 0, DateTimeKind.Unspecified),
                            PersonCount = 5,
                            RoomId = 5,
                            StartDatePlanned = new DateTime(2021, 10, 14, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDateReal = new DateTime(2021, 10, 14, 12, 12, 45, 0, DateTimeKind.Unspecified),
                            WithBreakfast = false
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            EndDatePlanned = new DateTime(2021, 10, 16, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDateReal = new DateTime(2021, 10, 16, 11, 12, 36, 0, DateTimeKind.Unspecified),
                            PersonCount = 1,
                            RoomId = 1,
                            StartDatePlanned = new DateTime(2021, 10, 15, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDateReal = new DateTime(2021, 10, 15, 13, 10, 32, 0, DateTimeKind.Unspecified),
                            WithBreakfast = true
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            EndDatePlanned = new DateTime(2021, 10, 18, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDateReal = new DateTime(2021, 10, 18, 13, 34, 1, 0, DateTimeKind.Unspecified),
                            PersonCount = 2,
                            RoomId = 2,
                            StartDatePlanned = new DateTime(2021, 10, 15, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDateReal = new DateTime(2021, 10, 15, 12, 11, 42, 0, DateTimeKind.Unspecified),
                            WithBreakfast = true
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 1,
                            EndDatePlanned = new DateTime(2021, 10, 18, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDateReal = new DateTime(2021, 10, 18, 10, 8, 59, 0, DateTimeKind.Unspecified),
                            PersonCount = 2,
                            RoomId = 1,
                            StartDatePlanned = new DateTime(2021, 10, 17, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDateReal = new DateTime(2021, 10, 17, 11, 31, 19, 0, DateTimeKind.Unspecified),
                            WithBreakfast = false
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 4,
                            EndDatePlanned = new DateTime(2021, 10, 30, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDateReal = new DateTime(2021, 10, 30, 9, 12, 31, 0, DateTimeKind.Unspecified),
                            PersonCount = 2,
                            RoomId = 3,
                            StartDatePlanned = new DateTime(2021, 10, 20, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDateReal = new DateTime(2021, 10, 20, 14, 55, 4, 0, DateTimeKind.Unspecified),
                            WithBreakfast = false
                        });
                });

            modelBuilder.Entity("DataBase.DataModels.RoomDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float>("Size")
                        .HasColumnType("real");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 2,
                            Description = "Opis pokoju 01",
                            Floor = 1,
                            Number = "01",
                            PricePerDay = 150m,
                            Size = 14f
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 2,
                            Description = "Opis pokoju 02",
                            Floor = 1,
                            Number = "02",
                            PricePerDay = 150m,
                            Size = 14f
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 2,
                            Description = "Opis pokoju 03",
                            Floor = 1,
                            Number = "03",
                            PricePerDay = 150m,
                            Size = 14f
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 2,
                            Description = "Opis pokoju 04",
                            Floor = 1,
                            Number = "04",
                            PricePerDay = 150m,
                            Size = 14f
                        },
                        new
                        {
                            Id = 5,
                            Capacity = 5,
                            Description = "Opis pokoju 05",
                            Floor = 2,
                            Number = "05",
                            PricePerDay = 340m,
                            Size = 34f
                        },
                        new
                        {
                            Id = 6,
                            Capacity = 4,
                            Description = "Opis pokoju 06",
                            Floor = 2,
                            Number = "06",
                            PricePerDay = 300m,
                            Size = 31.5f
                        });
                });

            modelBuilder.Entity("DataBase.DataModels.WorkerDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Workers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1976, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jan.brzęczyszczykiewicz@gmail.com",
                            Gender = 1,
                            IsActive = true,
                            Lastname = "Brzęczyszczykiewicz",
                            Name = "Jan",
                            PhoneNumber = "594291112",
                            Type = 0,
                            TypeId = 0
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1988, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hanna.mrozek@gmail.com",
                            Gender = 0,
                            IsActive = true,
                            Lastname = "Mrozek",
                            Name = "Hanna",
                            PhoneNumber = "234965284",
                            Type = 1,
                            TypeId = 0
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1992, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "pawel.nowak@gmail.com",
                            IsActive = true,
                            Lastname = "Nowak",
                            Name = "Paweł",
                            PhoneNumber = "110443785",
                            Type = 2,
                            TypeId = 0
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(1980, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "aneta.buda@gmail.com",
                            Gender = 0,
                            IsActive = true,
                            Lastname = "Buda",
                            Name = "Aneta",
                            PhoneNumber = "924577646",
                            Type = 2,
                            TypeId = 0
                        });
                });

            modelBuilder.Entity("DataBase.DataModels.CleaningsDataModel", b =>
                {
                    b.HasOne("DataBase.DataModels.WorkerDataModel", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.DataModels.WorkerDataModel", "Executor")
                        .WithMany()
                        .HasForeignKey("ExecutorId");

                    b.HasOne("DataBase.DataModels.RoomDataModel", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.Navigation("Creator");

                    b.Navigation("Executor");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DataBase.DataModels.LoginDataModel", b =>
                {
                    b.HasOne("DataBase.DataModels.WorkerDataModel", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("DataBase.DataModels.ReservationDataModel", b =>
                {
                    b.HasOne("DataBase.DataModels.CustomerDataModel", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.DataModels.RoomDataModel", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Room");
                });
#pragma warning restore 612, 618
        }
    }
}
