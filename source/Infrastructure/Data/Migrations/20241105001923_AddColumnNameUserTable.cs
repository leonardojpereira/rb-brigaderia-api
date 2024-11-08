using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnNameUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("65ca06f3-762d-46a6-b556-aabd861b6c34"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("f04b3fc2-5697-4b52-a9a2-667cd0647682"));

            migrationBuilder.AddColumn<string>(
                name: "TX_NOME",
                table: "T_USER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 5, 0, 19, 22, 489, DateTimeKind.Utc).AddTicks(8993));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 5, 0, 19, 22, 489, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "TX_NOME", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("758a8660-3bde-4d3a-aaba-79d99524b1bc"), new DateTime(2024, 11, 5, 0, 19, 22, 489, DateTimeKind.Utc).AddTicks(9194), "admin@admin.com", "$2a$11$I3b5iWfZRbEhFt.YCOhS.uPGPBkFQODqH1uQhsl15gyQ6v6TM8e7e", false, "Admin", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" },
                    { new Guid("d7a1243f-f756-40dc-8b7f-1701ad3bc3ff"), new DateTime(2024, 11, 5, 0, 19, 22, 620, DateTimeKind.Utc).AddTicks(33), "user@user.com", "$2a$11$y3fL.qjtSKu8dbWH5hM6.eYoTOH/BI6SXTghWu8Db3ZrPPZIHtX.O", false, "User", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("758a8660-3bde-4d3a-aaba-79d99524b1bc"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("d7a1243f-f756-40dc-8b7f-1701ad3bc3ff"));

            migrationBuilder.DropColumn(
                name: "TX_NOME",
                table: "T_USER");

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
    }
}
