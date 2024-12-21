using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Entities.Task> Task { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id); //id=> pk
                entity.Property(u => u.Id)
                      .ValueGeneratedOnAdd();

                entity.HasIndex(u => u.Email)//email=>uniquee
                      .IsUnique();

                //task and user => one to many
                modelBuilder.Entity<Entities.Task>()
              .HasOne(t => t.AssignedToUser)
              .WithMany(u => u.Task)
              .HasForeignKey(t => t.AssignedToUserId)
              .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
