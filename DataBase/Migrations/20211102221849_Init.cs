using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhonNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<float>(type: "real", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhonNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    PersonCount = table.Column<int>(type: "int", nullable: false),
                    WithBreakfast = table.Column<bool>(type: "bit", nullable: false),
                    StartDatePlanned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDatePlanned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateReal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateReal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cleanings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ExecutorId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CreatorDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutorDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDatePlanned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDatePlanned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDateReal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateReal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cleanings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cleanings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cleanings_Workers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cleanings_Workers_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logins_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Lastname", "Name", "PhonNumber" },
                values: new object[,]
                {
                    { 1, null, "Kozłowski", "Robert", "124543996" },
                    { 2, "maciej.jeziorek@gmail.com", "Jeziorek", "Maciej", "124543996" },
                    { 3, null, "Gitarek", "jan", null },
                    { 4, "stefan.bobrowski@gmail.com", "Bobrowski", "Stean", null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Description", "Floor", "Number", "PricePerDay", "Size" },
                values: new object[,]
                {
                    { 1, 2, "Opis pokoju 01", 1, "01", 150m, 14f },
                    { 2, 2, "Opis pokoju 02", 1, "02", 150m, 14f },
                    { 3, 2, "Opis pokoju 03", 1, "03", 150m, 14f },
                    { 4, 2, "Opis pokoju 04", 1, "04", 150m, 14f },
                    { 5, 5, "Opis pokoju 05", 2, "05", 340m, 34f },
                    { 6, 4, "Opis pokoju 06", 2, "06", 300m, 31.5f }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "CreatedDate", "DateOfBirth", "Email", "Gender", "IsActive", "Lastname", "Name", "PhonNumber", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1976, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "jan.brzęczyszczykiewicz@gmail.com", 1, true, "Brzęczyszczykiewicz", "Jan", "594291112", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "hanna.mrozek@gmail.com", 0, true, "Mrozek", "Hanna", "234965284", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "pawel.nowak@gmail.com", null, true, "Nowak", "Paweł", "110443785", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1980, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "aneta.buda@gmail.com", 0, true, "Buda", "Aneta", "924577646", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "Id", "Login", "Password", "WorkerId" },
                values: new object[,]
                {
                    { 1, "Jan", "Jan", 1 },
                    { 2, "Hanna", "Hanna", 2 },
                    { 3, "Paweł", "Paweł", 3 },
                    { 4, "Aneta", "Aneta", 4 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "EndDatePlanned", "EndDateReal", "PersonCount", "RoomId", "StartDatePlanned", "StartDateReal", "WithBreakfast" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2021, 10, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 17, 10, 44, 45, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2021, 10, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 14, 12, 12, 45, 0, DateTimeKind.Unspecified), true },
                    { 4, 1, new DateTime(2021, 10, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 17, 10, 44, 45, 0, DateTimeKind.Unspecified), 2, 1, new DateTime(2021, 10, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 14, 12, 12, 45, 0, DateTimeKind.Unspecified), false },
                    { 3, 3, new DateTime(2021, 10, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 17, 10, 44, 45, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2021, 10, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 14, 12, 12, 45, 0, DateTimeKind.Unspecified), true },
                    { 5, 4, new DateTime(2021, 10, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 17, 10, 44, 45, 0, DateTimeKind.Unspecified), 3, 3, new DateTime(2021, 10, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 14, 12, 12, 45, 0, DateTimeKind.Unspecified), false },
                    { 1, 1, new DateTime(2021, 10, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 17, 10, 44, 45, 0, DateTimeKind.Unspecified), 5, 5, new DateTime(2021, 10, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 14, 12, 12, 45, 0, DateTimeKind.Unspecified), false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cleanings_CreatorId",
                table: "Cleanings",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cleanings_ExecutorId",
                table: "Cleanings",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cleanings_RoomId",
                table: "Cleanings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_WorkerId",
                table: "Logins",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cleanings");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
