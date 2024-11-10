using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVendasCaixinhasTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("758a8660-3bde-4d3a-aaba-79d99524b1bc"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("d7a1243f-f756-40dc-8b7f-1701ad3bc3ff"));

            migrationBuilder.CreateTable(
                name: "T_VENDAS_CAIXINHAS",
                columns: table => new
                {
                    PK_ID_VENDAS_CAIXINHAS = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DT_VENDA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NR_QUANTIDADE_CAIXINHAS = table.Column<int>(type: "int", nullable: false),
                    NR_PRECO_TOTAL_VENDA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NR_SALARIO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NR_CUSTO_TOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NR_LUCRO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TX_LOCAL_VENDA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TM_HORARIO_INICIO = table.Column<TimeSpan>(type: "time", nullable: false),
                    TM_HORARIO_FIM = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VENDAS_CAIXINHAS", x => x.PK_ID_VENDAS_CAIXINHAS);
                });

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 10, 1, 36, 41, 422, DateTimeKind.Utc).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 10, 1, 36, 41, 422, DateTimeKind.Utc).AddTicks(9739));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "TX_NOME", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("88792e17-4afe-42b3-9bfd-d1db84d11a16"), new DateTime(2024, 11, 10, 1, 36, 41, 615, DateTimeKind.Utc).AddTicks(9103), "user@user.com", "$2a$11$uvJ0bWglIhnXwZcCqXkjNeTIs9vyVwmffL/DIqW6dNJJoAc6iPAA6", false, "User", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" },
                    { new Guid("c0b7fe22-8aad-4176-aed0-6559f6f4f0f0"), new DateTime(2024, 11, 10, 1, 36, 41, 423, DateTimeKind.Utc).AddTicks(26), "admin@admin.com", "$2a$11$jjo3bqhpDKOrejZyoC5zQOoHB5LUxjPuP6Zf6wSwF2Kj4Km25I9xW", false, "Admin", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_VENDAS_CAIXINHAS");

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("88792e17-4afe-42b3-9bfd-d1db84d11a16"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("c0b7fe22-8aad-4176-aed0-6559f6f4f0f0"));

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
    }
}
