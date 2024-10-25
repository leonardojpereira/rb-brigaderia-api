using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingUserPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: new DateTime(2024, 10, 25, 11, 53, 20, 279, DateTimeKind.Utc).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "T_ROLE",
                keyColumn: "PK_ROLEID",
                keyValue: new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"),
                column: "DT_CREATEDAT",
                value: new DateTime(2024, 10, 25, 11, 53, 20, 279, DateTimeKind.Utc).AddTicks(2520));

            migrationBuilder.InsertData(
                table: "T_USER",
                columns: new[] { "PK_USERID", "DT_CREATEDAT", "TX_EMAIL", "TX_PASSWORD", "FL_DELETED", "FK_ROLEID", "DT_UPDATEDAT", "TX_USERNAME" },
                values: new object[,]
                {
                    { new Guid("3b5b0d33-2813-4614-8957-d28862749958"), new DateTime(2024, 10, 25, 11, 53, 20, 424, DateTimeKind.Utc).AddTicks(1533), "user@user.com", "$2a$11$FMjilaJWIkMx8T4/nkFtceYwc5r2eW.ZUzKsFTHWNyGGpU9dLQ5Im", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9b"), null, "user" },
                    { new Guid("f4d74cff-e86e-452e-99d7-8cc8475d76c5"), new DateTime(2024, 10, 25, 11, 53, 20, 279, DateTimeKind.Utc).AddTicks(2768), "admin@admin.com", "$2a$11$7433LszZM2zhoNrV14Ewb.nkRxslplB8htiR9GoRe.acQWmddqp76", false, new Guid("f7d4d7a9-4d1e-4a8d-9a8e-9b9a9b9a9b9a"), null, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("3b5b0d33-2813-4614-8957-d28862749958"));

            migrationBuilder.DeleteData(
                table: "T_USER",
                keyColumn: "PK_USERID",
                keyValue: new Guid("f4d74cff-e86e-452e-99d7-8cc8475d76c5"));

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
        }
    }
}
