using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Managment.API.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2de32178-aeef-4cd4-a0d8-7a994da545a1", "3", "HR", "HR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39c68b2c-840f-41d3-b3fd-481c886e1e5b", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e99e4ab-ccbf-4b0f-a8e5-243eae27154e", "2", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2de32178-aeef-4cd4-a0d8-7a994da545a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39c68b2c-840f-41d3-b3fd-481c886e1e5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e99e4ab-ccbf-4b0f-a8e5-243eae27154e");
        }
    }
}
