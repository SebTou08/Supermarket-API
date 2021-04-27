using Microsoft.EntityFrameworkCore;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Extensions;

namespace SuperMarket.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        
        
        
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Tag>Tags { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
//C A T E G O R Y   E N T I T Y             
            //Category Entity
            builder.Entity<Category>().ToTable("Categories");
            //Constraints
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            
            //Relationships
            builder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            
            
            //Initial Data 
           /* builder.Entity<Category>().HasData(
                new Category {Id=100, Name = "Fruits and Vegetables"},
                new Category {Id = 101, Name = "Dairy"}
            );*/
            
            //Product Entity
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
            
            
            
            
            // Initial Data
          /*  builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 100, Name = "Apple", QuantityInPackage = 1, UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 100
                },
                new Product
                {
                    Id = 100, Name = "Milk", QuantityInPackage = 2, UnitOfMeasurement = EUnitOfMeasurement.Liter,
                    CategoryId = 101
                }
            );*/
     
// T A G   E N T I T Y             
            //Tags Entity
            builder.Entity<Tag>().ToTable("Tags");
            builder.Entity<Tag>().HasKey(p => p.Id);
            builder.Entity<Tag>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tag>().Property(p => p.Name).IsRequired().HasMaxLength(30);


// P R O D U C T    T A G     E N T I T Y 
            builder.Entity<ProductTag>().ToTable("ProductTags");
            builder.Entity<ProductTag>().HasKey(p => new {p.ProductId, p.TagId});
            //RelationShips
            builder.Entity<ProductTag>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.ProductId);
            
            
            
            builder.Entity<ProductTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(pt => pt.TagId);

            //Naming conventions Policy
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}