using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoTeste2.Infra.Migrations
{
    public partial class BaseInicial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1bd14693-d749-4586-a748-b2c2e67e44e9", "6e1c3692-bd79-4248-8465-d0176e004502", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "4995f09b-a368-4feb-9708-224e6b3d4dd0", "admin@admin", false, "administrador", false, null, "admin@admin", "admin", "AQAAAAEAACcQAAAAEIqLKny3YRY4+ylCB3j4TGzKnwYT3AWQgf8dTtG2z+W6qtDiuYAtBOZxnPUFQ6Z3tg==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "1bd14693-d749-4586-a748-b2c2e67e44e9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "1bd14693-d749-4586-a748-b2c2e67e44e9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1bd14693-d749-4586-a748-b2c2e67e44e9", "6e1c3692-bd79-4248-8465-d0176e004502" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "4995f09b-a368-4feb-9708-224e6b3d4dd0" });
        }
    }
}
