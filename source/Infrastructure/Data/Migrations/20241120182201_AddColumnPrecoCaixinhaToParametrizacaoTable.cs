using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnPrecoCaixinhaToParametrizacaoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("092e3da9-1df1-4c18-93d2-b5d2684942fd"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("bebafc02-0368-464e-8664-c2079d463777"));

            migrationBuilder.AddColumn<decimal>(
                name: "NR_PRECO_CAIXINHA",
                table: "T_PARAMETRIZACAO",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 20, 18, 22, 0, 905, DateTimeKind.Utc).AddTicks(2757));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 20, 18, 22, 0, 905, DateTimeKind.Utc).AddTicks(2761));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "TX_NOME", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("22a62d89-e559-48cb-b78a-5a4270660bd3"), new DateTime(2024, 11, 20, 18, 22, 0, 905, DateTimeKind.Utc).AddTicks(3014), "admin@admin.com", "$2a$11$52ZcOLkE0Ak/C1krllWdCuUpQdVUBKTiRwdw6JrAhrVI1dyevoiFq", false, "Admin", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" },
                    { new Guid("9105115e-ee1f-48ef-8797-e7c8143c975c"), new DateTime(2024, 11, 20, 18, 22, 1, 53, DateTimeKind.Utc).AddTicks(8820), "user@user.com", "$2a$11$mYYXTAh6GqF3TJ/GIh9e3.UsZw1K2O8OvxMsnh5UHut2168cLnr2q", false, "User", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("22a62d89-e559-48cb-b78a-5a4270660bd3"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("9105115e-ee1f-48ef-8797-e7c8143c975c"));

            migrationBuilder.DropColumn(
                name: "NR_PRECO_CAIXINHA",
                table: "T_PARAMETRIZACAO");

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 20, 14, 25, 18, 341, DateTimeKind.Utc).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 20, 14, 25, 18, 341, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "TX_NOME", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("092e3da9-1df1-4c18-93d2-b5d2684942fd"), new DateTime(2024, 11, 20, 14, 25, 18, 469, DateTimeKind.Utc).AddTicks(3183), "user@user.com", "$2a$11$1uaUfq6gTCZm51QGNhm2YOsvwNdtpzBk0nk9YGt4vUSXGLb0DD7LK", false, "User", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" },
                    { new Guid("bebafc02-0368-464e-8664-c2079d463777"), new DateTime(2024, 11, 20, 14, 25, 18, 341, DateTimeKind.Utc).AddTicks(4843), "admin@admin.com", "$2a$11$vbKwAX4mpirmqIcUg1pwReGGQ3/sC0QZRoI6pvhfiCvjvX81u5TEC", false, "Admin", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" }
                });
        }
    }
}
