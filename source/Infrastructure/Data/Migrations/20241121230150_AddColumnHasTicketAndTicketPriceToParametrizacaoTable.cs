using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnHasTicketAndTicketPriceToParametrizacaoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("22a62d89-e559-48cb-b78a-5a4270660bd3"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("9105115e-ee1f-48ef-8797-e7c8143c975c"));

            migrationBuilder.AddColumn<bool>(
                name: "BL_PRECISA_PASSAGEM",
                table: "T_PARAMETRIZACAO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "NR_PRECO_PASSAGEM",
                table: "T_PARAMETRIZACAO",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 21, 23, 1, 49, 984, DateTimeKind.Utc).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 21, 23, 1, 49, 984, DateTimeKind.Utc).AddTicks(8026));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "TX_NOME", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("bf6c4559-1ebc-4920-b2cc-fb86fdfb52f8"), new DateTime(2024, 11, 21, 23, 1, 50, 143, DateTimeKind.Utc).AddTicks(1419), "user@user.com", "$2a$11$1y4NASXyRBtFDGPuQO8Sme3/m5xIfl2SBITqvubfZk/fQEHtiqioG", false, "User", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" },
                    { new Guid("f3723404-978a-43aa-9c9b-03c4b375cac2"), new DateTime(2024, 11, 21, 23, 1, 49, 984, DateTimeKind.Utc).AddTicks(8448), "admin@admin.com", "$2a$11$61O0Py/fhAgJoZ095rcKLugDSJiphagxJXgprTTynEEdTPGEKJ23W", false, "Admin", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("bf6c4559-1ebc-4920-b2cc-fb86fdfb52f8"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("f3723404-978a-43aa-9c9b-03c4b375cac2"));

            migrationBuilder.DropColumn(
                name: "BL_PRECISA_PASSAGEM",
                table: "T_PARAMETRIZACAO");

            migrationBuilder.DropColumn(
                name: "NR_PRECO_PASSAGEM",
                table: "T_PARAMETRIZACAO");

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
    }
}
