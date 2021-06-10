using System;
using Microsoft.EntityFrameworkCore;

namespace cambalache.Entities
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

    }
}
