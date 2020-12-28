using Microsoft.EntityFrameworkCore;
using SoftDelete.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SoftDelete.Data
{
    public class SoftDeleteDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\Sql2016; database=SoftDeleteDB01; User Id=sa ;Password=qwertyui;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDeleted == false);
            base.OnModelCreating(modelBuilder);
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
