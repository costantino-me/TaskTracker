using TaskTracker.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskTracker.API.Models;

namespace TaskTracker.API.Data
{
    public class DataContext : IdentityDbContext<User, Role, int, 
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext>  options) : base (options) {}
        public DbSet<ClientTask> ClientTasks { get; set; }
        public DbSet<UserClientTask> UserClientTasks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole => 
            {
                userRole.HasKey(ur => new {ur.UserId, ur.RoleId});

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<UserClientTask>(userClientTask => 
            {
                userClientTask.HasKey(uc => new {uc.UserId, uc.ClientTaskId});

                userClientTask.HasOne(uc => uc.ClientTask)
                    .WithMany(c => c.UserClientTasks)
                    .HasForeignKey(ur => ur.ClientTaskId)
                    .IsRequired();

                userClientTask.HasOne(uc => uc.User)
                    .WithMany(r => r.UserClientTasks)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}