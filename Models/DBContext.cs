using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace TaskManagementSystem.Models
{
    public class DBContext : IdentityDbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

       public DbSet<AppUser> AppUsers { get; set; }
       // public DbSet<TaskEntity> tblTask { get; set; }

        public DbSet<TaskEntity> tblTask { get; set; }

    }
}
