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
            // Configure entity properties and relationships here
            base.OnModelCreating(modelBuilder);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:tests-server-2025.database.windows.net,1433;Initial Catalog=stock-control;Persist Security Info=False;User ID=testuser;Password=TestTest123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
