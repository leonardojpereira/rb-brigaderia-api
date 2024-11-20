using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddParametrizacaoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("a9bf5f22-1e02-4fc6-b7cb-86b7b34c8fcb"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("abe6897c-8c60-4b4c-9b7e-d6ccdb42f0fc"));

            migrationBuilder.CreateTable(
                name: "T_PARAMETRIZACAO",
                columns: table => new
                {
                    PK_ID_PARAMETRIZACAO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TX_NOME_VENDEDOR = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NR_CUSTO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NR_LUCRO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TX_LOCAL_VENDA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TM_HORARIO_INICIO = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    TM_HORARIO_FIM = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PARAMETRIZACAO", x => x.PK_ID_PARAMETRIZACAO);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_PARAMETRIZACAO");

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("092e3da9-1df1-4c18-93d2-b5d2684942fd"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("bebafc02-0368-464e-8664-c2079d463777"));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 20, 13, 58, 2, 917, DateTimeKind.Utc).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 20, 13, 58, 2, 917, DateTimeKind.Utc).AddTicks(9790));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "TX_NOME", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("a9bf5f22-1e02-4fc6-b7cb-86b7b34c8fcb"), new DateTime(2024, 11, 20, 13, 58, 2, 918, DateTimeKind.Utc).AddTicks(12), "admin@admin.com", "$2a$11$oOuMOTb2jV65B98BkhO.X.qfWRB7Mi9ni.Gluj.HADbwBgRoudYqu", false, "Admin", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" },
                    { new Guid("abe6897c-8c60-4b4c-9b7e-d6ccdb42f0fc"), new DateTime(2024, 11, 20, 13, 58, 3, 66, DateTimeKind.Utc).AddTicks(5755), "user@user.com", "$2a$11$tSXgltYl2.tQtetEw8VAoOmKcJ8WG7pUloD/WzSTG3rJKUkXf9kmy", false, "User", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" }
                });
        }
    }
}
