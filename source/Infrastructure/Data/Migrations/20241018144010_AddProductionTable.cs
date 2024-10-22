using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("1b5e90a4-4901-4f26-a2fe-7ec1db2da30e"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("b8a0d1e6-f8a4-44bb-82bc-8342cceba977"));

            migrationBuilder.CreateTable(
                name: "T_PRODUCTION",
                columns: table => new
                {
                    PK_ID_PRODUCTION = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FK_ID_RECEITA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NR_QUANTIDADE_PRODUZIDA = table.Column<int>(type: "int", nullable: false),
                    DT_PRODUCAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PRODUCTION", x => x.PK_ID_PRODUCTION);
                    table.ForeignKey(
                        name: "FK_T_PRODUCTION_T_RECIPE_FK_ID_RECEITA",
                        column: x => x.FK_ID_RECEITA,
                        principalTable: "T_RECIPE",
                        principalColumn: "PK_ID_RECIPE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 18, 14, 40, 9, 347, DateTimeKind.Utc).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 18, 14, 40, 9, 347, DateTimeKind.Utc).AddTicks(3229));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("23ddf9a9-0a24-41bb-8f6c-f9063315476a"), new DateTime(2024, 10, 18, 14, 40, 9, 551, DateTimeKind.Utc).AddTicks(5882), "user@user.com", "$2a$11$Bi8DISG6hzDdcwUA5gLhcOQhXdX6soZoZ1ZhltN57bKxs58l2UOqu", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" },
                    { new Guid("d868245e-9284-43b8-9454-8e6bf4e28d7f"), new DateTime(2024, 10, 18, 14, 40, 9, 347, DateTimeKind.Utc).AddTicks(3568), "admin@admin.com", "$2a$11$ju.70inOddhOLBDW1Y6aA./jF8r5GWQDl6feTo3oDw1UndCGMjPpa", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_PRODUCTION_FK_ID_RECEITA",
                table: "T_PRODUCTION",
                column: "FK_ID_RECEITA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_PRODUCTION");

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("23ddf9a9-0a24-41bb-8f6c-f9063315476a"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("d868245e-9284-43b8-9454-8e6bf4e28d7f"));

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
        }
    }
}
