using Microsoft.EntityFrameworkCore;
using StockControl.Domain.Entities;

namespace StockControl.DataAccess.EntityFramework
{
    public class StockControlDbContext : DbContext
    {
        public StockControlDbContext(DbContextOptions<StockControlDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; } //Property name identitical to the table name in de database (Product)
        public DbSet<ProductMovement> ProductMovement { get; set; } //Property name identitical to the table name in de database (ProductMovement)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Configure entity properties and relationships here, if necessary.
            base.OnModelCreating(modelBuilder);
        }
    }
}
