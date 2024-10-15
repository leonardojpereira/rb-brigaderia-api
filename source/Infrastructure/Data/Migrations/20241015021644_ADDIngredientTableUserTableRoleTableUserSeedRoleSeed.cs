using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ADDIngredientTableUserTableRoleTableUserSeedRoleSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_INGREDIENT",
                columns: table => new
                {
                    PK_ID_INGREDIENT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TX_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_MEASUREMENT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NR_CURRENT_STOCK = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NR_MINIMUM_STOCK = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NR_UNIT_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DT_CREATEDAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DT_UPDATEDAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FL_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_INGREDIENT", x => x.PK_ID_INGREDIENT);
                });

            migrationBuilder.CreateTable(
                name: "T_ROLE",
                columns: table => new
                {
                    PK_ROLEID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TX_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DT_CREATEDAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DT_UPDATEDAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FL_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ROLE", x => x.PK_ROLEID);
                });

            migrationBuilder.CreateTable(
                name: "T_USER",
                columns: table => new
                {
                    PK_USERID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TX_USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_ROLEID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DT_CREATEDAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DT_UPDATEDAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FL_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USER", x => x.PK_USERID);
                    table.ForeignKey(
                        name: "FK_USER_ROLE",
                        column: x => x.FK_ROLEID,
                        principalTable: "T_ROLE",
                        principalColumn: "PK_ROLEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "T_ROLE",
                columns: new[] { "PK_ROLEID", "DT_CREATEDAT", "FL_DELETED", "TX_NAME", "DT_UPDATEDAT" },
                values: new object[,]
                {
                    { new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), new DateTime(2024, 10, 15, 2, 16, 43, 893, DateTimeKind.Utc).AddTicks(5211), false, "Admin", null },
                    { new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), new DateTime(2024, 10, 15, 2, 16, 43, 893, DateTimeKind.Utc).AddTicks(5216), false, "User", null }
                });

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("8194ef4d-959d-48cd-8617-e8b2cbc5b0cc"), new DateTime(2024, 10, 15, 2, 16, 44, 111, DateTimeKind.Utc).AddTicks(8754), "user@user.com", "$2a$11$R0AYFma3Ko8zXHviR7ln5ecBEpgiUJAHZ8j2BktlZ00HH.XA4HYOK", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" },
                    { new Guid("aef9fb6c-1974-4e85-8fd9-65bb63d5c652"), new DateTime(2024, 10, 15, 2, 16, 43, 893, DateTimeKind.Utc).AddTicks(5535), "admin@admin.com", "$2a$11$RzDQPDkyHqmq5gO0IOTp4O1aKrcyftXnOREpgpXD5B01rp7yA63vC", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_USER_FK_ROLEID",
                table: "T_USER",
                column: "FK_ROLEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_INGREDIENT");

            migrationBuilder.DropTable(
                name: "T_USER");

            migrationBuilder.DropTable(
                name: "T_ROLE");
        }
    }
}
