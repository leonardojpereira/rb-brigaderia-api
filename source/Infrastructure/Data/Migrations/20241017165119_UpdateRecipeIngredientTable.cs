using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRecipeIngredientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_RECIPE_INGREDIENTES_T_RECIPE_RecipeId",
                table: "T_RECIPE_INGREDIENTES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_RECIPE_INGREDIENTES",
                table: "T_RECIPE_INGREDIENTES");

            migrationBuilder.DropIndex(
                name: "IX_T_RECIPE_INGREDIENTES_RecipeId",
                table: "T_RECIPE_INGREDIENTES");

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("182b7374-90d2-48b2-a75d-37708a48cad0"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("300721dd-d467-4194-8dd8-b24e857d3ea2"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "T_RECIPE_INGREDIENTES");

            migrationBuilder.RenameColumn(
                name: "FK_ID_INGREDIENTE",
                table: "T_RECIPE_INGREDIENTES",
                newName: "IngredienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_RECIPE_INGREDIENTES",
                table: "T_RECIPE_INGREDIENTES",
                columns: new[] { "RecipeId", "IngredienteId" });

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 17, 16, 51, 18, 383, DateTimeKind.Utc).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 17, 16, 51, 18, 383, DateTimeKind.Utc).AddTicks(2342));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("1b5e90a4-4901-4f26-a2fe-7ec1db2da30e"), new DateTime(2024, 10, 17, 16, 51, 18, 536, DateTimeKind.Utc).AddTicks(4257), "user@user.com", "$2a$11$sEmG6fB3K089tN2h6g0NTO456d9EsIHrcC1km/SdGsZVyXeoV5pS.", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" },
                    { new Guid("b8a0d1e6-f8a4-44bb-82bc-8342cceba977"), new DateTime(2024, 10, 17, 16, 51, 18, 383, DateTimeKind.Utc).AddTicks(2519), "admin@admin.com", "$2a$11$j2EXuNjE2IBvkRe62ap9Vuflu1Z1tHCCr.Ts8umKZQ0FPHMIi1PXe", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_RECIPE_INGREDIENTES_IngredienteId",
                table: "T_RECIPE_INGREDIENTES",
                column: "IngredienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_RECIPE_INGREDIENTES_INGREDIENT",
                table: "T_RECIPE_INGREDIENTES",
                column: "IngredienteId",
                principalTable: "T_INGREDIENT",
                principalColumn: "PK_ID_INGREDIENT",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RECIPE_INGREDIENTES_RECIPE",
                table: "T_RECIPE_INGREDIENTES",
                column: "RecipeId",
                principalTable: "T_RECIPE",
                principalColumn: "PK_ID_RECIPE",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RECIPE_INGREDIENTES_INGREDIENT",
                table: "T_RECIPE_INGREDIENTES");

            migrationBuilder.DropForeignKey(
                name: "FK_RECIPE_INGREDIENTES_RECIPE",
                table: "T_RECIPE_INGREDIENTES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_RECIPE_INGREDIENTES",
                table: "T_RECIPE_INGREDIENTES");

            migrationBuilder.DropIndex(
                name: "IX_T_RECIPE_INGREDIENTES_IngredienteId",
                table: "T_RECIPE_INGREDIENTES");

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("1b5e90a4-4901-4f26-a2fe-7ec1db2da30e"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("b8a0d1e6-f8a4-44bb-82bc-8342cceba977"));

            migrationBuilder.RenameColumn(
                name: "IngredienteId",
                table: "T_RECIPE_INGREDIENTES",
                newName: "FK_ID_INGREDIENTE");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "T_RECIPE_INGREDIENTES",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_RECIPE_INGREDIENTES",
                table: "T_RECIPE_INGREDIENTES",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_T_RECIPE_INGREDIENTES_T_RECIPE_RecipeId",
                table: "T_RECIPE_INGREDIENTES",
                column: "RecipeId",
                principalTable: "T_RECIPE",
                principalColumn: "PK_ID_RECIPE",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
