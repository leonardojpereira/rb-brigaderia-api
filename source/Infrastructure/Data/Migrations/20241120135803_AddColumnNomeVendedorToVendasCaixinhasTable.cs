using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnNomeVendedorToVendasCaixinhasTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("2865a55e-9019-4b59-bf6e-39fd571008e1"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("6ffe9b90-f5b8-48a0-a0e6-e045dbd19b61"));

            migrationBuilder.AddColumn<string>(
                name: "TX_NOME_VENDEDOR",
                table: "T_VENDAS_CAIXINHAS",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("a9bf5f22-1e02-4fc6-b7cb-86b7b34c8fcb"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("abe6897c-8c60-4b4c-9b7e-d6ccdb42f0fc"));

            migrationBuilder.DropColumn(
                name: "TX_NOME_VENDEDOR",
                table: "T_VENDAS_CAIXINHAS");

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 10, 13, 8, 32, 154, DateTimeKind.Utc).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 11, 10, 13, 8, 32, 154, DateTimeKind.Utc).AddTicks(7175));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "TX_NOME", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("2865a55e-9019-4b59-bf6e-39fd571008e1"), new DateTime(2024, 11, 10, 13, 8, 32, 154, DateTimeKind.Utc).AddTicks(7386), "admin@admin.com", "$2a$11$U3tcTXOu7PC6ME3qw4MJEurY4wSCgAVgzTu1fjytct61udOhHfVEC", false, "Admin", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" },
                    { new Guid("6ffe9b90-f5b8-48a0-a0e6-e045dbd19b61"), new DateTime(2024, 11, 10, 13, 8, 32, 373, DateTimeKind.Utc).AddTicks(8901), "user@user.com", "$2a$11$TU1zRCn8DkCN6bpQyoQYZ.VjnMuBg77eUlU3ot86On3I2sa8lrF7C", false, "User", new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" }
                });
        }
    }
}
