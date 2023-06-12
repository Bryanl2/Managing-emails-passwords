using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Managment.API.Migrations
{
    public partial class SeedRoless : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0417f77e-2cc0-4979-9bd6-b1fac587deb1", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c93f3fcd-572e-4135-a9bc-5a6bd75954db", "2", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1b7fd73-1224-4c9f-9b64-c1ce2d96103d", "3", "HR", "HR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0417f77e-2cc0-4979-9bd6-b1fac587deb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c93f3fcd-572e-4135-a9bc-5a6bd75954db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1b7fd73-1224-4c9f-9b64-c1ce2d96103d");

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
    }
}
