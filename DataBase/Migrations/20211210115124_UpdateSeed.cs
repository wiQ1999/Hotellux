using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class UpdateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$MYHASH$V1$10000$VZip5uHJd9AZkEGAd4sI2NrDhYyNlHk7Shxch3Oz2vp80thn");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$MYHASH$V1$10000$VZip5uHJd9AZkEGAd4sI2NrDhYyNlHk7Shxch3Oz2vp80thn");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$MYHASH$V1$10000$VZip5uHJd9AZkEGAd4sI2NrDhYyNlHk7Shxch3Oz2vp80thn");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$MYHASH$V1$10000$VZip5uHJd9AZkEGAd4sI2NrDhYyNlHk7Shxch3Oz2vp80thn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3");
        }
    }
}
