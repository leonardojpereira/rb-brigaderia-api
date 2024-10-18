using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("4172ac50-7043-4288-9f3b-dde8f0244f75"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("722079bd-f69c-418c-b4c5-ab45bd1750e1"));

            migrationBuilder.CreateTable(
                name: "T_RECIPE",
                columns: table => new
                {
                    PK_ID_RECIPE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TX_NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_RECIPE", x => x.PK_ID_RECIPE);
                });

            migrationBuilder.CreateTable(
                name: "T_RECIPE_INGREDIENTES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FK_ID_INGREDIENTE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NR_QUANTIDADE_NECESSARIA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_RECIPE_INGREDIENTES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_RECIPE_INGREDIENTES_T_RECIPE_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "T_RECIPE",
                        principalColumn: "PK_ID_RECIPE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 17, 12, 46, 36, 570, DateTimeKind.Utc).AddTicks(764));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 17, 12, 46, 36, 570, DateTimeKind.Utc).AddTicks(775));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("182b7374-90d2-48b2-a75d-37708a48cad0"), new DateTime(2024, 10, 17, 12, 46, 36, 854, DateTimeKind.Utc).AddTicks(6890), "user@user.com", "$2a$11$4onuRuGZ62IBZqyjZ.aB9OtAlclMc4Hx4QMiZxyH5ndziirua9Yie", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" },
                    { new Guid("300721dd-d467-4194-8dd8-b24e857d3ea2"), new DateTime(2024, 10, 17, 12, 46, 36, 570, DateTimeKind.Utc).AddTicks(1518), "admin@admin.com", "$2a$11$vujEHlngdNHnOcTJpCrWPeZLvDvCVykZpCJtnb7ZM0c5S.Jv.kWEi", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_RECIPE_INGREDIENTES_RecipeId",
                table: "T_RECIPE_INGREDIENTES",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_RECIPE_INGREDIENTES");

            migrationBuilder.DropTable(
                name: "T_RECIPE");

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("182b7374-90d2-48b2-a75d-37708a48cad0"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("300721dd-d467-4194-8dd8-b24e857d3ea2"));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 16, 12, 57, 2, 525, DateTimeKind.Utc).AddTicks(3316));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 16, 12, 57, 2, 525, DateTimeKind.Utc).AddTicks(3320));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("4172ac50-7043-4288-9f3b-dde8f0244f75"), new DateTime(2024, 10, 16, 12, 57, 2, 722, DateTimeKind.Utc).AddTicks(4997), "user@user.com", "$2a$11$OPZwUP1G0GsQzXLY4jsN4.8XFhC6OSqzNtY9HzyH5a483DhRIFysq", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" },
                    { new Guid("722079bd-f69c-418c-b4c5-ab45bd1750e1"), new DateTime(2024, 10, 16, 12, 57, 2, 525, DateTimeKind.Utc).AddTicks(3578), "admin@admin.com", "$2a$11$cAuNdaFb0KrqskyuLjDQ0eG7WygweXqTQlWQNdczVLcTm/Cs1Yy6q", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" }
                });
        }
    }
}
