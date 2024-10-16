using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class StockMovementTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("8194ef4d-959d-48cd-8617-e8b2cbc5b0cc"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("aef9fb6c-1974-4e85-8fd9-65bb63d5c652"));

            migrationBuilder.CreateTable(
                name: "T_STOCK_MOVEMENT",
                columns: table => new
                {
                    PK_ID_STOCK_MOVEMENT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NR_QUANTITY = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TX_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_MOVEMENT_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DT_CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_STOCK_MOVEMENT", x => x.PK_ID_STOCK_MOVEMENT);
                    table.ForeignKey(
                        name: "FK_T_STOCK_MOVEMENT_T_INGREDIENT_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "T_INGREDIENT",
                        principalColumn: "PK_ID_INGREDIENT",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_T_STOCK_MOVEMENT_IngredientId",
                table: "T_STOCK_MOVEMENT",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_STOCK_MOVEMENT");

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("4172ac50-7043-4288-9f3b-dde8f0244f75"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("722079bd-f69c-418c-b4c5-ab45bd1750e1"));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 15, 2, 16, 43, 893, DateTimeKind.Utc).AddTicks(5211));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 15, 2, 16, 43, 893, DateTimeKind.Utc).AddTicks(5216));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("8194ef4d-959d-48cd-8617-e8b2cbc5b0cc"), new DateTime(2024, 10, 15, 2, 16, 44, 111, DateTimeKind.Utc).AddTicks(8754), "user@user.com", "$2a$11$R0AYFma3Ko8zXHviR7ln5ecBEpgiUJAHZ8j2BktlZ00HH.XA4HYOK", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" },
                    { new Guid("aef9fb6c-1974-4e85-8fd9-65bb63d5c652"), new DateTime(2024, 10, 15, 2, 16, 43, 893, DateTimeKind.Utc).AddTicks(5535), "admin@admin.com", "$2a$11$RzDQPDkyHqmq5gO0IOTp4O1aKrcyftXnOREpgpXD5B01rp7yA63vC", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" }
                });
        }
    }
}
