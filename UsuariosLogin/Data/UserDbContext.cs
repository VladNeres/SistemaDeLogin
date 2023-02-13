using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace UsuariosLogin.Data
{
    public class UserDbContext:IdentityDbContext<IdentityUser<int>, IdentityRole<int>,int>
    {
        public UserDbContext(DbContextOptions<UserDbContext> opt): base(opt)
        {

        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    IdentityUser<int> admin = new IdentityUser<int>
        //    {
        //        UserName = "admin",
        //        NormalizedUserName = "ADMIN",
        //        Email = "admin@admin.com",
        //        NormalizedEmail = "ADMIN@ADMIN.COM",
        //        EmailConfirmed = true,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        Id = 1
        //    };


        //    PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();

        //    builder.Entity<IdentityUser<int>>().HasData(admin);

        //    builder.Entity<IdentityUser<int>>().HasData(
        //        new IdentityRole<int> { Id = 1, Name = "admin", NormalizedName = "ADMIN" });

        //    builder.Entity<IdentityUserRole<int>>().HasData(
        //        new IdentityUserRole<int> { RoleId = 1, UserId = 1 });
        //}
    }
}
