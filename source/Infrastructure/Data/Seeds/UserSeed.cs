using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Constants;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Seeds;

internal class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            (
                nome: "Admin",
                username: "admin",
                password: "admin123",
                email: "admin@admin.com",
                roleId: RoleConstants.Admin
            ),
            new User
            (
                nome: "User",
                username: "user",
                password: "admin123",
                email: "user@user.com",
                roleId: RoleConstants.User
            )
        );
    }
}
