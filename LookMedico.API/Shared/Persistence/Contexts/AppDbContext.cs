using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.Security.Domain.Models;
using LookMedico.API.Shared.Extensions;
using LookMedico.API.StoreInventoryManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LookMedico.API.Shared.Persistence.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Doctors Configuration

        builder.Entity<Doctor>().ToTable("Doctors");
        builder.Entity<Doctor>().HasKey(d => d.Id);
        builder.Entity<Doctor>().Property(d => d.FirstName).IsRequired().HasMaxLength(30);
        builder.Entity<Doctor>().Property(d => d.LastName).IsRequired().HasMaxLength(30);
        builder.Entity<Doctor>().Property(d => d.Address).IsRequired();
        builder.Entity<Doctor>().Property(d => d.Email).IsRequired();
        builder.Entity<Doctor>().Property(d => d.Phone).IsRequired().HasMaxLength(9);
        
        //Suppliers Configuration
        builder.Entity<Supplier>().ToTable("Suppliers");
        builder.Entity<Supplier>().HasKey(s => s.Id);
        builder.Entity<Supplier>().Property(s => s.FirstName).IsRequired().HasMaxLength(30);
        builder.Entity<Supplier>().Property(s => s.LastName).IsRequired().HasMaxLength(30);
        builder.Entity<Supplier>().Property(s => s.Email).IsRequired();
        builder.Entity<Supplier>().Property(s => s.Address).IsRequired();
        builder.Entity<Supplier>().Property(s => s.Phone).IsRequired().HasMaxLength(9);
        builder.Entity<Supplier>().Property(s => s.BusinessName).IsRequired();
        
        // Categories Configuration
        
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Category>().Property(c => c.Description).IsRequired();
        builder.Entity<Category>().Property(c => c.PhotoUrl).IsRequired();
        
        // Tutorials Configuration
        
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(120);
        builder.Entity<Product>().Property(p => p.PhotoUrl).IsRequired();
        builder.Entity<Product>().Property(p => p.InventoryStatus).IsRequired();
        builder.Entity<Product>().Property(p => p.Price).IsRequired();

        // Relationships

        builder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
       
        // ProductTag Entity Mapping Configuration
        builder.Entity<ProductTag>()
            .HasKey(p => new { p.ProductId, p.TagId });
        builder.Entity<ProductTag>().ToTable("ProductTags");
        
        // Products and Tags Many-to-Many Relationship Mapping Configuration
        builder.Entity<ProductTag>()
            .HasOne(p => p.Product)
            .WithMany(p => p.ProductTags)
            .HasForeignKey(p => p.ProductId);
        
        builder.Entity<ProductTag>()
            .HasOne(p => p.Tag)
            .WithMany(p => p.ProductTags)
            .HasForeignKey(p => p.TagId);


        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired();
        builder.Entity<User>().Property(u => u.Password).IsRequired();

        builder.UseSnakeCaseNamingConventions();
    }
}
