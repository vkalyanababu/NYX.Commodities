using Microsoft.EntityFrameworkCore;
using NYX.Commodities.Services.ProductAPI.Models;

namespace NYX.Commodities.Services.ProductAPI.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(fld => { 
                fld.Property(b => b.ProductName).HasColumnType("nvarchar(100)").IsRequired();
                fld.Property(b => b.ProductColor).HasColumnType("nvarchar(20)").IsRequired();
                fld.Property(b => b.ProductPrice).HasColumnType("decimal(18,2)").IsRequired();
                fld.Property(b => b.ProductDescription).HasColumnType("nvarchar(200)");
            });


            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 1,
                ProductName = "iPhone 15 Pro",
                ProductColor = "Titanium",
                ProductPrice = 999.00M,
                ProductDescription = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit"
            });

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 2,
                ProductName = "iPhone 15",
                ProductColor = "Blue",
                ProductPrice = 899.00M,
                ProductDescription = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit"
            });

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 3,
                ProductName = "iPad",
                ProductColor = "Silver",
                ProductPrice = 570.00M,
                ProductDescription = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit"
            });

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 4,
                ProductName = "Mac Pro",
                ProductColor = "Black",
                ProductPrice = 1300.00M,
                ProductDescription = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit"
            });

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 5,
                ProductName = "AirPods",
                ProductColor = "White",
                ProductPrice = 260.00M,
                ProductDescription = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit"
            });
        }
    }
}
