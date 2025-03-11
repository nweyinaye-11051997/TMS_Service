using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace TaskManagementSystem.Models
{
    public class DBContext : IdentityDbContext<AppUser>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

       public DbSet<AppUser> AppUsers { get; set; }
       // public DbSet<TaskEntity> tblTask { get; set; }

        public DbSet<TaskEntity> tblTask { get; set; }
        public DbSet<AssignTaskEntity> tblAssignTask { get; set; }
        public DbSet<ProjectEntity> tblProject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.AssignTasks)
                .WithOne(a => a.taskEntity)
                .HasForeignKey(a => a.TaskID)
                .OnDelete(DeleteBehavior.Cascade); // Adjust if needed

            modelBuilder.Entity<AssignTaskEntity>().ToTable("tblAssignTask");
            modelBuilder.Entity<TaskEntity>().ToTable("tblTask");
        }
    }
}
