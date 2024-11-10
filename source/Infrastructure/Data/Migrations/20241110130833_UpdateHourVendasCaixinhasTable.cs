using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHourVendasCaixinhasTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("88792e17-4afe-42b3-9bfd-d1db84d11a16"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("c0b7fe22-8aad-4176-aed0-6559f6f4f0f0"));

            migrationBuilder.AlterColumn<string>(
                name: "TM_HORARIO_INICIO",
                table: "T_VENDAS_CAIXINHAS",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "TM_HORARIO_FIM",
                table: "T_VENDAS_CAIXINHAS",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("2865a55e-9019-4b59-bf6e-39fd571008e1"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("6ffe9b90-f5b8-48a0-a0e6-e045dbd19b61"));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TM_HORARIO_INICIO",
                table: "T_VENDAS_CAIXINHAS",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TM_HORARIO_FIM",
                table: "T_VENDAS_CAIXINHAS",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

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
    }
}
