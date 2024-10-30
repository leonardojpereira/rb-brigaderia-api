using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedAtDeleteAtCreatedAtToRecipeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("426e7776-d69d-4fdb-9a6d-02f81b5e6ae6"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("e3697010-846a-4628-ad9e-3906952fa35e"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_CREATEDAT",
                table: "T_RECIPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_UPDATEDAT",
                table: "T_RECIPE",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FL_DELETED",
                table: "T_RECIPE",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 30, 1, 17, 16, 407, DateTimeKind.Utc).AddTicks(721));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 30, 1, 17, 16, 407, DateTimeKind.Utc).AddTicks(727));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("65ca06f3-762d-46a6-b556-aabd861b6c34"), new DateTime(2024, 10, 30, 1, 17, 16, 407, DateTimeKind.Utc).AddTicks(1070), "admin@admin.com", "$2a$11$7KdVNyV6Woy9ALiGNgG3l.UmNtzy4Ldxp4zmekYaYV2/vU4w5syae", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" },
                    { new Guid("f04b3fc2-5697-4b52-a9a2-667cd0647682"), new DateTime(2024, 10, 30, 1, 17, 16, 673, DateTimeKind.Utc).AddTicks(4792), "user@user.com", "$2a$11$aeaZ8PLhH6rYO6P.LkIZAuJWOESGt/XKMVu0J6BbzMIFQsL1SyIVW", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("65ca06f3-762d-46a6-b556-aabd861b6c34"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("f04b3fc2-5697-4b52-a9a2-667cd0647682"));

            migrationBuilder.DropColumn(
                name: "DT_CREATEDAT",
                table: "T_RECIPE");

            migrationBuilder.DropColumn(
                name: "DT_UPDATEDAT",
                table: "T_RECIPE");

            migrationBuilder.DropColumn(
                name: "FL_DELETED",
                table: "T_RECIPE");

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 26, 1, 3, 11, 890, DateTimeKind.Utc).AddTicks(1395));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 26, 1, 3, 11, 890, DateTimeKind.Utc).AddTicks(1400));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("426e7776-d69d-4fdb-9a6d-02f81b5e6ae6"), new DateTime(2024, 10, 26, 1, 3, 12, 41, DateTimeKind.Utc).AddTicks(5942), "user@user.com", "$2a$11$UMsnaKK7H5k9OnYKpoL9w.5mB53/uwi5xn8IyeALHbDnwKR79cs8G", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" },
                    { new Guid("e3697010-846a-4628-ad9e-3906952fa35e"), new DateTime(2024, 10, 26, 1, 3, 11, 890, DateTimeKind.Utc).AddTicks(1589), "admin@admin.com", "$2a$11$Kvn/YQATOYIBgiOREvS6vOnM7DgT8FaPDgOct80TKgJS8ccnxVSQq", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" }
                });
        }
    }
}
