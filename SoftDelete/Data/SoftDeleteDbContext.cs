using Microsoft.EntityFrameworkCore;
using SoftDelete.Models;
using System.Collections.Generic;

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
        public DbSet<Product> Products { set; get; }
    }
}
