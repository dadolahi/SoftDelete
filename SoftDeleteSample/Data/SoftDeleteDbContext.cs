using Microsoft.EntityFrameworkCore;
using SoftDeleteSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoftDeleteSample.Data
{
    public class SoftDeleteDbContext : DbContext
    {
        public SoftDeleteDbContext(DbContextOptions<SoftDeleteDbContext> option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDeleted == false);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Title 1", Price = 10 },
                new Product { Id = 2, Title = "Title 2", Price = 11 },
                new Product { Id = 3, Title = "Title 3", Price = 12 },
                new Product { Id = 4, Title = "Title 4", Price = 13 },
                new Product { Id = 5, Title = "Title 5", Price = 14 },
                new Product { Id = 6, Title = "Title 6", Price = 15 },
                new Product { Id = 7, Title = "Title 7", Price = 16 });
        }

        public override int SaveChanges()
        {
            DeleteToSoftDelete();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            DeleteToSoftDelete();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void DeleteToSoftDelete()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity.GetType() == typeof(Product) && entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.CurrentValues["IsDeleted"] = true;
                    Guid guid = Guid.NewGuid();
                    entry.CurrentValues["Title"] = $"{guid}@{entry.CurrentValues["Title"]}";
                }
            }
        }

        public DbSet<Product> Products { set; get; }
    }
}
