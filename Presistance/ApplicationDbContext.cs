using Application.Common.Abstract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Presistance
{
    public class ApplicationDbContext : DbContext, ApplicationDbHelper
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configuration
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<User>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.Phone).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.CreatedBy).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.CreatedOn).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.ModifiedOn);
            modelBuilder.Entity<User>().Property(e => e.ModifiedBy);
            //        modelBuilder.Entity<User>().HasData(
            //new Customer { Id = Guid.NewGuid(), Name = "Ali", Fname = "Khan", Phone = "023204902843", CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.UtcNow });
            //        modelBuilder.Entity<Customer>().HasData(
            //new Customer { Id = Guid.NewGuid(), Name = "Faisal", Fname = "Mustaq", Phone = "023204902843", CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.UtcNow });
            //        modelBuilder.Entity<Customer>().HasData(
            //new Customer { Id = Guid.NewGuid(), Name = "Hanif", Fname = "Shahzad", Phone = "023204902843", CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.UtcNow });
            //        modelBuilder.Entity<Customer>().HasData(
            //new Customer { Id = Guid.NewGuid(), Name = "Saif", Fname = "Khan", Phone = "023204902843", CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.UtcNow });
            //        modelBuilder.Entity<Customer>().HasData(
            //new Customer { Id = Guid.NewGuid(), Name = "Sohail", Fname = "Khan", Phone = "023204902843", CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.UtcNow });
        }

        public DbSet<User> User => Set<User>();


        public int SaveChangesAsync()
        {
            return SaveChanges();
        }

    }
}
